using VitPro.Engine;
using VitPro;
using System;

[Serializable]
partial class Block : IRenderable
{
    public bool bonus;

    public virtual void Render()
    {
        double t = (1 - 0.01 * HP) * 4 / 5;
        Color color = new Color(t, t, t);
        Draw.Rect(Position - Size, Position + Size, color);
        if(bonus)
            Draw.Circle(Position + Size - new Vec2(2, 2), 1, Color.White);
        Draw.Save();
        new Camera(240).Apply();
        Draw.Translate(Position);
        Draw.Scale(8);
        Draw.Color(0.6, 1, 0.6, 0.5);
        Draw.Align(Program.font.Measure(HP.ToString()) / 2, 0.5);
        Program.font.Render(HP.ToString());
        Draw.Load();
    }
    public virtual Block Copy()
    {
        var b = new Block(HP);
        return b;
    }
}