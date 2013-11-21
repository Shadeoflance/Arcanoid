using System;
using VitPro;
using VitPro.Engine;

partial class Block
{
    public static Vec2 Size = new Vec2(15, 7);
    public Vec2 Position;
    public int HP = 1;
    public Box Box { get { return new Box(Position, Size); } }

    public void Hit()
    {
        HP--;
        if (HP == 0 && bonus != null)
        {
            bonus.Position = Position;
            World.Current.Bonuses.Add(bonus);
        }
    }
}