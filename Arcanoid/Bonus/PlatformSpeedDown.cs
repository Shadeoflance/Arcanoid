using System;
using VitPro.Engine;
using VitPro;

class PlatformSpeedDown : Bonus
{
    public PlatformSpeedDown() { Bad = true; }
    public override void Get()
    {
        base.Get();
        Platform.Speed = Math.Max(Platform.Speed - 75, 150);
    }

    Texture Tex = new Texture("Data/img/PlatformSpeedDown.png");
    public override void Render()
    {
        if (!Alive)
            return;
        base.Render();
        Draw.Save();
        Draw.Translate(Position - Size);
        Draw.Scale(Size.X * 2, Size.Y * 2);
        Tex.Render();
        Draw.Load();
    }
}