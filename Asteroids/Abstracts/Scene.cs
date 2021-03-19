using Asteroids.Utils;
using System.Collections.Generic;
using System.Drawing;

namespace Asteroids.Abstracts
{
    public abstract class Scene
    {
        public Size Size => Parent.Size;

        protected Stack<List<Command>> CommandStack;

        public List<Command> Commands => CommandStack.Count > 0 ? CommandStack.Peek() : new List<Command>();

        private FormGeral Parent => Program.FrmGeral;

        public List<Layer> Layers { get; set; }

        public Scene()
        {
            Layers = new List<Layer>();
            CommandStack = new Stack<List<Command>>();
        }

        public void AddLayer(Layer layer)
        {
            if (layer is ElementLayer layer1 && layer1.Commands.Count > 0)
            {
                CommandStack.Push(layer1.Commands);
            }
            Layers.Add(layer);
        }

        public void RemoveLayer(Layer layer)
        {
            if (layer is ElementLayer layer1 && layer1.Commands.Count > 0)
            {
                CommandStack.Pop();
            }
            Layers.Remove(layer);
        }

        public abstract Scene ExecuteCommands();

        public void ChangeScene(Scene c)
        {
            Parent.ChangeScene(c);
        }

        public Bitmap Draw()
        {
            var b = new Bitmap(Size.Width, Size.Height);
            using (var g = Graphics.FromImage(b))
            {
                foreach (var layer in Layers)
                {
                    layer.Draw(g);
                }
            }
            return b;
        }

        public Scene CalculateFrame()
        {
            foreach (var layer in Layers)
            {
                if (layer.CanUpdate)
                {
                    layer.CalculateFrame();
                }
            }

            return this;
        }
    }
}
