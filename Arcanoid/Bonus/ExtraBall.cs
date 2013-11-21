using System;
using VitPro;
using VitPro.Engine;

[Serializable]
class ExtraBall : Bonus
{
    public ExtraBall()
    {
        Tex = new Texture("Data/img/ExtraBall.png");
    }
    public override void Get()
    {
        base.Get();
        Ball b = new Ball();
        World.Current.Balls.Add(b);
    }
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