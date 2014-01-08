using VitPro;
using VitPro.Engine;
using System;

[Serializable]
class InvBlock : Block
{
    public InvBlock(int hp)
        : base(hp)
    {
        color = new Color(0, 0, 0, 0);
    }
    public override void Hit(int damage)
    {
        base.Hit(damage);
        World.Current.Effects.Add(new InvBlockHit(this));
    }
    public override Block Copy()
    {
        var b = new InvBlock(HP);
        return b;
    }
    public override void Render()
    {
        base.Render();
    }
}