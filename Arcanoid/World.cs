using VitPro;
using VitPro.Engine;
using System;

class World : IRenderable, IUpdateable
{
    public Platform Platform = null;
    public static World Current = null;
    public Group<Ball> Balls = new Group<Ball>();
    public Block[,] Blocks = new Block[15, 15];
    public Group<Bonus> Bonuses = new Group<Bonus>();
    public Group<Effect> Effects = new Group<Effect>();
    public double ScreenB = -Game.c / 2 + 2, ScreenT = Game.c / 2 - 2, ScreenL = -Game.c * 1.3333 / 2 + 2, ScreenR = Game.c * 1.3333 / 2 - 2;
    public Ball ShootBall;
    public int Score = 0;

    public int CurrentBalls
    {
        get
        {
            int t = 0;
            foreach (var a in Balls)
                if (a.OnPlatform == false)
                    t++;
            return t;
        }
    }

    bool BlockCheck()
    {
        foreach (var a in Blocks)
            if (a != null)
                return false;
        return true;
    }

    void Collision()
    {
        foreach (var a in Balls)
        {
            if (a.Position.X > ScreenR - Ball.Size.Length)
            {
                a.Collision(1);
            }
            if (a.Position.X < ScreenL + Ball.Size.Length)
            {
                a.Collision(3);
            }
            if (a.Position.Y > ScreenT - Ball.Size.Length)
            {
                a.Collision(0);
            }

            if (a.Box.Collide(Platform.Box) != -1 && !a.OnPlatform)
            {
                if (a.Box.Collide(Platform.Box) != 2)
                {
                    a.Collision(a.Box.Collide(Platform.Box));
                    return;
                }
                a.PlatformCollision((a.Position.X - Platform.Position.X) / Platform.Size.X);
            }

            for(int i = 1; i < Blocks.GetUpperBound(0); i++)
                for(int j = 1; j <= Blocks.GetUpperBound(1); j++)
                {
                    Block b = Blocks[i, j];
                    if (b == null)
                        continue;
                    if (b.Box.Collide(a.Box) != -1)
                    {
                        int h = b.Box.Collide(a.Box);
                        bool sidebug = false;
                        if (h == 0 && Blocks[i, j - 1] != null)
                            sidebug = true;
                        if (h == 1 && Blocks[i + 1, j] != null)
                            sidebug = true;
                        if (h == 2 && Blocks[i, j + 1] != null)
                            sidebug = true;
                        if (h == 3 && Blocks[i - 1, j] != null)
                            sidebug = true;
                        
                        if (!sidebug)
                        {
                            b.Hit();
                            Effects.Add(new BallHit(a.Position, a.Box.Collide(b.Box)));
                            a.Collision(a.Box.Collide(b.Box));
                            World.Current.Effects.Add(new ScorePlus(a));
                            Score += a.Streak * CurrentBalls;
                            if (a.Streak != 1024)
                                a.Streak *= 2;
                            switch (h)
                            {
                                case 0:
                                    {
                                        a.Position = new Vec2(a.Position.X, b.Position.Y + Block.Size.Y + Ball.Size.Y);
                                        break;
                                    }
                                case 1:
                                    {
                                        a.Position = new Vec2(b.Position.X + Block.Size.X + Ball.Size.X, a.Position.Y);
                                        break;
                                    }
                                case 2:
                                    {
                                        a.Position = new Vec2(a.Position.X, b.Position.Y - Block.Size.Y - Ball.Size.Y);
                                        break;
                                    }
                                case 3:
                                    {
                                        a.Position = new Vec2(b.Position.X - Block.Size.X - Ball.Size.X, a.Position.Y);
                                        break;
                                    }
                            }
                        }
                    }
                }
        }
        foreach (var a in Bonuses)
            if (!a.Alive)
                Bonuses.Remove(a);
    }

    public void Update(double dt)
    {
        Balls.Refresh();
        Bonuses.Refresh();
        Effects.Refresh();
        for (int i = 1; i < Blocks.GetUpperBound(0); i++)
            for (int j = 1; j <= Blocks.GetUpperBound(1); j++)
                if (Blocks[i, j] != null && Blocks[i, j].HP == 0)
                {
                    Blocks[i, j] = null;
                    if (BlockCheck())
                        Game.NextLevel();
                }
        Effects.Update(dt);
        if (ShootBall != null)
        {
            return;
        }
        Platform.Update(dt);
        Balls.Update(dt);
        Bonuses.Update(dt);

        Collision();
    }

    public void Render()
    {
        Platform.Render();
        Balls.Render();
        foreach (Block a in Blocks)
            if(a != null)
                a.Render();
        Bonuses.Render();
        Effects.Render();
    }
}