﻿using System;
using VitPro.Engine;
using VitPro;

class SpeedUp : Bonus
{
    public SpeedUp()
        : base()
    {
        Duration = 20;
        Bad = true;
    }
    public override void Get()
    {
        base.Get();
        Ball.Speed += 75;
    }

    public override void Runout()
    {
        base.Runout();
        Ball.Speed -= 75;
    }

    Texture Tex = new Texture("Data/img/SpeedUp.png");
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