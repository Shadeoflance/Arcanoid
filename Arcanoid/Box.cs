using System;
using VitPro;

class Box
{
    double Left, Right, Bottom, Top;
    public static Vec2 Side(int s)
    {
        switch (s)
        {
            case 0:
                return new Vec2(0, 1);
            case 1:
                return new Vec2(1, 0);
            case 2:
                return new Vec2(0, -1);
            case 3:
                return new Vec2(-1, 0);
        }
        return Vec2.Zero;
    }
    public Box(Vec2 Position, Vec2 Size)
    {
        Left = Position.X - Size.X;
        Right = Position.X + Size.X;
        Bottom = Position.Y - Size.Y;
        Top = Position.Y + Size.Y;
    }
    public bool CollideBool(Box a)
    {
        if (Left > a.Right || Right < a.Left || Top < a.Bottom || Bottom > a.Top)
            return false;
        return true;
    }
    public int Collide(Box a)
    {
        if (Left > a.Right || Right < a.Left || Top < a.Bottom || Bottom > a.Top)
            return -1;
        double
            R = Math.Abs(Right - a.Left),
            L = Math.Abs(Left - a.Right),
            T = Math.Abs(Top - a.Bottom),
            B = Math.Abs(Bottom - a.Top);
        if (T <= R && T <= B && T <= L)
            return 0;
        if (R <= B && R <= L && R <= T)
            return 1;
        if (B <= L && B <= T && B <= R)
            return 2;
        if (L <= T && L <= R && L <= B)
            return 3;
        return -1;
    }
}