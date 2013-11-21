using VitPro.Engine;
using VitPro;
using System;

[Serializable]
class Block3hp : Block
{
    public Block3hp()
    {
        HP = 3;
    }
    public override void Render()
    {
        base.Render();
        Color color = new Color(0.5, 0.5, 0.5);
        if (HP == 2)
            color = new Color(0.7, 0.7, 0.7);
        if (HP == 1)
            color = new Color(0.9, 0.9, 0.9);
        Draw.Rect(Position - Size, Position + Size, color);
    }
}