using System;
using VitPro;
using VitPro.Engine;

class Button : IRenderable
{
    public Vec2 Position;
    public Vec2 Size;
    public Color color = new Color(0.4, 0.4, 0.4);

    void MouseOver()
    {
        if (Hit())
            color = new Color(0.7, 0.7, 0.7);
        else color = new Color(0.4, 0.4, 0.4);
    }

    public bool Hit()
    {
        Vec2 pos = Mouse.Position;
        pos += new Vec2(0, -240);
        pos = new Vec2(pos.X, -pos.Y);
        pos -= new Vec2(320, 0);
        pos /= 2;
        if (pos.X < Position.X + Size.X && pos.X > Position.X && pos.Y < Position.Y + Size.Y && pos.Y > Position.Y)
            return true;
        return false;
    }
    
    public string text;

    public void Render()
    {
        MouseOver();
        Draw.Rect(Position, Position + Size, color);
        Draw.Save();
        Draw.Translate(Position);
        Draw.Scale(20);
        Program.font.Render(text);
        Draw.Load();
    }
}