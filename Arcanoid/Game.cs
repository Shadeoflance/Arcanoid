using System;
using VitPro;
using VitPro.Engine;

class Game : State
{
    public const double c = 240;
    Camera cam = new Camera(c);
    
    static int CurrentLevel;
    public static void NextLevel()
    {
        CurrentLevel++;
        if (CurrentLevel > 10)
            Program.Manager.NextState = new Victory();
        World.Current.Blocks = GUtil.Load<Block[,]>("./Data/levels/lvl" + CurrentLevel.ToString() + ".dat");
        World.Current.Platform.Position = new Vec2(0, -100);
        World.Current.Balls.Clear();

        Ball b = new Ball();
        World.Current.Balls.Add(b);
    }
    public Game(int level)
    {
        cam.Apply();
        World.Current = new World();
        World.Current.Platform = new Platform();
        World.Current.Platform.Position = new Vec2(0, -100);
        World.Current.Platform.AddWidth();
        World.Current.Platform.AddWidth();
        
        Ball b = new Ball();

        World.Current.Balls.Add(b);
        CurrentLevel = level;
        World.Current.Blocks = GUtil.Load<Block[,]>("./Data/levels/lvl" + level.ToString() + ".dat");

        World.Current.Effects.Add(new ShootLine());
        World.Current.Effects.Add(new Score());
    }

    public override void Update(double dt)
    {
        dt = Math.Min(dt, 1.0 / 60);
        base.Update(dt);
        World.Current.Update(dt);
        if (World.Current.Balls.Count == 0)
            Program.Manager.NextState = new GameOver();
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
    public static StateManager Manager = new StateManager(new Menu());
    static void Main()
    {
        App.Fullscreen = false;
        App.Run(Manager);
    }
}