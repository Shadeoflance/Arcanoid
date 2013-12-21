using VitPro;
using VitPro.Engine;
using System;

class Pause : State
{
    Texture Tex;
    public Pause(Texture tex)
    {
        Tex = tex;
    }
    public override void KeyDown(Key key)
    {
        base.KeyDown(key);
        if (key == Key.Escape)
            Close();
    }
    public override void Render()
    {
        base.Render();
        Draw.Save();
        Draw.Scale(2);
        Draw.Align(0.5, 0.5);
        Draw.Color(0.5, 0.5, 0.5);
        Tex.Render();
        Draw.Load();
    }
}