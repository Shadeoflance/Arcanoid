using VitPro.Engine;
using VitPro;
using System;

class Menu : State
{
    Camera cam = new Camera(240);
    Button StartButton = new Button();
    public Menu()
    {
        StartButton.text = "START";
        StartButton.Position = new Vec2(-75, 50);
        StartButton.Size = new Vec2(150, 22);
        cam.Apply();
    }

    public override void MouseDown(MouseButton button, Vec2 pos)
    {
        if (button != MouseButton.Left)
            return;
        if (StartButton.Hit(pos))
            App.NextState = new Game();
    }

    public override void Render()
    {
        Draw.Clear(Color.White);
        StartButton.Render();
    }
}