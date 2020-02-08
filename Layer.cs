using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    public class Layer
    {
        public enum Activation {Sigmoid, Relu}
        private float[] _neurons;
        private float[,] _weights;
        private Activation _activation;
        public Layer(int neurons, int next_neurons, Activation activation = Activation.Sigmoid)
        {
            _neurons = new float[neurons];
            _weights = new float[neurons, next_neurons];
            _activation = activation;
        }

        public void IniatilizeWeights()
        {
            Random rand = new Random();
            for (int i = 0; i < _weights.GetLength(0); i++)
            {
                for (int j = 0; j < _weights.GetLength(1); j++)
                {
                    _weights[i, j] = (float)(rand.NextDouble()) * 4 - 2;
                }
            }
        }

        public float[] Predict(float[] input)
        {

            if (input.Length != _neurons.Length)
            {
                throw new ArgumentException();
            }
            if (_weights.GetLength(1) == 0)
            {
                return ActivateLayer(input, _activation);
            }
            _neurons = input;
            float[] res = new float[_weights.GetLength(1)];
            for (int i = 0; i < _weights.GetLength(0); i++)
            {
                float inputVal = input[i];
                for (int j = 0; j < _weights.GetLength(1); j++)
                {
                    res[j] += inputVal * _weights[i, j];
                }
            }
            res = ActivateLayer(res, _activation);
            return res;
        }
        public static float[] ActivateLayer(float[] input, Activation activation)
        {
            Func<float[], float[]> activationFunc = null;
            if (activation == Activation.Sigmoid)
            {
                activationFunc = Activate.Sigmoid;

            }
            if (activation == Activation.Relu)
            {
                activationFunc = Activate.Relu;

            }
            return activationFunc(input);
        }
    }
}
