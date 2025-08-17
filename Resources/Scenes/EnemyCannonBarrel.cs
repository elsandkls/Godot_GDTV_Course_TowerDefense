using Godot;
using System;

public partial class EnemySpriteBarrel : Sprite2D
{
    public override void _Ready()
    {
        GD.Print("Hello World Player Bullet");
        SetProcess(true);
    }
    public override void _Input(InputEvent _inputEvent)
    {
        GD.Print("Hello World Enemy Cannon Left Mouse Clicked");
        if (_inputEvent.IsActionPressed("LeftMouseEvent"))
        { }
    }   
}
