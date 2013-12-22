using System;
using VitPro;
using VitPro.Engine;

class LevelCreator : State
{
    public static Block[,] Blocks = new Block[15, 15];
    Camera cam = new Camera(240);

    public LevelCreator()
    {
        Blocks = GUtil.Load<Block[,]>("./Data/levels/lvl1.dat");
    }

    Block Current = new Block(1);
    int HP = 1;
    

    public override void MouseDown(MouseButton button, Vec2 pos)
    {
        pos = Mouse.Position;
        pos += new Vec2(0, -240);
        pos -= new Vec2(320, 0);
        pos /= 2;

        int i = (int)Math.Floor((pos.X + 210) / 28), j = -(int)Math.Floor((pos.Y - 115) / 10);
        if (i > 13 || j > 13 || i < 1 || j < 1)
            return;
        if (button == MouseButton.Middle)
        {
            if (Blocks[i, j] == null)
                return;
            Blocks[i, j].bonus = true;
            return;
        }
        if (button == MouseButton.Right)
        {
            Blocks[i, j] = null;
            return;
        }
        if (button == MouseButton.Left)
        {
            Blocks[i, j] = Current.Copy();
        }
    }

    int CurrentLevel = 1;
    public override void KeyDown(Key key)
    {
        if (key == Key.S)
        {
            CurrentLevel++;
            GUtil.Dump(Blocks, "./Data/levels/lvl" + (CurrentLevel - 1).ToString() + ".dat");
            Blocks = GUtil.Load<Block[,]>("./Data/levels/lvl" + CurrentLevel.ToString() + ".dat");
            //StateManager.NextState = new Menu();
        }
        if (key == Key.Number1)
            Current = new InvBlock(HP);
        if (key == Key.Number2)
            Current = new SolidBlock();
        if (key == Key.Number3)
            Current = new Block(HP);
        if (key == Key.Space)
        {
            HP = (HP) % 3 + 1;
            if (Current.GetType() != typeof(SolidBlock))
                Current.HP = HP;
        }
    }

    public override void Render()
    {
        cam.Apply();
        Draw.Clear(Color.White);
        for (int i = 2; i < 13; i++)
            for (int j = 1; j < 14; j++)
                if (Blocks[i, j] != null)
                {
                    if (Blocks[i, j].GetType() == typeof(InvBlock))
                    {
                        Draw.Rect(new Vec2(i * 28 - 208, 116 - j * 10), new Vec2(i * 28 - 184, 124 - j * 10), new Color(0, 0.8, 0.8));
                        if (Blocks[i, j].bonus)
                            Draw.Circle(Blocks[i, j].Position + Block.Size - new Vec2(2, 2), 1, Color.White);
                    }
                    else Blocks[i, j].Render();
                }
                else Draw.Rect(new Vec2(i * 28 - 208, 116 - j * 10), new Vec2(i * 28 - 184, 124 - j * 10), new Color(1, 0.8, 0.8));
        Draw.Save();
        new Camera(10).Apply();
        Draw.Color(Color.Black);
        Draw.Translate(new Vec2(5, -5));
        Program.font.Render(HP.ToString());
        Draw.Translate(new Vec2(-7, 0));
        Draw.Scale(0.8);
        Program.font.Render(Current.ToString());
        Draw.Load();
    }
}