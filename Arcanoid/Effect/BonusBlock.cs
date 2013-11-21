using VitPro;
using VitPro.Engine;
using System;

class BonusBlock : Effect
{
    Block Block;
    public BonusBlock(Block Block)
    {
        this.Block = Block;
    }

    public override void Render()
    {
        base.Render();
        Draw.Circle(Block.Position + Block.Size - new Vec2(2, 2), 1, Color.White); 
    }

    public override void Update(double dt)
    {
        base.Update(dt);
    }
}