using Asteroids.Abstracts;
using System.Drawing;

namespace Asteroids.Elements
{
    internal class Background : Element
    {
        private new Size Size { get; set; }

        public override bool IsAlive => true;

        public Background(Size size, Color color) : base()
        {
            Brush = new SolidBrush(color);
            Size = size;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brush, 0, 0, Size.Width, Size.Height);
        }
    }
}