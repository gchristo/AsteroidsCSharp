using Asteroids.Abstracts;
using Asteroids.Elements;
using System.Drawing;

namespace Asteroids.Containers.MenuInicial_Layers
{
    public class MainMenu : ElementLayer
    {
        int Contador = 50;
        readonly Text text;

        public MainMenu(Scene parent) : base(parent)
        {
            text = new Text(Color.Black, new Point(Size.Width / 2, Size.Height / 2), new Font(FontFamily.GenericSerif, 72));
            Elements.Add(text);
        }

        public override void CalculateFrame()
        {
            text.StringToWrite = (Contador--).ToString();
            if (Contador < 0)
            {
                ChangeScene(new Game());
            }
        }
    }
}
