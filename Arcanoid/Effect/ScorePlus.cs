using VitPro.Engine;
using VitPro;
using System;

class ScorePlus : Effect
{
    Ball b;
    int Streak;
    public ScorePlus(Ball b)
    {
        this.b = b;
        LifeTime = 1.2;
        Position = b.Position;
        double t = 10;
        Streak = b.Streak;
        switch(Program.Random.Next(4))
        {
            case 0:
                {
                    Position += new Vec2(0, t);
                    break;
                }
            case 1:
                {
                    Position += new Vec2(t, 0);
                    break;
                }
            case 2:
                {
                    Position += new Vec2(0, -t);
                    break;
                }
            case 3:
                {
                    Position += new Vec2(-t, 0);
                    break;
                }
        }
    }

    public override void Render()
    {
        base.Render();
        string text = "+" + Streak.ToString();
        int balls = World.Current.Balls.Count;
        string mult = "";
        if(balls > 1)
            mult = "x " + balls;
        Draw.Save();
        Draw.Translate(Position);
        Draw.Scale(10);
        Draw.Color(new Color(0.5 + Time / 3, 0.5 + Time / 3, 0.5 + Time / 3));
        Program.font.Render(text);
        Draw.Load();
        if (mult == "")
            return;
        Draw.Save();
        Draw.Translate(Position + new Vec2(18, 0));
        Draw.Scale(10);
        Draw.Color(new Color(0.2 + Time / 3, 0.5 + Time / 3, 0.2 + Time / 3));
        Program.font.Render(mult);
        Draw.Load();
    }

    public override void Update(double dt)
    {
        base.Update(dt);
        Position += new Vec2(0, dt * 10);
    }
}