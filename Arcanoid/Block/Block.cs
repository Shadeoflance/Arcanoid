using VitPro.Engine;
using VitPro;
using System;

[Serializable]
partial class Block : IRenderable
{
    public bool bonus;
    public Texture hptex;
    public Color color;
    public Block(int hp)
    {
        HP = hp;
        double t = (1 - 0.01 * HP) * 4 / 5;
        color = new Color(t, t, t);
        hptex = Program.font.MakeTexture(HP.ToString());
    }
    public virtual void Render()
    {
        Draw.Rect(Position - Size, Position + Size, color);
        if(bonus)
            Draw.Circle(Position + Size - new Vec2(2, 2), 1, Color.White);
        Draw.Save();
        Draw.Translate(Position);
        Draw.Scale(8);
        Draw.Color(0.5, 0.5, 1, color.A);
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