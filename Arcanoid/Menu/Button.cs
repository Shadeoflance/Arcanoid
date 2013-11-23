using System;
using VitPro;
using VitPro.Engine;

class Button : IRenderable
{
    public Vec2 Position;
    public Vec2 Size;

    public Button()
    {
        font.Smooth = false;
    }

    public bool Hit(Vec2 pos)
    {
        pos -= new Vec2(320, 240);
        pos /= 2;
        if (pos.X < Position.X + Size.X && pos.X > Position.X && pos.Y < Position.Y + Size.Y && pos.Y > Position.Y)
            return true;
        return false;
    }
    static SystemFont font = new SystemFont("Impact", 50, FontStyle.Bold);
    public string text;
    public void Render()
    {
        Draw.Rect(Position, Position + Size, new Color(0.4, 0.4, 0.4));
        Draw.Save();
        Draw.Translate(Position);
        Draw.Scale(20);
        font.Render(text);
        Draw.Load();
    }
}