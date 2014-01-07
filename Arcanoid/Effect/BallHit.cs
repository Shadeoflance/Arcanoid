using VitPro;
using VitPro.Engine;
using System;
using System.Collections.Generic;

class BallHit : Effect
{

    Group<Particle> Particles = new Group<Particle>();

    public BallHit(Vec2 Position, int Side)
    {
        this.Position = Position;
        LifeTime = 0.5;
        foreach (var a in World.Current.Balls)
        {
            Position += a.Size.X * Box.Side(Side);
            break;
        }
        for (int i = 0; i < 5; i++)
        {
            Particle w = new Particle(Position, Vec2.Zero, 1, new Color(0.5, 0.5, 0.5), new Vec2(0, -100), 100);
            switch (Side)
            {
                case 0:
                    {
                        w.Vel = new Vec2(Program.Random.NextDouble(-1, 1), Program.Random.NextDouble(-1, 0));
                        break;
                    }
                case 1:
                    {
                        w.Vel = new Vec2(Program.Random.NextDouble(-1, 0), Program.Random.NextDouble(-1, 1));
                        break;
                    }
                case 2:
                    {
                        w.Vel = new Vec2(Program.Random.NextDouble(-1, 1), Program.Random.NextDouble(0, 1));
                        break;
                    }
                case 3:
                    {
                        w.Vel = new Vec2(Program.Random.NextDouble(0, 1), Program.Random.NextDouble(-1, 1));
                        break;
                    }
            }
            w.Vel = w.Vel.Unit;
            w.Vel *= Program.Random.NextDouble(30, 50);
            Particles.Add(w);
        }
        Particles.Refresh();
    }

    public override void Update(double dt)
    {
        base.Update(dt);
        Particles.Update(dt);
    }

    public override void Render()
    {
        base.Render();
        foreach (var a in Particles)
            a.Color = new Color(0, 0, 0, LifeTime - Time);
        Particles.Render();
    }
}