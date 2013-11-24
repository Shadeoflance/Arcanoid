using System;
using VitPro;
using VitPro.Engine;

class Score : Effect
{
    static SystemFont font = new SystemFont("04b03", 50, FontStyle.Bold);

    public override void Render()
    {
        string text = "";
        for (int i = World.Current.Score.ToString().Length; i < 8; i++)
            text += "0";
        text += World.Current.Score.ToString();
        Draw.Save();
        Draw.Translate(new Vec2(World.Current.ScreenL, World.Current.ScreenB));
        font.Smooth = false;
        Draw.Scale(20);
        Draw.Color(new Color(0.7, 0.7, 0.7));
        font.Render(text);
        Draw.Load();
    }
}