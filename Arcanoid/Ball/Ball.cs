using VitPro;
using VitPro.Engine;
using System;

partial class Ball : IUpdateable, IRenderable
{
    public void Update(double dt)
    {
        UpdatePhysics(dt);
    }

    public void Render()
    {
        Draw.Circle(Position, Size.X, Color.Green);
    }
}