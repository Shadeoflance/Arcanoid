using VitPro;
using VitPro.Engine;
using System;

class Lives : Effect
{
    public override void Render()
    {
        string text = "x" + World.Current.Lives.ToString();
        Draw.Save();
        Draw.Translate(new Vec2(World.Current.ScreenR - 21, World.Current.ScreenB - 2));
        Draw.Scale(20);
        Draw.Color(new Color(0.7, 0.7, 0.7));
        Program.font.Render(text);
        Draw.Load();
    }
}