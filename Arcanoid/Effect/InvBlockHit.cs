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
        b.color = new Color(0, 0, 0, Fade);
    }
}