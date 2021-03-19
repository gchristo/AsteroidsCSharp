using Asteroids.Abstracts;
using Asteroids.Utils;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class FormGeral : Form
    {
        private Scene c;
        private Thread gameLoop;

        public FormGeral()
        {
            InitializeComponent();
        }
        public void ChangeScene(Scene c)
        {
            this.c = c;
        }

        private void FormGeral_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gameLoop != null)
            {
                gameLoop.Abort();
            }
        }

        private void FormGeral_KeyUp(object sender, KeyEventArgs e)
        {
            var command = c.Commands.FirstOrDefault(c => c.Key == e.KeyCode);
            if (command != null)
            {
                command.IsActive = false;
            }
        }

        private void FormGeral_KeyDown(object sender, KeyEventArgs e)
        {
            var command = c.Commands.FirstOrDefault(c => c.Key == e.KeyCode);
            if (command != null)
            {
                command.IsActive = true;
            }
        }

        private void FormGeral_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            ChangeScene(new Containers.MainMenu());

            gameLoop = GameLoop.NewGameLoop(30, () =>
            {
                Invoke((MethodInvoker)delegate
                {
                    BackgroundImage = c
                        .ExecuteCommands()
                        .CalculateFrame()
                        .Draw();
                });
            }, true);
        }
    }
}
