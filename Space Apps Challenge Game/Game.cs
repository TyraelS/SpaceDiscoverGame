using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Resources;
using Space_Apps_Challenge_Game.Properties;


namespace Space_Apps_Challenge_Game
{
    class Game
    {
        private GameLogic GL;
        //Textures
        Bitmap BackGround = new Bitmap(Resources.BackGround);
        Bitmap p = new Bitmap(Resources.UFO, 40, 30);


        //events
        public event Action<Bitmap> NewFrame;
        public event Action<int> Question;

        //Palyer
        class Player
        {
            public float x = 840;
            public float y = 1200;
            public float vx = 0;
            public float vy = 0;
            public float r = 0;
        }
        Player Pl = new Player();

        //Controll
        public short CH = 0;
        public short CV = 0;

        //GameState
        bool Render = true;
        bool Running = true;
        SpaceObject Mercury = new SpaceObject(0, 0, 15, new Bitmap(Resources.Mercury, 30, 30),1);
        SpaceObject Venus = new SpaceObject(0, 0, 25, new Bitmap(Resources.Venus, 50, 50),2);
        SpaceObject Earth = new SpaceObject(0, 0, 40, new Bitmap(Resources.Earth_Moon, 80, 80),3);
        SpaceObject Mars = new SpaceObject(0, 0, 30, new Bitmap(Resources.Mars, 60, 60),4);
        SpaceObject Jupieter = new SpaceObject(0, 0, 50, new Bitmap(Resources.Jupieter, 100, 100),5);
        SpaceObject Saturn = new SpaceObject(0, 0, 50, new Bitmap(Resources.Saturn, 100, 100),6);
        SpaceObject Neptune = new SpaceObject(0, 0, 40, new Bitmap(Resources.Neptune, 800, 80),8);
        SpaceObject Uranus = new SpaceObject(0, 0, 50, new Bitmap(Resources.Uranus, 100, 100),7);
        SpaceObject Pluto = new SpaceObject(0, 0, 20, new Bitmap(Resources.Pluto, 40, 40),9);
        SpaceObject Sun = new SpaceObject(1000, 1000, 70, new Bitmap(Resources.Sun, 140, 140),0);
        List<SpaceObject> objects = new List<SpaceObject>();
        uint time = 99999;

        //Camera
        class Camera
        {
            public float x = 0;
            public float y = 0;
            public int SizeX = 0;
            public int SizeY = 0;
        }
        private Camera Cam = new Camera();

        //Threads
        Thread RenderThread;
        Thread MainThread;
        Thread TimerThread;

        private void Enter(int i)
        {
            RenderThread.Suspend();
            TimerThread.Suspend();
            Question(i);
            MainThread.Suspend();
        }

        private void Destroy()
        {
            GL.Score -= 10;
            time = 99999;
            Pl.x = 840;
            Pl.y = 1200;
            Enter(99);
        }

        public void Return()
        {
            SpaceObject o = null;
            float l = 999999;
            foreach (SpaceObject obj in objects)
            {
                float t = (float)Math.Sqrt(Math.Pow(obj.X - Pl.x, 2) + Math.Pow(obj.Y - Pl.y, 2));
                if ( t < l)
                {
                    l = t;
                    o = obj;
                }
            }
            Pl.vx = o.vx * 2;
            Pl.vy = o.vy * 2;
            Pl.x = o.X;
            Pl.y = o.Y - o.r * 2;
            RenderThread.Resume();
            TimerThread.Resume();
            MainThread.Resume();
        }

        public Game(int X, int Y,GameLogic gl)
        {
            Cam.SizeX = X;
            Cam.SizeY = Y;
            GL = gl;
        }

        public void Stop()
        {
            RenderThread.Abort();
            TimerThread.Abort();
            MainThread.Abort();
        }

        public void Start()
        {
            objects.Add(Mercury);
            objects.Add(Venus);
            objects.Add(Earth);
            objects.Add(Mars);
            objects.Add(Jupieter);
            objects.Add(Saturn);
            objects.Add(Neptune);
            objects.Add(Uranus);
            objects.Add(Pluto);
            objects.Add(Sun);
            TimerThread = new Thread(TimerThreadFunc);
            MainThread = new Thread(mainThreadFunc);
            RenderThread = new Thread(RenderThreadFunc);
            MainThread.Start();
            TimerThread.Start();
            RenderThread.Start();
            
        }

