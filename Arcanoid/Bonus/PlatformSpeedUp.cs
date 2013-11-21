using System;
using VitPro.Engine;
using VitPro;

class PlatformSpeedUp : Bonus
{
    public override void Get()
    {
        base.Get();
        Platform.Speed += 75;
    }

    Texture Tex = new Texture("Data/img/PlatformSpeedUp.png");
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