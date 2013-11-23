using System;
using VitPro;
using VitPro.Engine;

class Game : State
{
    public const double c = 240;
    Camera cam = new Camera(c);



    public Game()
    {
        cam.Apply();
        World.Current = new World();
        World.Current.Platform = new Platform();
        World.Current.Platform.Position = new Vec2(0, -100);
        World.Current.Platform.AddWidth();
        World.Current.Platform.AddWidth();
        
        Ball b = new Ball();

        World.Current.Balls.Add(b);
        double w = 12, h = 4;
        for (int i = 1; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Block k = new Block1hp();
                if (i == 8 || i == 9 || j == 0 || j == 5)
                    k = new Block2hp();
                if (i < 4 && j > 2 && j < 5)
                    k = new Block3hp();
                k.Position = new Vec2(((i % 2 == 1) ? i / 2 * (w * 2 + 2) : -i / 2 * (w * 2 + 2)), j * (h * 2 + 2) + 60);

                if (Program.Random.Next(3) == 2)
                {
                    k.AddBonus();
                }

                World.Current.Blocks[i, j] = k;
            }
        }
        //GUtil.Dump(World.Current.Blocks, "./lvl1.dat");
        World.Current.Blocks = GUtil.Load<Block[,]>("temp.dat");

        World.Current.Effects.Add(new ShootLine());
    }

    public override void Update(double dt)
    {
        dt = Math.Min(dt, 1.0 / 60);
        base.Update(dt);
        World.Current.Update(dt);
        if (World.Current.Balls.Count == 0)
            App.NextState = new GameOver();
    }

    public override void Render()
    {
        Draw.Clear(Color.White);
        base.Render();
        World.Current.Render();
    }
    public override void KeyDown(Key key)
    {
        base.KeyDown(key);
        if (key == Key.Space)
        {
            if (World.Current.ShootBall != null)
            {
                World.Current.ShootBall.OnPlatform = false;
                World.Current.ShootBall = null;
                return;
            }
            foreach (var a in World.Current.Balls)
                if (a.OnPlatform)
                {
                    World.Current.ShootBall = a;
                    return;
                }
        }
    }
}

class Program
{
    public static Random Random = new Random();
    static void Main()
    {
        App.Fullscreen = false;
        App.Run(new Menu());
    }
}