using Asteroids.Abstracts;
using System.Drawing;

namespace Asteroids.Elements
{
    public class Shoot : Element
    {
        public Ship Origin { private set; get; }

        public override bool IsAlive => LifeTime > 0;

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brush, CurrentPosition.X, CurrentPosition.Y, Size, Size);
        }

        public Shoot(Ship origin, int size, Point startPosition, int direction, float speed, Color color, int timeToLive) : base()
        {
            Size = size;
            CurrentAngle = direction;
            CurrentSpeed = speed;
            Brush = new SolidBrush(color);
            LifeTime = timeToLive;

            startPosition.X -= size / 2;
            startPosition.Y -= size / 2;

            CurrentPosition = startPosition;

            Origin = origin;

            WhoCollides.Add(typeof(Asteroid));
            Life = 1;
        }
    }
}
