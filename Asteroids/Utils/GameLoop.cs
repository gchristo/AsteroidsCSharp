using System;
using System.Diagnostics;
using System.Threading;

namespace Asteroids.Utils
{
    public static class GameLoop
    {
        public static long FrameTime { private set; get; }

        public static Thread NewGameLoop(int fps, Action action)
        {
            return new Thread(() =>
            {
                int sleepMaximo = 1000 / fps;

                var sw = Stopwatch.StartNew();
                while (true)
                {
                    action();

                    FrameTime = sw.ElapsedMilliseconds;
                    var sleep = sleepMaximo - (int)FrameTime;
                    if (sleep > 0)
                    {
                        Thread.Sleep(sleep);
                    }
                    GC.Collect();
                    sw.Restart();
                }
            });
        }

        public static Thread NewGameLoop(int fps, Action action, bool immediateStart)
        {
            var t = NewGameLoop(fps, action);
            if (immediateStart)
            {
                t.Start();
            }
            return t;
        }
    }
}
