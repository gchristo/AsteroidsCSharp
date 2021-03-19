using System.Drawing;

namespace Asteroids.Abstracts
{
    public abstract class Layer
    {
        public Size Size => Parent.Size;
        public bool CanUpdate { get; set; }

        protected Scene Parent;

        public Layer(Scene parent)
        {
            Parent = parent;
            CanUpdate = true;
        }

        public void AddLayer(Layer layer)
        {
            Parent.AddLayer(layer);
        }

        public void RemoveLayer(Layer layer)
        {
            Parent.RemoveLayer(layer);
        }

        public void ChangeScene(Scene cena)
        {
            Parent.ChangeScene(cena);
        }

        public abstract void CalculateFrame();

        public abstract void Draw(Graphics g);
    }
}
