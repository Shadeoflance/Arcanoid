using System;
using VitPro;
using VitPro.Engine;

class Firework : Effect
{
    Color Color;
    Group<Particle> Particles = new Group<Particle>();
    public Firework(Vec2 position)
    {
        LifeTime = 1.5;
        Position = position;
        Color = new Color(Program.Random.NextDouble(0.3, 1), Program.Random.NextDouble(0.3, 1), Program.Random.NextDouble(0.3, 1));
        for(int i = 0; i < 20; i++)
            Particles.Add(new Particle(Position, new Vec2(Math.Cos(Math.PI * i / 10), Math.Sin(Math.PI * i / 10)) * 20, 0.1, Color, new Vec2(0, -0.5), 3, 50));
        for (int i = 0; i < 20; i++)
            Particles.Add(new Particle(Position, new Vec2(Math.Cos(Math.PI * i / 10), Math.Sin(Math.PI * i / 10)) * Program.Random.NextDouble(15, 19), 0.1, Color, new Vec2(0, -0.5), 3, 50));
        for (int i = 0; i < 20; i++)
            Particles.Add(new Particle(Position, new Vec2(Math.Cos(Math.PI * i / 10), Math.Sin(Math.PI * i / 10)) * Program.Random.NextDouble(9, 15), 0.1, Color, new Vec2(0, -0.5), 3, 50));
    }
    public override void Update(double dt)
    {
        base.Update(dt);
        Particles.Update(dt);
        Particles.Refresh();
    }
    public override void Render()
    {
        base.Render();
        Particles.Render();
    }

}