using System;
using System.Collections.Generic;

namespace Asteroids.Utils
{
    public class AngleHelper
    {
        public static List<AngleHelper> Angles;

        public int Degree { get; private set; }
        public double Sin { get; private set; }
        public double Cos { get; private set; }

        public AngleHelper(int degree)
        {
            Degree = degree;

            var rad = DegreeToRadians(degree);
            Sin = Math.Sin(rad);
            Cos = Math.Cos(rad);
        }

        static AngleHelper()
        {
            Angles = new List<AngleHelper>();

            for (int i = 0; i < 360; i++)
            {
                Angles.Add(new AngleHelper(i));
            }
        }

        public static double DegreeToRadians(int degree)
        {
            return degree * Math.PI / 180;
        }

        public static int Normalize(int degree)
        {
            return ((degree % 360) + 360) % 360;
        }

        public static int Reflect(int degree)
        {
            return Normalize(degree + 180);
        }
    }
}
