using VitPro.Engine;
using VitPro;
using System;

[Serializable]
partial class Block : IRenderable
{
    public bool bonus;
    public Texture hptex;
    public virtual void Render()
    {
        if (hptex == null)
        {
            hptex = Program.font.MakeTexture(HP.ToString());
        }
        double t = (1 - 0.01 * HP) * 4 / 5;
        Color color = new Color(t, t, t);
        Draw.Rect(Position - Size, Position + Size, color);
        if(bonus)
            Draw.Circle(Position + Size - new Vec2(2, 2), 1, Color.White);
        Draw.Save();
        Draw.Translate(Position);
        Draw.Scale(8);
        Draw.Color(0.6, 0.6, 1, 0.7);
        Draw.Scale((double)hptex.Width / (double)hptex.Height, 1);
        Draw.Align(0.5, 0.5);

        hptex.Render();
        Draw.Load();
    }
    public virtual Block Copy()
    {
        var b = new Block(HP);
        return b;
    }
}