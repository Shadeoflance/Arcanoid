using VitPro;
using VitPro.Engine;
using System;

partial class Ball
{
    public Vec2 Vel = new Vec2(1, 1).Unit;
    public Vec2 Position = Vec2.Zero;
    public static Vec2 Size = new Vec2(4, 4);
    public static double Speed = 200;
    public Box Box { get { return new Box(Position, Size); } }

    public void Collision(int s)
    {
        switch (s)
        {
            case 0:
                {
                    if (Vel.Y > 0)
                        Vel = new Vec2(Vel.X, -Vel.Y);
                    break;
                }
            case 1:
                {
                    if(Vel.X > 0)
                        Vel = new Vec2(-Vel.X, Vel.Y);
                    break;
                }
            case 2:
                {
                    if (Vel.Y < 0)
                        Vel = new Vec2(Vel.X, -Vel.Y);
                    break;
                }
            case 3:
                {
                    if (Vel.X < 0)
                        Vel = new Vec2(-Vel.X, Vel.Y);
                    break;
                }
        }
    }

    double AngRange = 0.7;

    public void PlatformCollision(double p)
    {
        //if (Math.Abs(p) <= 0.5)
        //{
        //    Vel = new Vec2(Vel.X, Math.Abs(Vel.Y));
        //    return;
        //}
        if (Math.Abs(p) > 1)
            p /= Math.Abs(p);
        Vel = new Vec2(AngRange * p, Math.Sin(Math.PI / 4)).Unit;
        Streak = 1;
    }

    public void UpdatePhysics(double dt)
    {
        Position += Vel * Speed * dt;
        if (Position.Y < World.Current.ScreenB)
            World.Current.Balls.Remove(this);
    }
}