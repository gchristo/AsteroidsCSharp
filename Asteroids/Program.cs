using System;
using System.Windows.Forms;

namespace Asteroids
{
    static class Program
    {
        public static Random Random { private set; get; }
        public static FormGeral FrmGeral { private set; get; }

        /*
         * - PENSAR EM UMA FORMA MERDA DE QUEBRAR CADA ELEMENTO EM UM BITMAP SEPARADO
         *  - CADA BITMAP DEVE SER UMA THREAD (?)
         *  - TODOS BITMAPS DEVEM SER TRANSPARENTES (POR MOTIVOS OBVIOS)
         *  - UM BITMAP SERA O CANVAS, TODOS OS OUTROS DEVERÃO SER ESCALADOS ANTES DE SEREM ENCAIXADOS NO CANVAS
         *  - O CANVAS VAI USAR PLANO CARTESIANO
         *  - A DIMENSAO BASE SERA 800x600            
         */

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Random = new Random();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmGeral = new FormGeral();
            Application.Run(FrmGeral);
        }
    }
}
