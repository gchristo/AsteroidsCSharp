using Asteroids.Abstracts;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Asteroids.Elements
{
    public class Asteroid : Element
    {
        private readonly Brush FontBrush;

        public override bool IsAlive => Life > 0;

        public static List<Asteroid> CreateAsteroids(int amount, int minSize, int maxSize, int polygonPointCount, Color color, Size screenSize)
        {
            var ret = new List<Asteroid>();

            for (int i = 0; i < amount; i++)
            {
                ret.Add(CreateAsteroid(minSize, maxSize, polygonPointCount, color, screenSize));
            }

            return ret;
        }

        public static Asteroid CreateAsteroid(int minSize, int maxSize, int polygonPointCount, Color color, Size screenSize)
        {
            var size = Program.Random.Next(minSize, maxSize);

            var points = new int[polygonPointCount];
            for (int i = 0; i < polygonPointCount; i++)
            {
                points[i] = Program.Random.Next(0, 359);
            }
            Array.Sort(points);

            int x = Program.Random.Next(size * 2, screenSize.Width - (size * 2));
            int y = Program.Random.Next(size * 2, screenSize.Height - (size * 2));
            var startPosition = new Point(x, y);

            var direction = Program.Random.Next(0, 359);
            var speed = ((minSize + maxSize) / size) + 1;

            return new Asteroid(points, size, startPosition, direction, speed, color);
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
            g.DrawString(Life.ToString(), SystemFonts.DefaultFont, FontBrush, CurrentPosition);
        }

        public Asteroid(int[] points, int size, Point startPosition, int direction, int speed, Color color) : base()
        {
            Points = points;
            Size = size;
            CurrentPosition = startPosition;
            CurrentAngle = direction;
            CurrentSpeed = speed;

            Brush = new SolidBrush(color);
            FontBrush = new SolidBrush(Color.Black);

            WhoCollides.AddRange(new[]
            {
                typeof(Shoot),
                typeof(Ship)
            });
            Life = size / 10;
        }
    }
}
