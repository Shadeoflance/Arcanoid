using VitPro;
using VitPro.Engine;
using System;

class Victory : State
{
    string toptext = "YOU ARE VICTORIOUS!";
    string bottext = "FINAL SCORE: ";
    Button BackToMenu = new Button();
    int Score;
    double t = 0;
    Group<Effect> Effects = new Group<Effect>();

    public Victory(int score)
    {
        World.Current = new World();
        Score = score;
        BackToMenu.text = "CONTINUE";
        BackToMenu.Position = new Vec2(-75, -110);
        BackToMenu.Size = new Vec2(150, 22);
    }
    public override void MouseDown(MouseButton button, Vec2 pos)
    {
        if (button != MouseButton.Left)
            return;
        if (BackToMenu.Hit())
        {
            Texture tex = new Texture(Draw.Width, Draw.Height);
            Draw.BeginTexture(tex);
            Render();
            Draw.EndTexture();
            StateManager.NextState = new GameOver(Score, tex);
        }
    }
    public override void Update(double dt)
    {
        base.Update(dt);
        t += dt;
        if (t > 2)
        {
            t = 0;
            Effects.Add(new Firework(new Vec2(Program.Random.Next(-3, 3), Program.Random.Next(-1, 5))));
        }
        Effects.Refresh();
        Effects.Update(dt);
        foreach (var a in Effects)
            if (a.Time > 1.5)
                Effects.Remove(a);

    }
    public override void Render()
    {
        new Camera(10).Apply();
        Draw.Clear(Color.White);
        Draw.Save();
        Draw.Color(new Color(0.7, 0.7, 0.7));
        Draw.Save();
        Draw.Align(Program.font.Measure(toptext) / 2, 0.5);
        Draw.Translate(new Vec2(0, 3));
        Program.font.Render(toptext);
        Draw.Load();
        Draw.Align(Program.font.Measure(bottext + Score.ToString()) / 2, 0.5);
        Draw.Translate(new Vec2(0, -3));
        Program.font.Render(bottext + Score.ToString());
        Draw.Load();
        Effects.Render();
        BackToMenu.Render();
    }
}