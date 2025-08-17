using Godot;
using System;

public partial class PlayerCannonBarrel : Sprite2D
{
    public override void _Ready()
    {
        GD.Print("Hello World Player Cannon Barrel");
        SetProcess(true);
    }
    public override void _Input(InputEvent _inputEvent)
    {
        if (_inputEvent.IsActionPressed("FireCannonEvent"))
        { 
            GD.Print("Hello World Player Cannon Space Pressed");
        }
    }   

}
