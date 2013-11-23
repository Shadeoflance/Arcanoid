﻿using VitPro.Engine;
using VitPro;
using System;

class GameOver : State
{
    Button Replay = new Button();
    Button BackToMenu = new Button();

    Camera cam = new Camera(240);

    public GameOver()
    {
        Replay.text = "Replay";
        BackToMenu.text = "BackToMenu";
        Replay.Position = new Vec2(-75, 50);
        Replay.Size = new Vec2(150, 22);
        BackToMenu.Position = new Vec2(-75, 0);
        BackToMenu.Size = new Vec2(150, 22);
    }

    public override void MouseDown(MouseButton button, Vec2 pos)
    {
        if (button != MouseButton.Left)
            return;
        if (Replay.Hit(pos))
            App.NextState = new Game();
        if (BackToMenu.Hit(pos))
            App.NextState = new Menu();
    }

    public override void Render()
    {
        Draw.Clear(Color.White);
        Replay.Render();
        BackToMenu.Render();
    }
}