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
        HP--;
        World.Current.Effects.Add(new InvBlockHit(this));
        if (HP == 0 && bonus)
        {
            Bonus b = Bonus.RandomBonus();
            b.Position = Position;
            World.Current.Bonuses.Add(b);
        }
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