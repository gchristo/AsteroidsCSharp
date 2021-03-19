using Asteroids.Abstracts;
using Asteroids.Containers.Game_Layers;
using Asteroids.Elements;
using System.Drawing;

namespace Asteroids.Containers
{
    public class Game : Scene
    {
        private readonly Ship ship;

        public Game()
        {
            AddLayer(new Game_Layers.Background(this, Color.Black, 100, 2, 10, Color.White));

            var mg = new MainGame(this);
            ship = mg.ship;

            AddLayer(mg);
            AddLayer(new HUD(this, ship));
        }

        public override Scene ExecuteCommands()
        {
            if (ship.IsAlive)
            {
                foreach (var c in Commands)
                {
                    c.Event?.Invoke(c.IsActive);
                }
            }

            return this;
        }
    }
}
