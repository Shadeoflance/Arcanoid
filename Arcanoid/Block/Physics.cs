using System;
using VitPro;
using VitPro.Engine;

partial class Block
{
    public static Vec2 Size = new Vec2(12, 4);
    public Vec2 Position;
    public int HP = 1;
    public Box Box { get { return new Box(Position, Size); } }

    public Block(int hp)
    {
        HP = hp;
    }

    public void Hit()
    {
        HP--;
        if (HP == 0 && bonus)
        {
            Bonus b = Bonus.RandomBonus();
            b.Position = Position;
            World.Current.Bonuses.Add(b);
        }
    }
}