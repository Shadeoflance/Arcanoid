using VitPro;
using VitPro.Engine;
using System;

class BallDeath : Effect
{
    public BallDeath(Vec2 position)
    {
        double t = Program.Random.NextDouble(Math.PI / 4, Math.PI * 3 / 4);
        P = new ParticleGen(position, new Vec2(Math.Cos(t), Math.Sin(t)), 130, 35, Color.Green, 1.5, Math.PI / 6, 0.3);
        LifeTime = 1.5;
    }

    ParticleGen P;
    public override void Render()
    {
        base.Render();
        P.Render();
    }
    public override void Update(double dt)
    {
        base.Update(dt);
        P.Update(dt);
        P.Produce = Time < 0.5;
    }
}