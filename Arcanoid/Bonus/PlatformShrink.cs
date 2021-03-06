﻿using System;
using VitPro.Engine;
using VitPro;

class PlatformShrink : Bonus
{
    public PlatformShrink() { Bad = true; }
    public override void Get()
    {
        base.Get();
        World.Current.Platform.DecWidth();
    }

    Texture Tex = new Texture("Data/img/PlatformShrink.png");
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