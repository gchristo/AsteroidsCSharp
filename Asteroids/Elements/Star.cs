using System.Drawing;

namespace Asteroids.Elements
{
    public class Star
    {
        public int Size { get; set; }
        public Point Position { get; set; }

        public Star(int size, Point position)
        {
            Size = size;
            Position = position;
        }

        public static Star[] CreateStars(int amount, int minSize, int maxSize, Size screenSize)
        {
            var ret = new Star[amount];

            for (int i = 0; i < amount; i++)
            {
                int starSize = Program.Random.Next(minSize, maxSize);

                int x = Program.Random.Next(starSize * 2, screenSize.Width - (starSize * 2));
                int y = Program.Random.Next(starSize * 2, screenSize.Height - (starSize * 2));
                var posicao = new Point(x, y);

                ret[i] = new Star(starSize, posicao);
            }

            return ret;
        }

    }
}
