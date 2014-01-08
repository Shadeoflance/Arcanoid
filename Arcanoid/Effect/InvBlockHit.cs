using VitPro;
using VitPro.Engine;
using System;

class InvBlockHit : Effect
{
    bool Passive;
    Block b;
    public InvBlockHit(Block b, bool passive = false)
    {
        LifeTime = 1;
        this.b = b;
        Position = b.Position;
        bonus = b.bonus;
        Passive = passive;
    }
    bool bonus;
    public override void Render()
    {
        double Fade;
        if (Passive)
            Fade = Math.Abs(Math.Sin(Time * Math.PI) / 3) / 2;
        else Fade = 1d / 3 - Time / 3;
        Draw.Rect(Position + Block.Size, Position - Block.Size, new Color(0, 0, 0, Fade));
        if (bonus)
            Draw.Circle(Position + Block.Size - new Vec2(2, 2), 1, Color.White);
        Draw.Save();
        Draw.Color(new Color(0, 0, 0, Fade));
        Draw.Translate(Position);
        Draw.Scale(8);
        Draw.Color(0.6, 0.6, 1, 0.7);
        Draw.Scale((double)b.hptex.Width / (double)b.hptex.Height, 1);
        Draw.Align(0.5, 0.5);

        b.hptex.Render();
        Draw.Load();
    }
}