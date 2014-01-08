using System;
using VitPro.Engine;
using VitPro;

class LevelGenerator
{
    static Block[,] Blocks = new Block[15, 15];
    static bool[,] used = new bool[15, 15];
    static void bfs(int i, int j)
    {
        used[i, j] = true;
        if (i >= 3 && (!(Blocks[i - 1, j] is SolidBlock) || Blocks[i - 1, j] == null) && !used[i - 1, j])
            bfs(i - 1, j);
        if (i < 12 && (!(Blocks[i + 1, j] is SolidBlock) || Blocks[i + 1, j] == null) && !used[i + 1, j])
            bfs(i + 1, j);
        if (j >= 2 && (!(Blocks[i, j - 1] is SolidBlock) || Blocks[i, j - 1] == null) && !used[i, j - 1])
            bfs(i, j - 1);
        if (j < 13 && (!(Blocks[i, j + 1] is SolidBlock) || Blocks[i, j + 1] == null) && !used[i, j + 1])
            bfs(i, j + 1);
    }
    static bool check()
    {
        bool b = true;
        used = new bool[15, 15];
        for (int i = 2; i < 13 && b; i++)
            for (int j = 1; j < 14 && b; j++)
                if (!(b = Blocks[i, j] is SolidBlock))
                    bfs(i, j);
        for (int i = 2; i < 13; i++)
            for (int j = 1; j < 14; j++)
                if (used[i, j] == false && !(Blocks[i, j] is SolidBlock))
                    return false;
        return true;
    }
    public static Block[,] Generate(int difficulty)
    {
        difficulty += 3;
        Blocks = new Block[15, 15];
        for (int i = 2; i < 13; i++)
        {
            for (int j = 1; j < 14; j++)
            {
                Vec2 t = new Vec2((double)i, (double)j);
                double dist = Math.Min((t - new Vec2(2, 1)).Length, (t - new Vec2(12, 1)).Length);
                int hp = (int)Math.Min(Math.Floor(((double)difficulty * 8 * Program.Random.NextDouble(1, 1.3) - dist * 9)), 100);
                if (hp <= 0)
                    continue;
                bool special = false;
                if (difficulty > 7)
                    special = Program.Random.NextDouble() < Math.Min(0.02 * difficulty, 0.3);
                if (special)
                    if (Program.Random.Coin())
                        Blocks[i, j] = new InvBlock(hp);
                    else
                    {
                        Blocks[i, j] = new SolidBlock();
                        if (!check())
                            Blocks[i, j] = new InvBlock(hp);
                    }
                else Blocks[i, j] = new Block(hp);
                
            }
        }

        return Blocks;
    }
}