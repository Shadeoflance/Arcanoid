using System;
using VitPro;
using VitPro.Engine;

class ExtraLife : Bonus
{
    public ExtraLife() { Bad = false; }
    public override void Get()
    {
        base.Get();
        World.Current.Lives++;
    }

    Texture Tex = new Texture("Data/img/ExtraLife.png");
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