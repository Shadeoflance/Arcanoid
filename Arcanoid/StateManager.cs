using VitPro;
using VitPro.Engine;
using System;

class MyManager : StateManager
{
    public MyManager(State a)
        : base(a)
    {
    }
    double t = 1;

    public override void Update(double dt)
    {
        if(t == 0)
            base.Update(dt);
        t -= 5 * dt;
        if (t < 0)
            t = 0;
    }

    public override void StateChanged()
    {
        base.StateChanged();
        t = 1;
        if (tex != null)
        {
            back = tex.Copy();
        }
    }

    public new void Close()
    {
        PreviousState = CurrentState;
        CurrentState.Close();
    }

    Texture tex = null, back = null;

    IState PreviousState;

    public void Push(State next, State previous)
    {
        base.PushState(next);
        PreviousState = previous;
    }

    void DefaultRender()
    {
        Draw.Save();
        Draw.Save();
        Draw.Scale(2 + t);
        Draw.Align(0.5, 0.5);
        tex.Render();
        Draw.Load();
        Draw.Scale(3 - t);
        Draw.Align(0.5, 0.5);
        if (back != null)
        {
            Draw.Color(1, 1, 1, t);
            back.Render();
        }
        Draw.Load();
    }

    void PauseRender()
    {
        Draw.Save();
        Draw.Scale(2);
        Draw.Align(0.5, 0.5);
        tex.Render();
        if (back != null)
        {
            Draw.Color(1, 1, 1, t);
            back.Render();
        }
        Draw.Load();
    }

    public override void Render()
    {
        if (tex == null || tex.Width != Draw.Width || tex.Height != Draw.Height)
            tex = new Texture(Draw.Width, Draw.Height);
        Draw.BeginTexture(tex);
        base.Render();
        Draw.EndTexture();
        tex.RemoveAlpha();

        if (PreviousState != null && (CurrentState.GetType() == typeof(Pause) || PreviousState.GetType() == typeof(Pause)))
        {
            PauseRender();
            return;
        }

        DefaultRender();
    }
}