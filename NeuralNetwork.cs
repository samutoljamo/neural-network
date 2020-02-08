using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        private List<Layer> layers = new List<Layer>();
        private List<Tuple<int, Layer.Activation>> layerData = new List<Tuple<int, Layer.Activation>>();
        public void AddLayer(int neurons, Layer.Activation activation = Layer.Activation.Sigmoid)
        {
            var data = new Tuple<int, Layer.Activation>(neurons, activation);
            layerData.Add(data);
        }
        public void Compile()
        {
            for(int i = 0; i < layerData.Count; i++)
            {
                var data = layerData[i];
                Layer layer = new Layer(data.Item1, i == layerData.Count - 1 ? 0 : layerData[i + 1].Item1, data.Item2);
                layer.IniatilizeWeights();
                layers.Add(layer);
            }
        }
        public float[] Predict(float[] input)
        {

            foreach(Layer layer in layers)
            {
                input = layer.Predict(input);
            }
            return input;
        }
        static void Main()
        {
            NeuralNetwork n = new NeuralNetwork();
            n.AddLayer(3, Layer.Activation.Relu);
            n.AddLayer(3, Layer.Activation.Sigmoid);
            n.Compile();
            Console.WriteLine("Done");
            float[] prediction = n.Predict(new float[] { 3, 3, 3});
            for (int i = 0; i < prediction.Length; i++)
            {
                Console.Write(prediction[i]);
                Console.Write("  ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
