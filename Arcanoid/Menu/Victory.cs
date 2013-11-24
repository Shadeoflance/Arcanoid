using VitPro;
using VitPro.Engine;
using System;

class Victory : State
{
    string toptext = "YOU ARE VICTORIOUS!";
    string bottext = "FINAL SCORE: ";
    static SystemFont font = new SystemFont("04b03", 50, FontStyle.Bold);
    Camera cam = new Camera(240);

    public Victory()
    {
        cam.Apply();
        font.Smooth = false;
    }

    public override void Render()
    {
        Draw.Clear(Color.White);
        Draw.Save();
        Draw.Translate(new Vec2(-100, 50));
        Draw.Scale(20);
        Draw.Color(new Color(0.7, 0.7, 0.7));
        font.Render(toptext);
        Draw.Load();
        Draw.Save();
        Draw.Translate(new Vec2(-150, 0));
        Draw.Color(new Color(0.7, 0.7, 0.7));
        Draw.Scale(20);
        font.Render(bottext + World.Current.Score.ToString());
        Draw.Load();
    }
}