using VitPro;
using VitPro.Engine;
using System;

class SolidBlock : Block
{
    public SolidBlock()
        : base(1)
    { }

    public override void Hit() { }

    public override void Render()
    {
        Draw.Rect(Position + Size, Position - Size, new Color(0, 0, 0));
    }
}