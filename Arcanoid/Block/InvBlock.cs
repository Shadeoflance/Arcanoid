using VitPro;
using VitPro.Engine;
using System;

[Serializable]
class InvBlock : Block
{
    public InvBlock(int hp)
        : base(hp)
    { }
    public override void Hit()
    {
        base.Hit();
        World.Current.Effects.Add(new InvBlockHit(this));
    }
    public override Block Copy()
    {
        var b = new InvBlock(HP);
        return b;
    }
    public override void Render()
    {

    }
}