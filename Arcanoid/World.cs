﻿using VitPro;
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
    public double ScreenB = -Game.c / 2, ScreenT = Game.c / 2, ScreenL = -Game.c * 1.3333 / 2, ScreenR = Game.c * 1.3333 / 2;
    public Ball ShootBall;
    public int Score = 0;

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
                        if (h == 0 && Blocks[i, j - 1] != null)
                            return;
                        if (h == 1 && Blocks[i + 1, j] != null)
                            return;
                        if (h == 2 && Blocks[i, j + 1] != null)
                            return;
                        if (h == 3 && Blocks[i - 1, j] != null)
                            return;
                        
                        b.Hit();
                        Effects.Add(new BallHit(a.Position, a.Box.Collide(b.Box)));
                        a.Collision(a.Box.Collide(b.Box));
                        World.Current.Effects.Add(new ScorePlus(a));
                        Score += a.Streak;
                        a.Streak *= 2;
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
                    Blocks[i, j] = null;
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