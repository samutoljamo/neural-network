using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Activation
    {
        public static float[] Sigmoid(float[] input)
        {
            for (int i = 0; i < input.Count(); i++)
            {
                input[i] =  1 / ( 1 + (float)Math.Exp(-input[i]));
            }
            return input;
        }

        public static float[] Relu(float[] input)
        {
            for (int i = 0; i < input.Count(); i++)
            {
                if (input[i] < 0)
                {
                    input[i] = 0;
                }
            }
            return input;
        }
        public static float[] Linear(float[] input)
        { 
            return input;
        }

        public static float[] Tanh(float[] input)
        {

            for (int i = 0; i < input.Count(); i++)
            {
                float num = input[i];
                input[i] = ((float)Math.Exp(input[i]) - (float)Math.Exp(-input[i])) / ((float)Math.Exp(input[i]) + (float)Math.Exp(-input[i]));
                if (input[i] != input[i])
                {
                    if (num > 0)
                    {
                        input[i] = 1;
                    }
                    else
                    {
                        input[i] = -1;
                    }
                }
            }
            return input;
        }
    }
}
