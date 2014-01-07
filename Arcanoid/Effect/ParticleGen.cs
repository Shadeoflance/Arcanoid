using VitPro;
using VitPro.Engine;
using System;

class ParticleGen : IRenderable, IUpdateable
{
    Group<Particle> Particles = new Group<Particle>();
    Vec2 Position;
    Vec2 Dir;
    Vec2 Gravity;
    double Force;
    double PPS;
    double T = 0;
    Color Color;
    double Fade;
    double Spread;
    double SpeedSpread;
    public bool Produce = true;

    public ParticleGen(Vec2 position, Vec2 dir, double force, double pps, Color color, double fade = -1, double spread = 0, double speedspread = 0)
    {
        Position = position;
        Dir = dir;
        Force = force;
        PPS = pps;
        Color = color;
        Fade = fade;
        Spread = spread;
        SpeedSpread = speedspread;
        Gravity = Vec2.Zero;
    }

    public void Render()
    {
        Particles.Render();
    }
    public void Update(double dt)
    {
        double st = Program.Random.NextDouble(-Spread / 2, Spread / 2);
        double sst = Program.Random.NextDouble(-SpeedSpread / 2, SpeedSpread / 2) + 1;
        T += dt;
        if (T > 1 / PPS && Produce)
        {
            Particles.Add(new Particle(Position, Vec2.Rotate(Dir, st) * Force * sst, 1, Color, Gravity, Fade));
            T = 0;
        }
        Particles.Refresh();
        Particles.Update(dt);
    }

}