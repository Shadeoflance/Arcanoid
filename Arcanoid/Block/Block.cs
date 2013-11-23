using VitPro.Engine;
using VitPro;
using System;

[Serializable]
partial class Block : IRenderable
{
    public bool bonus;

    public void Render()
    {
        Color color = new Color(0.5, 0.5, 0.5);
        if (HP == 2)
            color = new Color(0.7, 0.7, 0.7);
        if (HP == 1)
            color = new Color(0.9, 0.9, 0.9);
        Draw.Rect(Position - Size, Position + Size, color);
        if(bonus)
            Draw.Circle(Position + Size - new Vec2(2, 2), 1, Color.White); 
    }
}