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
        private int _genes;
        public void AddLayer(int neurons, Layer.Activation activation = Layer.Activation.Linear)
        {
            var data = new Tuple<int, Layer.Activation>(neurons, activation);
            layerData.Add(data);
        }
        public void Compile()
        {
            _genes = 0;
            for(int i = 0; i < layerData.Count; i++)
            {
                var data = layerData[i];
                Layer layer = new Layer((i == 0 ? 0 : layerData[i - 1].Item1), data.Item1, data.Item2);
                layer.Iniatilize();
                layers.Add(layer);
                if (i != 0)
                {
                    _genes += data.Item1 * (layerData[i-1].Item1 + 1);
                }
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
        public float[] GetGenes()
        {
            float[] res = new float[_genes];
            int index = 0;
            foreach (Layer layer in layers)
            {
                float[] genes = layer.GetGenes();
                if (genes.Length > 0)
                {
                    genes.CopyTo(res, index);
                    index += genes.Length;
                }


            }
            return res;
        }
        public void SetGenes(float[] genes)
        {
            int index = 0;
            foreach (Layer layer in layers)
            {
                float[] subgenes = new float[layer.Length()];
                Array.Copy(genes, index, subgenes, 0, layer.Length());
                layer.SetGenes(subgenes);
                index += layer.Length();

            }
        }
    }
}
