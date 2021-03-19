using Asteroids.Abstracts;
using Asteroids.Elements;
using System.Drawing;

namespace Asteroids.Containers.Game_Layers
{
    public class HUD : Layer
    {
        readonly Text Text;
        readonly Ship Ship;

        public HUD(Scene parent, Ship ship) : base(parent)
        {
            Ship = ship;
            Text = new Text(Color.Yellow, new Point(0, 0), SystemFonts.DefaultFont);
        }

        public override void CalculateFrame() { }

        public override void Draw(Graphics g)
        {
            Text.Draw(Ship.Score.ToString(), g);
        }
    }
}
