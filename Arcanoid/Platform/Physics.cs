using VitPro.Engine;
using System;
using VitPro;

partial class Platform
{
    public Vec2 Size { get { return new Vec2(Side + Width * Middle / 2, Height / 2); } }
    public Vec2 Position = Vec2.Zero;
    public Box Box { get { return new Box(Position, Size); } }

    public static double Speed = 300;

    int Width = 0;
    public void AddWidth()
    {
        Width++;
    }
    public void DecWidth()
    {
        Width--;
    }

    public void UpdatePhysics(double dt)
    {
        Vec2 vel = Vec2.Zero;
        if (Key.A.Pressed())
            vel += new Vec2(-1, 0);
        if (Key.D.Pressed())
            vel += new Vec2(1, 0);
        Position += vel * Speed * dt;
        if (Position.X - Size.X < World.Current.ScreenL)
            Position = new Vec2(World.Current.ScreenL + Size.X, Position.Y);
        if (Position.X + Size.X > World.Current.ScreenR)
            Position = new Vec2(World.Current.ScreenR - Size.X, Position.Y);
    }
}