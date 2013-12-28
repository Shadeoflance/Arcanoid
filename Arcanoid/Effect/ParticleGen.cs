using VitPro;
using VitPro.Engine;
using System;

class ParticleGen : IRenderable, IUpdateable
{
    Group<Particle> Particles = new Group<Particle>();
    Vec2 Position;
    Vec2 Dir;
    double Force;
    double PPS;
    double T = 0;

    public ParticleGen()
    {
        Position = Vec2.Zero;
        Dir = new Vec2(1, 1).Unit;
        Force = 100;
        PPS = 6;
    }

    public void Render()
    {
        Particles.Render();
    }
    public void Update(double dt)
    {
        T += dt;
        if (T >= 1 / PPS)
        {
            Particles.Add(new Particle(Position, Dir * Force, 1, Color.Red, new Vec2(0, -1)));
            T = 0;
        }
        Particles.Refresh();
        Particles.Update(dt);
    }

}