        string test = "";
        private void mainThreadFunc()
        {
            uint lastTime = 0;
            while (Running)
            {
                Thread.Sleep(20);
                //PlayerPhysics
                Pl.vx += CH * 0.01F;
                Pl.vy += CV * 0.01F;
                foreach (SpaceObject obj in objects)
                {
                    if (Math.Sqrt(Math.Pow(obj.X - Pl.x, 2) + Math.Pow(obj.Y - Pl.y, 2)) < obj.r)
                        if (Math.Abs(obj.vx - Pl.vx) + Math.Abs(obj.vy - Pl.vy) < 0.8)
                        {
                            if (obj.ID != 0)
                            {
                                Enter(obj.ID);
                            }
                            else
                            {
                                Destroy();
                            }
                        }
                        else
                        {
                            Destroy();
                        }
                }
                Pl.x += Pl.vx;
                Pl.y += Pl.vy;

                Cam.x = Pl.x - Cam.SizeX / 2;
                Cam.y = Pl.y - Cam.SizeY / 2;
                if (lastTime != time)
                {
                    //Mercury
                    Mercury.X = Sun.X + 116 * (float)Math.Sin(time / (26F * 10));
                    Mercury.Y = Sun.Y + 116 * (float)Math.Cos(time / (26F * 10));
                    Mercury.vx = 48 * (float)Math.Sin(time / (26F * 10) + Math.PI / 2) * 0.005F;
                    Mercury.vy = 48 * (float)Math.Cos(time / (26F * 10) + Math.PI / 2) * 0.005F;
                    //Venus
                    Venus.X = Sun.X + 216 * (float)Math.Sin(time / (66F * 10));
                    Venus.Y = Sun.Y + 216 * (float)Math.Cos(time / (66F * 10));
                    Venus.vx = 35 * (float)Math.Sin(time / (66F * 10) + Math.PI / 2) * 0.005F;
                    Venus.vy = 35 * (float)Math.Cos(time / (66F * 10) + Math.PI / 2) * 0.005F;
                    //Earth
                    Earth.X = Sun.X + 300 * (float)Math.Sin(time / (100F * 10));
                    Earth.Y = Sun.Y + 300 * (float)Math.Cos(time / (100F * 10));
                    Earth.vx = 29 * (float)Math.Sin(time / (100F * 10) + Math.PI / 2) * 0.005F;
                    Earth.vy = 29 * (float)Math.Cos(time / (100F * 10) + Math.PI / 2) * 0.005F;
                    //Mars
                    Mars.X = Sun.X + 460 * (float)Math.Sin(time / (188F * 10));
                    Mars.Y = Sun.Y + 460 * (float)Math.Cos(time / (188F * 10));
                    Mars.vx = 25 * (float)Math.Sin(time / (188F * 10) + Math.PI / 2) * 0.006F;
                    Mars.vy = 25 * (float)Math.Cos(time / (188F * 10) + Math.PI / 2) * 0.006F;
                    //Jupieter
                    Jupieter.X = Sun.X + 650 * (float)Math.Sin(time / (1186F * 10));
                    Jupieter.Y = Sun.Y + 650 * (float)Math.Cos(time / (1186F * 10));
                    Jupieter.vx = 16 * (float)Math.Sin(time / (1186F * 10) + Math.PI / 2) * 0.005F;
                    Jupieter.vy = 16 * (float)Math.Cos(time / (1186F * 10) + Math.PI / 2) * 0.005F;
                    //Saturn
                    Saturn.X = Sun.X + 800 * (float)Math.Sin(time / (2946F * 10));
                    Saturn.Y = Sun.Y + 800 * (float)Math.Cos(time / (2946F * 10));
                    Saturn.vx = 10 * (float)Math.Sin(time / (2946F * 10) + Math.PI / 2) * 0.005F;
                    Saturn.vy = 10 * (float)Math.Cos(time / (2946F * 10) + Math.PI / 2) * 0.005F;
                    //Uranus
                    Uranus.X = Sun.X + 950 * (float)Math.Sin(time / (8400F * 10));
                    Uranus.Y = Sun.Y + 950 * (float)Math.Cos(time / (8400F * 10));
                    //neptune
                    Neptune.X = Sun.X + 1150 * (float)Math.Sin(time / (10000F * 10));
                    Neptune.Y = Sun.Y + 1150 * (float)Math.Cos(time / (10000F * 10));
                    //pluto
                    Pluto.X = Sun.X + 1300 * (float)Math.Sin(time / (12000F * 10));
                    Pluto.Y = Sun.Y + 1300 * (float)Math.Cos(time / (12000F * 10));
                }
                lastTime = time;
            }
        }

        private void DrawObject(SpaceObject obj, Graphics Graph)
        {
            if (obj.X + obj.r > Cam.x - Cam.SizeX && obj.X - obj.r < Cam.x + Cam.SizeX)
                if (obj.Y + obj.r > Cam.y - Cam.SizeY && obj.Y - obj.r < Cam.y + Cam.SizeY)
                    Graph.DrawImage(obj.Texture, obj.X - obj.r - Cam.x, obj.Y - obj.r - Cam.y, obj.r * 2, obj.r * 2);
        }

        private void Timer()
        {
            Thread.Sleep(50);
        }

        private void RenderThreadFunc()
        {
            Bitmap bm = new Bitmap(Cam.SizeX, Cam.SizeY);
            Graphics Graph = Graphics.FromImage(bm);
            Thread t;
            while (Render)
            {
                t = new Thread(Timer);
                t.Start();
                Graph.DrawImage(BackGround, -Pl.x / 10, -Pl.y / 10, 1600, 1000);
                Graph.DrawImage(p, 380,285);
                DrawObject(Mercury, Graph);
                DrawObject(Venus, Graph);
                DrawObject(Earth, Graph);
                DrawObject(Mars, Graph);
                DrawObject(Jupieter, Graph);
                DrawObject(Saturn, Graph);
                DrawObject(Uranus, Graph);
                DrawObject(Neptune, Graph);
                DrawObject(Pluto, Graph);
                DrawObject(Sun, Graph);
                Graph.DrawString("Score : " + GL.Score, SystemFonts.CaptionFont, Brushes.Yellow, 10, 10);
                NewFrame(bm);
                t.Join();
            }
        }

        private void TimerThreadFunc()
        {
            while (Running)
            {
                time++;
                Thread.Sleep(20);
            }
        }
    }
}
