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
        World.Current.Balls.Refresh();

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

        //for (int i = 2; i < 13; i++)
        //    for (int j = 1; j < 14; j++)
        //        World.Current.Blocks[i, j] = null;
        //World.Current.Blocks[8, 8] = new Block(3);

        World.Current.Effects.Add(new ShootLine());
        World.Current.Effects.Add(new Score());
        World.Current.Effects.Add(new Lives());

        Ball.Speed = 200;
        Platform.Speed = 300;
    }

    public override void Update(double dt)
    {
        dt = Math.Min(dt, 1d / 60);
        base.Update(dt);
        World.Current.Update(dt);
        if (World.Current.Lives < 0)
        {
            Texture tex = new Texture(Draw.Width, Draw.Height);
            Draw.BeginTexture(tex);
            Render();
            Draw.EndTexture();
            StateManager.NextState = new GameOver(World.Current.Score, tex);
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
        if (key == Key.Escape)
        {
            Texture tex = new Texture(Draw.Width, Draw.Height);
            Draw.BeginTexture(tex);
            Render();
            Draw.EndTexture();
            StateManager.PushState(new Pause(tex));
        }
        if (key == Key.R)
            StateManager.NextState = new Game(1);
    }
}

class Program
{
    public static Random Random = new Random();
    public static MyManager Manager = new MyManager(new Menu());
    public static Font font = new Font("./Data/font.TTF", 50, FontStyle.Bold);
    static void Main()
    {
        App.Fullscreen = false;
#if !DEBUG
        App.VSync = true;
#endif
        font.Smooth = false;
        App.Run(Manager);
    }
}