using VitPro;
using VitPro.Engine;
using System;

class ShootLine : Effect
{
    Vec2 Dir = new Vec2(0, 1);
    public override void Render()
    {
        base.Render();
        if (!World.Current.Shooting)
            return;
        Draw.Save();
        Draw.Translate(Position);
        Draw.Rotate(Dir.Arg);
        for (int i = 0; i < 5; i++)
        {
            Draw.Rect(new Vec2(Ball.Size.X, -1) + new Vec2(i * 10, 0),
                new Vec2(10, 1) + new Vec2(i * 10, 0),
                new Color(0.5 + i * 0.1, 0.5 + i * 0.1, 0.5 + i * 0.1));
        }
        Draw.Load();
    }
    bool Rot = false;
    public override void Update(double dt)
    {
        base.Update(dt);
        if (!World.Current.Shooting)
            return;
        Position = World.Current.PlatformBall.Position;
        if (Rot)
            Dir = Vec2.Rotate(Dir, -Math.PI * dt / 1.2);
        else Dir = Vec2.Rotate(Dir, Math.PI * dt / 1.2);

        if (Dir.Arg > Math.PI * 3 / 4)
        {
            Dir = new Vec2(Math.Cos(Math.PI * 3 / 4), Math.Sin(Math.PI * 3 / 4));
            Rot = true;
        }
        if (Dir.Arg < Math.PI / 4)
        {
            Dir = new Vec2(Math.Cos(Math.PI / 4), Math.Sin(Math.PI / 4));
            Rot = false;
        }
        World.Current.PlatformBall.Vel = Dir.Unit;
    }
}