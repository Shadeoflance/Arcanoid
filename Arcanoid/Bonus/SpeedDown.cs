using System;
using VitPro.Engine;
using VitPro;

class SpeedDown : Bonus
{
    public override void Get()
    {
        base.Get();
        Ball.Speed = Math.Max(Ball.Speed - 75, 100);
    }

    Texture Tex = new Texture("Data/img/SpeedDown.png");
    public override void Render()
    {
        base.Render();
        Draw.Save();
        Draw.Translate(Position - Size);
        Draw.Scale(Size.X * 2, Size.Y * 2);
        Tex.Render();
        Draw.Load();
    }
}