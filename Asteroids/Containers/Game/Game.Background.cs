using Asteroids.Abstracts;
using System.Drawing;
using Asteroids.Elements;

namespace Asteroids.Containers.Game_Layers
{
    public class Background : Layer
    {
        public Star[] Stars { private set; get; }
        public Brush Brush { private set; get; }
        public Brush BrushStars { private set; get; }

        public Background(Scene container, Color corFundo, int nEstrelas, int minTamanho, int maxTamanho, Color corEstrelas) 
            : base(container)
        {
            Brush = new SolidBrush(corFundo);
            BrushStars = new SolidBrush(corEstrelas);
            Stars = Star.CreateStars(nEstrelas, minTamanho, maxTamanho, container.Size);
        }

        public override void CalculateFrame() { }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brush, 0, 0, Size.Width, Size.Height);

            foreach (var e in Stars)
            {
                g.FillEllipse(BrushStars, e.Position.X, e.Position.Y, e.Size, e.Size);
            }
        }
    }
}
