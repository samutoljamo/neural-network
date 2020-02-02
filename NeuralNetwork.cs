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

        }
        public void Compile()
        {

        }
        static void Main()
        {
            Layer layer = new Layer(3, 5);
            layer.IniatilizeWeights();
            Console.ReadKey();
        }
    }
}
