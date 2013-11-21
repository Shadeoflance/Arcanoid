using VitPro;
using VitPro.Engine;
using System;

partial class Platform : IRenderable, IUpdateable
{
    public void Update(double dt)
    {
        UpdatePhysics(dt);
    }

    Texture TexLeft = new Texture("./Data/img/left.png");
    Texture TexRight = new Texture("./Data/img/right.png");
    Texture TexMiddle = new Texture("./Data/img/middle.png");
    double Side = 15, Height = 7, Middle = 12;

    public void Render()
    {
        Draw.Save();
        Draw.Translate(Position - Size);
        Draw.Scale(Side, Height);
        TexLeft.Render();
        Draw.Load();
        Draw.Save();
        Draw.Translate(Position + Size - new Vec2(Side, Height));
        Draw.Scale(Side, Height);
        TexRight.Render();
        Draw.Load();
        for (int i = 0; i < Width; i++)
        {
            Draw.Save();
            Draw.Translate(Position - Size + new Vec2(Side + i * Middle, 0));
            Draw.Scale(Middle, Height);
            TexMiddle.Render();
            Draw.Load();
        }
    }
}