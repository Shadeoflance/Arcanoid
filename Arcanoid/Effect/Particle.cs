using System;
using VitPro;
using VitPro.Engine;

class Particle : IRenderable, IUpdateable
{
    public Vec2 Position;
    public Vec2 Vel;
    public Vec2 Gravitation = new Vec2(0, -10000);
    double _Size;
    public double Size
    {
        get { return (Fade == -1) ? _Size : _Size * (1 - T / Fade); }
        set { _Size = value; }
    }
    public double g;
    public Color Color;
    double Fade;
    double T = 0;

    public Particle(Vec2 pos, Vec2 vel, double size, Color color, Vec2 gravity, double fade = -1, double g = 100)
    {
        Gravitation = gravity;
        Position = pos;
        Vel = vel;
        Size = size;
        Color = color;
        this.g = g;
        Fade = fade;
    }

    public void Update(double dt)
    {
        T += dt;
        dt *= 2;
        Vel += Vec2.Clamp(Gravitation - Vel, g * dt);
        Position += Vel * dt;
        if (Position.X + Size > World.Current.ScreenR)
            Vel = new Vec2(-Math.Abs(Vel.X), Vel.Y);
        if (Position.Y - Size < World.Current.ScreenB)
            Vel = new Vec2(Vel.X, Math.Abs(Vel.Y));
        if (Position.X - Size < World.Current.ScreenL)
            Vel = new Vec2(Math.Abs(Vel.X), Vel.Y);
        if (Position.Y + Size > World.Current.ScreenT)
            Vel = new Vec2(Vel.X, -Math.Abs(Vel.Y));
        if (Fade != -1 && Fade > T)
            Color = new Color(Color.R, Color.G, Color.B, 1 - T / Fade);
    }

    public void Render()
    {
        Draw.Circle(Position, Size, Color);
    }
}