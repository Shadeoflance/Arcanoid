using VitPro.Engine;
using VitPro;
using System;
using System.Collections.Generic;
using System.IO;

class HighScores : State
{
    Camera cam = new Camera(240);
    Button Back = new Button();

    List<Tuple<string, int>> HS = new List<Tuple<string, int>>();

    public HighScores()
    {
        Back.text = "BACK";
        Back.Position = new Vec2(-75, -100);
        Back.Size = new Vec2(150, 22);
        
        if(System.IO.File.Exists("./Data/HighScores.dat"))
            HS = GUtil.Load<List<Tuple<string, int>>>("./Data/HighScores.dat");
    }

    public override void MouseDown(MouseButton button, Vec2 pos)
    {
        if (button != MouseButton.Left)
            return;
        if (Back.Hit())
            StateManager.NextState = new Menu();
    }

    public override void Render()
    {
        cam.Apply();
        Draw.Clear(Color.White);
        Draw.Save();
        Draw.Translate(new Vec2(-130, 70));
        Draw.Scale(20);
        for (int i = 0; i < HS.Count; i++)
        {
            Draw.Save();
            Draw.Color(new Color(0.5, 0.5, 0.5));
            Program.font.Render(HS[i].Item1);
            Draw.Load();
            Draw.Translate(new Vec2(12, 0));
            Draw.Save();
            Draw.Color(new Color(0.5, 0.8, 0.5));
            Program.font.Render(HS[i].Item2.ToString());
            Draw.Load();
            Draw.Translate(new Vec2(-12, 0));
            Draw.Translate(new Vec2(0, -1));
        }
        Draw.Load();
        Back.Render();
    }
}