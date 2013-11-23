using System;
using VitPro;
using VitPro.Engine;

class LevelCreator : State
{
    Block[,] Blocks = new Block[15, 15];
    double w = 12, h = 4;
    Camera cam = new Camera(240);

    public LevelCreator()
    {
        cam.Apply();
    }

    public override void MouseDown(MouseButton button, Vec2 pos)
    {
        pos = Mouse.Position;
        pos += new Vec2(0, -240);
        pos = new Vec2(pos.X, -pos.Y);
        pos -= new Vec2(320, 0);
        pos /= 2;

        int i = (int)Math.Floor((pos.X + 210) / 28), j = -(int)Math.Floor((pos.Y - 115) / 10);
        if (i > 13 || j > 13 || i < 1 || j < 1)
            return;
        Vec2 p = new Vec2(i * 28 - 196, 120 - j * 10);
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
        if (Blocks[i, j] == null)
        {
            Blocks[i, j] = new Block(1);
            Blocks[i, j].Position = p;
        }
        else if (Blocks[i, j].HP == 1)
        {
            Blocks[i, j] = new Block(2);
            Blocks[i, j].Position = p;
        }
        else if (Blocks[i, j].HP == 2)
        {
            Blocks[i, j] = new Block(3);
            Blocks[i, j].Position = p;
        }
        else if (Blocks[i, j].HP == 3)
            Blocks[i, j] = null;
    }

    public override void KeyDown(Key key)
    {
        if (key == Key.S)
        {
            GUtil.Dump(Blocks, "./temp.dat");
            App.NextState = new Menu();
        }
    }

    public override void Render()
    {
        Draw.Clear(Color.White);
        for (int i = 2; i < 13; i++)
            for (int j = 1; j < 14; j++)
                if (Blocks[i, j] != null)
                    Blocks[i, j].Render();
                else Draw.Rect(new Vec2(i * 28 - 208, 116 - j * 10), new Vec2(i * 28 - 184, 124 - j * 10), new Color(1, 0.8, 0.8));
    }
}