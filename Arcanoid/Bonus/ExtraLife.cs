using System;
using VitPro;
using VitPro.Engine;

class ExtraLife : Bonus
{
    public override void Get()
    {
        World.Current.Lives++;
    }

    Texture Tex = new Texture("Data/img/ExtraLife.png");
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