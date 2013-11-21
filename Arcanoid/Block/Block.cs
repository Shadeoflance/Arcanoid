using VitPro.Engine;
using VitPro;
using System;

[Serializable]
partial class Block : IRenderable
{
    public Bonus bonus;

    public void AddBonus()
    {
        bonus = Bonus.RandomBonus();
        World.Current.Effects.Add(new BonusBlock(this));
    }

    public virtual void Render()
    {
    }
}