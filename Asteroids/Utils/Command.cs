using System;
using System.Windows.Forms;

namespace Asteroids.Utils
{
    public class Command
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Keys Key { get; set; }
        public Action<bool> Event { get; set; }
    }
}
