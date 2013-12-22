using System;
using VitPro;
using VitPro.Engine;

partial class Block
{
    public static Vec2 Size = new Vec2(12, 4);
    public Vec2 Position
    {
        get
        {
            for (int i = 2; i < 13; i++)
                for (int j = 1; j < 14; j++)
                    if ((World.Current != null && World.Current.Blocks[i, j] == this) 
                        || (LevelCreator.Blocks != null && LevelCreator.Blocks[i, j] == this))
                        return new Vec2(i * 28 - 196, 120 - j * 10);
            return Vec2.Zero;
        }
    }
    public int HP = 1;
    public Box Box { get { return new Box(Position, Size); } }

    public Block(int hp)
    {
        HP = hp;
    }

    public virtual void Hit()
    {
        HP--;
        if (HP == 0)
        {
            Death();
            if (bonus)
            {
                Bonus b = Bonus.RandomBonus();
                b.Position = Position;
                World.Current.Bonuses.Add(b);
            }
        }
    }
    public virtual void Death()
    {
        World.Current.Effects.Add(new BlockDeath(this));
    }
}