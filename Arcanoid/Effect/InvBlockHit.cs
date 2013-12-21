using VitPro;
using VitPro.Engine;
using System;

class InvBlockHit : Effect
{
    public InvBlockHit(Block b)
    {
        LifeTime = 1;
        Position = b.Position;
        bonus = b.bonus;
    }
    bool bonus;
    public override void Render()
    {
        double Fade = 0.75 + Time / 2;
        Draw.Rect(Position + Block.Size, Position - Block.Size, new Color(0, 0, 0, 1 - Fade));
        if (bonus)
            Draw.Circle(Position + Block.Size - new Vec2(2, 2), 1, Color.White);
    }
}