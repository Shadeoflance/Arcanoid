using System;
using VitPro.Engine;
using VitPro;

class LevelGenerator
{
    public static Block[,] Generate(int difficulty)
    {
        Block[,] Blocks = new Block[15, 15];
        difficulty += 3;
        for (int i = 2; i < 13; i++)
        {
            for (int j = 1; j < 14; j++)
            {
                Vec2 t = new Vec2((double)i, (double)j);
                double dist = Math.Min((t - new Vec2(2, 1)).Length, (t - new Vec2(12, 1)).Length);
                int hp = (int)Math.Min(Math.Floor(((double)difficulty * 8 * Program.Random.NextDouble(1, 1.3) - dist * 9)), 100);
                if (hp <= 0)
                    continue;
                Blocks[i, j] = new Block(hp);
            }
        }

        return Blocks;
    }
}