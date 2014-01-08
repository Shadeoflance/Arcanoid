using VitPro;
using VitPro.Engine;
using System;

class BlockHP : Effect
{
    double t = 1;
    public BlockHP(Block b)
    {
        LifeTime = 1;
        tex = Program.font.MakeTexture(b.HP.ToString());
        Position = b.Position;
    }
    Texture tex;
    public override void Update(double dt)
    {
        base.Update(dt);
        t -= dt;
    }
    public override void Render()
    {
        Draw.Save();
        Draw.Translate(Position);
        Draw.Scale(8);
        Draw.Color(1, 1, 1, t);
        Draw.Scale((double)tex.Width / (double)tex.Height, 1);
        Draw.Align(0.5, 0.5);
        tex.Render();
        Draw.Load();
    }
}