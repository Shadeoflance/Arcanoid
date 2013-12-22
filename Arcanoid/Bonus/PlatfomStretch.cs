using System;
using VitPro.Engine;
using VitPro;

class PlatformStretch : Bonus
{
    public override void Get()
    {
        base.Get();
        World.Current.Platform.AddWidth();
    }

    Texture Tex = new Texture("Data/img/PlatformStretch.png");
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