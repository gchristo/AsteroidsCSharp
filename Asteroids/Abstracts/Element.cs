using Asteroids.Elements;
using Asteroids.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Asteroids.Abstracts
{
    public abstract class Element
    {
        protected List<Type> WhoCollides { get; set; }
        public Point CurrentPosition { protected set; get; }
        public float CurrentSpeed { protected set; get; }
        public int Size { protected set; get; }
        public int[] Points { protected set; get; }
        public Brush Brush { protected set; get; }
        protected List<AngleHelper> PointsAngle { get; set; }
        private AngleHelper RotationAngle { get; set; }
        public int LifeTime { get; protected set; }
        public int Life { get; protected set; }
        public abstract bool IsAlive { get; }
        private int _currentAngle;
        public int CurrentAngle
        {
            protected set
            {
                var anguloNovo = AngleHelper.Normalize(value - _currentAngle);
                _currentAngle = AngleHelper.Normalize(value);
                RotationAngle = AngleHelper.Angles[_currentAngle];

                PointsAngle = new List<AngleHelper>();

                for (int i = 0; i < Points.Length; i++)
                {
                    Points[i] = AngleHelper.Normalize(Points[i] + anguloNovo);

                    PointsAngle.Add(AngleHelper.Angles[Points[i]]);
                }
            }
            get
            {
                return _currentAngle;
            }
        }

        protected Element()
        {
            WhoCollides = new List<Type>();
            PointsAngle = new List<AngleHelper>();
            Points = new int[0];
        }

        public abstract void Draw(Graphics g);

        public void Move(Size screenSize)
        {
            int x = (int)(CurrentPosition.X + RotationAngle.Cos * CurrentSpeed);
            int y = (int)(CurrentPosition.Y + RotationAngle.Sin * CurrentSpeed);

            if (x >= screenSize.Width)
            {
                x = 0;
            }
            else if (x <= 0)
            {
                x = screenSize.Width;
            }

            if (y >= screenSize.Height)
            {
                y = 0;
            }
            else if (y <= 0)
            {
                y = screenSize.Height;
            }

            CurrentPosition = new Point(x, y);

            if (LifeTime > 0)
            {
                LifeTime--;
            }
        }

        public void DidCollide(Element target)
        {
            if (WhoCollides.Contains(target.GetType()))
            {
                if (DistanceBetweenTwoElements(target) <= (target.Size + Size))
                {
                    target.Life--;
                    Life--;

                    Ship s = null;
                    Asteroid a = null;

                    if (target.GetType() == typeof(Asteroid))
                    {
                        a = (Asteroid)target;
                    }
                    else if (target.GetType() == typeof(Ship))
                    {
                        s = (Ship)target;
                    }
                    else if (target.GetType() == typeof(Shoot))
                    {
                        s = ((Shoot)target).Origin;
                    }

                    if (GetType() == typeof(Asteroid))
                    {
                        a = (Asteroid)this;
                    }
                    else if (GetType() == typeof(Ship))
                    {
                        s = (Ship)this;
                    }
                    else if (GetType() == typeof(Shoot))
                    {
                        s = ((Shoot)this).Origin;
                    }

                    if (s != null && a != null)
                    {
                        if (!a.IsAlive)
                        {
                            s.UpdateScore(a.Size + (int)(a.CurrentSpeed * 10));
                        }
                    }
                }
            }
        }

        private double DistanceBetweenTwoElements(Element target)
        {
            var x1 = target.CurrentPosition.X;
            var x2 = CurrentPosition.X;

            var y1 = target.CurrentPosition.Y;
            var y2 = CurrentPosition.Y;

            var x = x1 - x2;
            var y = y1 - y2;

            var cx = Math.Pow(x, 2);
            var cy = Math.Pow(y, 2);

            return Math.Sqrt(cx + cy);
        }
    }
}
