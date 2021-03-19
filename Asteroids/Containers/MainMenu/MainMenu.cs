using Asteroids.Abstracts;

namespace Asteroids.Containers
{
    public class MainMenu : Scene
    {
        public MainMenu()
        {
            Layers.Add(new MenuInicial_Layers.MainMenu(this));
        }

        public override Scene ExecuteCommands()
        {
            return this;
        }
    }
}
