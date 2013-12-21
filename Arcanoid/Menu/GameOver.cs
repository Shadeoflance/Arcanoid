using VitPro.Engine;
using VitPro;
using System;
using System.Collections.Generic;
using System.IO;

class GameOver : State
{
    Button Replay = new Button();
    Button BackToMenu = new Button();
    Button HighScores = new Button();

    List<Tuple<string, int>> HS = new List<Tuple<string, int>>();

    string toptext = "YOUR SCORE IS: ";
    string bottext = "ENTER YOUR NAME:";
    string name = "";

    int score;

    Camera cam = new Camera(240);
    public GameOver(int score)
    {
        this.score = score;
        Replay.text = "REPLAY";
        BackToMenu.text = "BACK TO MENU";
        HighScores.text = "HIGH SCORES";
        Replay.Position = new Vec2(-150, -100);
        Replay.Size = new Vec2(90, 15);
        BackToMenu.Position = new Vec2(-50, -100);
        BackToMenu.Size = new Vec2(90, 15);
        HighScores.Position = new Vec2(50, -100);
        HighScores.Size = new Vec2(90, 15);
        if(System.IO.File.Exists("./Data/HighScores.dat"))
            HS = GUtil.Load < List<Tuple<string, int>>>("./Data/HighScores.dat");
        else GUtil.Dump(HS, "./Data/HighScores.dat");
    }

    public override void MouseDown(MouseButton button, Vec2 pos)
    {
        if (button != MouseButton.Left)
            return;
        if (Replay.Hit())
            StateManager.NextState = new Game(1);
        if (BackToMenu.Hit())
            StateManager.NextState = new Menu();
        if (HighScores.Hit())
            StateManager.NextState = new HighScores();
    }

    public override void KeyDown(Key key)
    {
        base.KeyDown(key);
        if (key == Key.Enter)
        {
            if (HS.Count == 0)
            {
                HS.Add(new Tuple<string, int>(name, score));
                GUtil.Dump(HS, "./Data/HighScores.dat");
                Program.Manager.NextState = new HighScores();
                return;
            }
            for (int i = 0; i <= HS.Count; i++)
            {
                if (i == HS.Count)
                {
                    if (name != "")
                    {
                        HS.Add(new Tuple<string, int>(name, score));
                        GUtil.Dump(HS, "./Data/HighScores.dat");
                        Program.Manager.NextState = new HighScores();
                        return;
                    }
                    else return;
                }
                if (score >= HS[i].Item2)
                    if (name != "")
                    {
                        HS.Insert(i, new Tuple<string, int>(name, score));
                        GUtil.Dump(HS, "./Data/HighScores.dat");
                        Program.Manager.NextState = new HighScores();
                        return;
                    }
            }
            return;
        }
        if (key == Key.BackSpace)
        {
            if (name.Length < 1)
                return;
            name = name.Remove(name.Length - 1);
            return;
        }
        if (name.Length < 3)
            name += key.ToString().ToUpper()[0];
        else
        {
            name = name[0].ToString() + name[1].ToString();
            name += key.ToString().ToUpper()[0];
        }
    }

    public override void Render()
    {
        cam.Apply();
        Draw.Clear(Color.White);
        Replay.Render();
        BackToMenu.Render();
        HighScores.Render();
        Draw.Save();
        Draw.Translate(new Vec2(-150, 90));
        Draw.Scale(20);
        Draw.Color(new Color(0.4, 0.4, 0.4));
        Program.font.Render(toptext);
        Draw.Save();
        Draw.Color(new Color(1, 2, 1));
        Draw.Translate(new Vec2(9, 0));
        Program.font.Render(score.ToString());
        Draw.Load();
        Draw.Translate(new Vec2(0, -2));
        Program.font.Render(bottext);
        Draw.Translate(new Vec2(9, 0));
        if(name != "")
            Program.font.Render(name);
        Draw.Load();
    }
}