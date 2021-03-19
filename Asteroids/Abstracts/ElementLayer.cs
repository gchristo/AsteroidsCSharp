using Asteroids.Utils;
using System.Collections.Generic;
using System.Drawing;

namespace Asteroids.Abstracts
{
    public abstract class ElementLayer : Layer
    {
        public List<Element> Elements { get; set; }
        public List<Command> Commands { get; set; }

        public ElementLayer(Scene parent) 
            : base(parent)
        {
            Commands = new List<Command>();
            Elements = new List<Element>();
        }

        public override void Draw(Graphics g)
        {
            foreach (var elemento in Elements)
            {
                elemento.Draw(g);
            }
        }

        public void CheckCollisions()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                for (int j = i + 1; j < Elements.Count; j++)
                {
                    Elements[i].DidCollide(Elements[j]);
                }
            }
        }
    }
}
