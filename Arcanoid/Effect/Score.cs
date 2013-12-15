using System;
using VitPro;
using VitPro.Engine;

class Score : Effect
{

    public override void Render()
    {
        string text = "";
        for (int i = World.Current.Score.ToString().Length; i < 8; i++)
            text += "0";
        text += World.Current.Score.ToString();
        Draw.Save();
        Draw.Translate(new Vec2(World.Current.ScreenL - 2, World.Current.ScreenB - 2));
        Draw.Scale(20);
        Draw.Color(new Color(0.7, 0.7, 0.7));
        Program.font.Render(text);
        Draw.Load();
    }
}