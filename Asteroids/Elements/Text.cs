using Asteroids.Abstracts;
using System.Drawing;

namespace Asteroids.Elements
{
    public class Text : Element
    {
        private Brush FontBrush { get; set; }
        private Font Font { get; set; }
        public string StringToWrite { get; set; }

        public override bool IsAlive => true;

        public Text(Color color, Point startPosition, Font font) : base()
        {
            CurrentPosition = startPosition;
            FontBrush = new SolidBrush(color);
            Font = font;
        }

        public void Draw(string stringToWrite, Graphics g)
        {
            StringToWrite = stringToWrite;
            Draw(g);
        }

        public override void Draw(Graphics g)
        {
            g.DrawString(StringToWrite, Font, FontBrush, CurrentPosition);
        }
    }
}
