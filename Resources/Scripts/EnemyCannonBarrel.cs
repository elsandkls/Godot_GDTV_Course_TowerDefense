using Godot;
using System;

public partial class EnemyCannonBarrel : Sprite2D
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
        if (_inputEvent.IsActionPressed("LeftMouseEvent"))
        {
            if (debug == 1)
            {
                GD.Print("Enemy Cannon Left Mouse Clicked");
                GD.Print(" Player Cannon Pressed Left Mouse Button");
                GD.Print("EnemyCannonBarrel:_Input:GlobalPosition " + GlobalPosition);
                GD.Print("EnemyCannonBarrel:_Input:GetGlobalMousePosition " + GetGlobalMousePosition());
            }
            BulletBrain.SpawnEnemyBullet(GlobalPosition, GetGlobalMousePosition());
        }
    }   
    
    public override void _Process(double delta)
    {
        LookAt(GetGlobalMousePosition());
    }   
}


