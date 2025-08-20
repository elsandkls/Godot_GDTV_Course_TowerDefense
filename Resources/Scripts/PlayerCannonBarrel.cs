using Godot;
using System;

public partial class PlayerCannonBarrel : Sprite2D
{
    BulletBrain BulletBrain;    
    private int debug = 0;
    public override void _Ready()
    {
        if (debug == 1)
        {
            GD.Print("Player Cannon Barrel");
        }
        SetProcess(true);
        BulletBrain = (BulletBrain)GetNode("/root/Main/Bullets/BulletBrain");
    }
    public override void _Input(InputEvent _inputEvent)
    {
        if (_inputEvent.IsActionPressed("FireCannonEvent"))
        {
            if (debug == 1)
            {
                GD.Print("Player Cannon Space Pressed");
                GD.Print("PlayerCannonBarrel:_Input:GlobalPosition " + GlobalPosition);
                GD.Print("PlayerCannonBarrel:_Input:GetGlobalMousePosition " + GetGlobalMousePosition());
            }
            BulletBrain.SpawnPlayerBullet(GlobalPosition, GetGlobalMousePosition());
        }
    }


    public override void _Process(double delta)
    { 
        LookAt(GetGlobalMousePosition());        
    }   

}
