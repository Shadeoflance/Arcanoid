using VitPro;
using VitPro.Engine;
using System;

[Serializable]
class SolidBlock : Block
{
    public SolidBlock()
        : base(1)
    { }

    public override void Hit(int damage) { }

    public override Block Copy()
    {
        var b = new SolidBlock();
        return b;
    }

    public override void Render()
    {
        Draw.Rect(Position + Size, Position - Size, new Color(0, 0, 0));
    }
}