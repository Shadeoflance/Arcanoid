using VitPro;
using VitPro.Engine;
using System;

class ShootLine : Effect
{
    Vec2 Dir = new Vec2(0, 1);
    public override void Render()
    {
        base.Render();
        if (World.Current.ShootBall == null)
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
    public override void Update(double dt)
    {
        base.Update(dt);
        if (World.Current.ShootBall == null)
            return;
        Position = World.Current.ShootBall.Position;
        if (Key.A.Pressed() && Dir.Arg < Math.PI * 3 / 4)
            Dir = Vec2.Rotate(Dir, Math.PI * dt * 2);
        if (Key.D.Pressed() && Dir.Arg > Math.PI / 4)
            Dir = Vec2.Rotate(Dir, -Math.PI * dt * 2);
        World.Current.ShootBall.Vel = Dir.Unit;
    }
}