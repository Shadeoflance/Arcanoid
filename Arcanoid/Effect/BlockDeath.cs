using VitPro;
using VitPro.Engine;
using System;

class BlockDeath : Effect
{
    Group<Particle> Particles = new Group<Particle>();
    Color Color = new Color(0.5, 0.5, 0.5);
    Ball ball;
    public BlockDeath(Block b)
    {
        foreach (var a in World.Current.Balls)
            if (ball == null || (a.Position - b.Position).Length < (ball.Position - b.Position).Length)
                ball = a;
        Position = b.Position;
        LifeTime = 1.5;
        Vec2 Dir = new Vec2(1, 0);
        for (int i = 0; i < 9; i++)
        {
            double t = Program.Random.NextDouble(0, Math.PI * 2);
            Dir = new Vec2(Math.Cos(t), Math.Sin(t));
            Particles.Add(new Particle(Position, Dir * 150, 1.5, Color, new Vec2(0, -1), 300));
        }
        Particles.Refresh();
    }
    public override void Update(double dt)
    {
        base.Update(dt);
        Particles.Update(dt);
        Color = new Color(0, 0, 0, 0.5 - Time / 3);
        foreach (var a in Particles)
        {
            a.Color = Color;
            a.Size = 1.5 - Time * 2 / 3;
        }
        foreach (var a in Particles)
        {
            a.g += dt * 300;
            a.Gravitation = (ball.Position - a.Position).Unit * 200;
            if ((a.Position - ball.Position).Length < 6)
                Particles.Remove(a);
        }
        Particles.Refresh();
    }
    public override void Render()
    {
        Particles.Render();
    }
}