using VitPro.Engine;
using VitPro;
using System;

class BonusGet : Effect
{
    Group<Particle> Particles = new Group<Particle>();
    Color Color = new Color(0.5, 0.5, 0.5);
    public BonusGet(bool bad, Vec2 position)
    {
        Position = position;
        LifeTime = 3;
        Vec2 Dir = new Vec2(1, 0);
        Color = (bad) ? Color.Red : Color.Green;
        for (int i = 0; i < 12; i++)
        {
            double t = Program.Random.NextDouble(Math.PI / 6, Math.PI * 5 / 6);
            Dir = new Vec2(Math.Cos(t), Math.Sin(t));
            t = Program.Random.NextDouble(0.5, 1.2);
            Particles.Add(new Particle(Position, Dir * 150 * t, 1.5, Color, (World.Current.Platform.Position - Position).Unit, -1, 250));
        }
        Particles.Refresh();
    }
    public override void Update(double dt)
    {
        base.Update(dt);
        Particles.Update(dt);
        Color = new Color(Color.R, Color.G, 0, 1 - Time / 3);
        foreach (var a in Particles)
        {
            a.Color = Color;
            a.Size = 1.2 - Time / 3;
        }
        foreach (var a in Particles)
        {
            a.Gravitation = (World.Current.Platform.Position - a.Position).Unit * 200;
            if ((a.Position - World.Current.Platform.Position).Length < 7)
                Particles.Remove(a);
        }
        Particles.Refresh();
    }
    public override void Render()
    {
        Particles.Render();
    }
}