using VitPro.Engine;
using VitPro;
using System;

[Serializable]
class Block1hp : Block
{

    public override void Render()
    {
        base.Render();
        Color color = new Color(0.9, 0.9, 0.9);
        Draw.Rect(Position - Size, Position + Size, color);
    }
}