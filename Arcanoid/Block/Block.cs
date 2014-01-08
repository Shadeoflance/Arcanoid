using VitPro.Engine;
using VitPro;
using System;

[Serializable]
partial class Block : IRenderable
{
    public bool bonus;
    public Color color;
    public Block(int hp)
    {
        HP = hp;
        double t = (1 - 0.01 * HP) * 4 / 5;
        color = new Color(t, t, t);
    }
    public virtual void Render()
    {
        Draw.Rect(Position - Size, Position + Size, color);
        if(bonus)
            Draw.Circle(Position + Size - new Vec2(2, 2), 1, Color.White);
    }
    public virtual Block Copy()
    {
        var b = new Block(HP);
        return b;
    }
}