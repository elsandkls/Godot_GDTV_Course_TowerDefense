using Godot;
using System;

public partial class EnemyCannonBarrel : Sprite2D
{
    private string ClassName = "EnemyCannonBarrel";
    BulletBrain BulletBrain;
    Scenes scenes;   
    private int debug = 0;
    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        SetProcess(true);
        BulletBrain = (BulletBrain)GetNode("/root/Main/Bullets/BulletBrain");
    }
    public override void _Input(InputEvent _inputEvent)
    { 
        string func_name = "_Input";
        if (_inputEvent.IsActionPressed("LeftMouseEvent"))
        {
            if (debug == 1)
            {
                GD.Print(ClassName + "[" + func_name + "] Left Mouse Clicked"); 
                GD.Print(ClassName + "[" + func_name + "] GlobalPosition " + GlobalPosition);
                GD.Print(ClassName + "[" + func_name + "] GetGlobalMousePosition " + GetGlobalMousePosition());
            }
            BulletBrain.SpawnEnemyBullet(GlobalPosition, GetGlobalMousePosition());
        }
    }   
    
    public override void _Process(double delta)
    {
        string func_name = "_Process";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        LookAt(GetGlobalMousePosition());
    }   
}


