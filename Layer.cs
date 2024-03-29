﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    public class Layer
    {
        private float[] _neurons;
        private float[,] _weights;
        private float[] _biases;
        private Func<float[], float[]> _activation;
        private float[] minMax;
        public static Func<float, float, float> randomFunction;
        public Layer(int previous_neurons, int neurons, float[] minMax, Func<float[], float[]> activation = null, Func<float, float, float> randomFunc = null)
        {
            _neurons = new float[neurons];
            _weights = new float[previous_neurons, neurons];
            _biases = new float[previous_neurons == 0 ? 0 : neurons];
            _activation = activation == null ? Activation.Linear : activation;
            this.minMax = minMax;
            randomFunction = randomFunc;
            if (randomFunction == null)
            {
                randomFunction = Randomf;
            }
        }
        public int Length()
        {
            return _weights.Length == 0 ? 0 : _weights.Length + _biases.Length;
        }
        public void Initialize()
        {
            Random rand = new Random();
            for (int i = 0; i < _weights.GetLength(0); i++)
            {
                for (int j = 0; j < _weights.GetLength(1); j++)
                {
                    _weights[i, j] = randomFunction(minMax[0], minMax[1]);
                }
            }
            for (int i = 0; i < _biases.Length; i++)
            {
                 _biases[i] = randomFunction(minMax[2], minMax[3]);
            }
        }
        public float[] GetGenes()
        {
            if(_weights.Length == 0)
            {
                return new float[0];
            }
            float[] res = new float[_weights.Length + _biases.Length];
            for (int i = 0; i < _weights.GetLength(0); i++)
            {
                for (int j = 0; j < _weights.GetLength(1); j++)
                {
                    res[i * _weights.GetLength(1) + j] = _weights[i, j];
                }
            }
            for (int i = 0; i < _biases.Length; i++)
            {
                res[_weights.Length + i] = _biases[i];
            }
            return res;
        }

        public void SetGenes(float[] genes)
        {
            for (int i = 0; i < _weights.GetLength(0); i++)
            {
                for (int j = 0; j < _weights.GetLength(1); j++)
                {
                    _weights[i, j] = genes[i * _weights.GetLength(1) + j];
                }
            }

            for (int i = 0; i < _biases.Length; i++)
            {
                _biases[i] = genes[_weights.Length + i];
            }
        }

        public float[] Predict(float[] input)
        {
            if (_weights.Length == 0)
            {
                _neurons = input;
                return input;
            }
            for (int i = 0; i < _weights.GetLength(0); i++)
            {
                float inputVal = input[i];
                for (int j = 0; j < _weights.GetLength(1); j++)
                {
                    _neurons[j] += inputVal * _weights[i, j];
                }
            }
            for (int i = 0; i < _biases.Length; i++)
            {
                _neurons[i] += _biases[i];
            }
            _neurons =  _activation(_neurons);
            return _neurons;
        }
        public static float Randomf(float min, float max)
        {
            Random random = new Random();
            return (float)(random.NextDouble()) * (max - min) + min;
        }
    }
}
