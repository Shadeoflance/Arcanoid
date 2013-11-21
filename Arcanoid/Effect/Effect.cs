using VitPro.Engine;
using VitPro;
using System;

partial class Effect : IRenderable, IUpdateable
{
    public Vec2 Position;
    public double LifeTime = -1, Time = 0;

    public virtual void Render()
    {

    }

    public virtual void Update(double dt)
    {
        Time += dt;
        if (LifeTime == -1)
            return;
        if (LifeTime < Time)
            World.Current.Effects.Remove(this);
    }
}