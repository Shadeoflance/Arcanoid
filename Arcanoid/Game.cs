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
        {
            Program.Manager.NextState = new Victory();
            return;
        }
        World.Current.Blocks = GUtil.Load<Block[,]>("./Data/levels/lvl" + CurrentLevel.ToString() + ".dat");
        World.Current.Platform.Position = new Vec2(0, -100);
        World.Current.Balls.Clear();

        World.Current.PlatformBall = new Ball();
    }
    public Game(int level)
    {
        World.Current = new World();
        World.Current.Platform = new Platform();
        World.Current.Platform.Position = new Vec2(0, -100);
        World.Current.Platform.AddWidth();
        World.Current.Platform.AddWidth();

        World.Current.PlatformBall = new Ball();
        CurrentLevel = level;
        World.Current.Blocks = GUtil.Load<Block[,]>("./Data/levels/lvl" + level.ToString() + ".dat");

        World.Current.Effects.Add(new ShootLine());
        World.Current.Effects.Add(new Score());
        World.Current.Effects.Add(new Lives());

        Ball.Speed = 200;
        Platform.Speed = 300;
    }

    public override void Update(double dt)
    {
        dt = Math.Min(dt, 1.0 / 60);
        base.Update(dt);
        World.Current.Update(dt);
        if (World.Current.Balls.Count == 0 && World.Current.PlatformBall == null)
        {
            World.Current.Lives--;
            World.Current.PlatformBall = new Ball();
            if(World.Current.Lives < 0)
                Program.Manager.NextState = new GameOver(World.Current.Score);
        }
    }

    public override void Render()
    {
        cam.Apply();
        Draw.Clear(Color.White);
        base.Render();
        World.Current.Render();
    }
    public override void KeyDown(Key key)
    {
        base.KeyDown(key);
        if (key == Key.Space)
        {
            if (World.Current.Shooting)
            {
                World.Current.Balls.Add(World.Current.PlatformBall);
                World.Current.PlatformBall = null;
                World.Current.Shooting = false;
                return;
            }
            if (World.Current.PlatformBall != null)
            {
                World.Current.Shooting = true;
                return;
            }
        }
    }
}

class Program
{
    public static Random Random = new Random();
    public static StateManager Manager = new StateManager(new Menu());
    public static Font font = new Font("./Data/font.TTF", 50, FontStyle.Bold);
    static void Main()
    {
        App.Fullscreen = false;
        font.Smooth = false;
        App.Run(Manager);
    }
}