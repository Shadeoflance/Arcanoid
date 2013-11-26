using VitPro;
using VitPro.Engine;
using System;

class Victory : State
{
    string toptext = "YOU ARE VICTORIOUS!";
    string bottext = "FINAL SCORE: ";
    Camera cam = new Camera(240);
    Button BackToMenu = new Button();

    public Victory()
    {
        cam.Apply();
        BackToMenu.text = "BACK TO MENU";
        BackToMenu.Position = new Vec2(-75, -100);
        BackToMenu.Size = new Vec2(150, 22);
    }
    public override void MouseDown(MouseButton button, Vec2 pos)
    {
        if (button != MouseButton.Left)
            return;
        if (BackToMenu.Hit())
            StateManager.NextState = new Menu();
    }
    public override void Render()
    {
        Draw.Clear(Color.White);
        Draw.Save();
        Draw.Translate(new Vec2(-100, 50));
        Draw.Scale(20);
        Draw.Color(new Color(0.7, 0.7, 0.7));
        Program.font.Render(toptext);
        Draw.Load();
        Draw.Save();
        Draw.Translate(new Vec2(-115, 0));
        Draw.Color(new Color(0.7, 0.7, 0.7));
        Draw.Scale(20);
        Program.font.Render(bottext + World.Current.Score.ToString());
        Draw.Load();
        BackToMenu.Render();
    }
}