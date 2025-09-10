using Godot;
using System;

public partial class PlayerCannonBarrel : Sprite2D
{
    BulletBrain BulletBrain;
    StopperBrain StopperBrain;
    PlayerCannon PlayerCannon;
    Scenes scenes;
    private int debug = 0;

    private string ClassName = "PlayerCannonBarrel";

    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] Player Cannon Barrel");
        }
        SetProcess(true);
        BulletBrain = (BulletBrain)GetNode("/root/Main/Bullets/BulletBrain");
        StopperBrain = (StopperBrain)GetNode("/root/Main/BulletStopper/StopperBrain");
        PlayerCannon = (PlayerCannon)GetNode("/root/Main/Foreground/PlayerCannon");
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
                GD.Print(ClassName + " [" + func_name + "] Space Pressed");
                GD.Print(ClassName + " [" + func_name + "] GlobalPosition " + PositionOfCannon);
                GD.Print(ClassName + " [" + func_name + "] GetGlobalMousePosition " + PositionOfMouse);
                // to confirm that position is being set
            }
            FireCannon(PositionOfCannon, PositionOfMouse);
        }
        if (_inputEvent.IsActionPressed("RightMouseEvent"))
        {
            Vector2 PositionOfMouse = GetGlobalMousePosition(); 
            if (debug == 1)
            {
                GD.Print(ClassName + " [" + func_name + "] Right Mouse Button Even"); 
                GD.Print(ClassName + " [" + func_name + "] GetGlobalMousePosition " + PositionOfMouse);
                // to confirm that position is being set
            } 
            PlaceStopper(PositionOfMouse); 
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
            GD.Print(ClassName + " [" + func_name + "] PlayerCannon.canShoot " + PlayerCannon.canShoot);       
        }
        // for firing the bullet at the mouse position from the cannons position
        if (PlayerCannon.canShoot == true)
        {
            if (BulletBrain.PlayerBulletCount > 5)
            {
                PlayerCannon.canShoot = false;
            } 
            BulletBrain.SpawnPlayerBullet(CannonBarrelPosition, SpawnPosition); 
        } 
    } 
    public void PlaceStopper( Vector2 SpawnPosition )
    {
        string func_name = "PlaceStopper";
        if (debug == 1)
        { 
            GD.Print(ClassName + " [" + func_name + "] SpawnPosition " + SpawnPosition);
        }
        // for creating bullet stoppers at the mouses position
        if (PlayerCannon.canBlock == true)
        {
            if (StopperBrain.PlayerStopperCount > 5)
            {
                PlayerCannon.canBlock = false;
            }
            StopperBrain.SpawnPlayerStopper(SpawnPosition);
        }
    } 

}
