using Asteroids.Abstracts;
using Asteroids.Elements;
using Asteroids.Utils;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids.Containers.Game_Layers
{
    public class MainGame : ElementLayer
    {
        public Ship ship;

        public MainGame(Scene container) : base(container)
        {
            Elements = new List<Element>();

            ship = new Ship(
                new int[] { 0, 135, 225 },
                10,
                new Point(Size.Width / 2, Size.Height / 2),
                0,
                0,
                Color.Blue);

            Elements.Add(ship);
            Elements.AddRange(Asteroid.CreateAsteroids(10, 10, 60, 15, Color.SandyBrown, Size));

            Commands = new List<Command>()
            {
                new Command()
                {
                    Name = "RotateLeft",
                    Key = Keys.A,
                    Event = ((Rotate) =>
                    {
                        if (Rotate)
                        {
                            ship.Rotate(-5);
                        }
                    })
                },
                new Command()
                {
                    Name = "RotateRight",
                    Key = Keys.D,
                    Event = ((Rotate) =>
                    {
                        if (Rotate)
                        {
                            ship.Rotate(5);
                        }
                    })
                },
                new Command()
                {
                    Name = "ChangeSpeed",
                    Key = Keys.W,
                    Event = ((Acelerar) =>
                    {
                        if (Acelerar)
                        {
                            ship.ChangeSpeed(.5f);
                        }
                        else
                        {
                            ship.ChangeSpeed(-.5f);
                        }
                    })
                },
                new Command()
                {
                    Name = "Shoot",
                    Key = Keys.Space,
                    Event = ((Atirar) =>
                    {
                        if (Atirar)
                        {
                            Elements.Add(ship.Shoot());
                        }
                    })
                },
                new Command()
                {
                    Name= "Pause",
                    Key = Keys.Escape,
                    Event = ((Pause) =>
                    {
                        foreach(var l in Parent.Layers)
                        {
                            l.CanUpdate = !Pause;
                        }
                    })
                }
            };
        }

        public override void CalculateFrame()
        {
            foreach (var el in Elements)
            {
                el.Move(Size);
            }

            CheckCollisions();
            Elements.RemoveAll(t => !t.IsAlive);

            if (!ship.IsAlive || Elements.Count == 1)
            {
                ChangeScene(new MainMenu());
            }
        }
    }
}
