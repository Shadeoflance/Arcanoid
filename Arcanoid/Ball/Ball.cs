using VitPro;
using VitPro.Engine;
using System;

partial class Ball : IUpdateable, IRenderable
{
    public int Streak = 1;
    Color Color;
    public int Damage = 3;

    public Ball() { Color = new Color(0, 1, 0, Fade); }

    public void Update(double dt)
    {
        UpdatePhysics(dt);
    }

    public void Render()
    {
        Color = new Color(0, 1, 0, Fade);
        Draw.Circle(Position, Size.X, Color);
    }
}