using System;
using VitPro;
using VitPro.Engine;

[Serializable]
class ExtraBall : Bonus
{
    public override void Get()
    {
        base.Get();
        Ball b = new Ball();
        World.Current.PlatformBall = b;
    }

    Texture Tex = new Texture("Data/img/ExtraBall.png");
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