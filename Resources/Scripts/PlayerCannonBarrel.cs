using Godot;
using System;

public partial class PlayerCannonBarrel : Sprite2D
{
    BulletBrain BulletBrain;
    StopperBrain StopperBrain;
    Scenes scenes;
    private int debug = 0;
    
    private string ClassName = "PlayerCannonBarrel";

    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + " ["+func_name+"] Player Cannon Barrel");
        }
        SetProcess(true);
        BulletBrain = (BulletBrain)GetNode("/root/Main/Bullets/BulletBrain");
        StopperBrain = (StopperBrain)GetNode("/root/Main/BulletStopper/StopperBrain");
    }
    public override void _Input(InputEvent _inputEvent)
    {
        string func_name = "_Input";
        if (_inputEvent.IsActionPressed("FireCannonEvent"))
        {
            Vector2 PositionOfMouse = GetGlobalMousePosition();  
            Vector2 PositionOfCannon = GlobalPosition;
            if (debug == 1)
            {
                GD.Print(ClassName + " ["+func_name+"] Space Pressed");
                GD.Print(ClassName + " ["+func_name+"] GlobalPosition " + PositionOfCannon);
                GD.Print(ClassName + " ["+func_name+"] GetGlobalMousePosition " + PositionOfMouse);
                // to confirm that position is being set
            }  
            FireCannon(PositionOfCannon, PositionOfMouse);
        }
    }

    public override void _Process(double delta)
    {
        string func_name = "_Process";
        LookAt(GetGlobalMousePosition());
        if (debug == 2)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }
    }

    public void FireCannon(Vector2 CannonBarrelPosition, Vector2 SpawnPosition)
    {
        string func_name = "FireCannon";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] CannonBarrelPosition " + CannonBarrelPosition);
            GD.Print(ClassName + " [" + func_name + "] SpawnPosition " + SpawnPosition);
        }
        // for firing the bullet at the mouse position from the cannons position
        BulletBrain.SpawnPlayerBullet(CannonBarrelPosition, SpawnPosition);

        // for creating bullet stoppers at the mouses position
        StopperBrain.SpawnPlayerStopper(SpawnPosition);
    } 

}
