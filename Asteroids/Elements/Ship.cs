using Asteroids.Abstracts;
using System;
using System.Drawing;

namespace Asteroids.Elements
{
    public class Ship : Element
    {
        public override bool IsAlive => Life > 0;

        private const int MAX_SPEED = 10;
        private const int MIN_SPEED = 0;

        public int Score { get; private set; }

        public Ship(int[] points, int size, Point startPosition, int direction, int speed, Color color) : base()
        {
            Points = points;
            Size = size;
            CurrentPosition = startPosition;
            CurrentAngle = direction;
            CurrentSpeed = speed;
            Brush = new SolidBrush(color);

            WhoCollides.Add(typeof(Asteroid));
            Life = 10;
        }

        public override void Draw(Graphics g)
        {
            var points = new PointF[Points.Length];

            for (int i = 0; i < Points.Length; i++)
            {
                var a1 = PointsAngle[i];
                var x1 = (int)((a1.Cos * Size) + CurrentPosition.X);
                var y1 = (int)((a1.Sin * Size) + CurrentPosition.Y);

                points[i] = new Point(x1, y1);
            }

            g.FillPolygon(Brush, points);
            g.DrawEllipse(new Pen(Color.Green, Life - 1), CalculateShield());
        }

        private Rectangle CalculateShield()
        {
            var x = CurrentPosition.X - (Size / 2) - Life;
            var y = CurrentPosition.Y - (Size / 2) - Life;
            var wh = Size + (Life * 2) + 1;

            var ret = new Rectangle(x, y, wh, wh);

            return ret;
        }

        public void Rotate(int degree)
        {
            CurrentAngle += degree;
        }

        public void ChangeSpeed(float acceleration)
        {
            if ((acceleration > 0 && CurrentSpeed < MAX_SPEED)
                || (acceleration < 0 && CurrentSpeed > MIN_SPEED))
            {
                CurrentSpeed += acceleration;
            }
        }

        public Point Front
        {
            get
            {
                var a1 = PointsAngle[0];
                var x1 = (int)((a1.Cos * Size) + CurrentPosition.X);
                var y1 = (int)((a1.Sin * Size) + CurrentPosition.Y);

                return new Point(x1, y1);
            }
        }

        public void UpdateScore(int value)
        {
            Score += value;
        }

        public Shoot Shoot()
        {
            return new Shoot(this, 4, Front, CurrentAngle, MAX_SPEED * 1.2f, Color.Red, 50);
        }
    }
}
