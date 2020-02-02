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
    }
}
