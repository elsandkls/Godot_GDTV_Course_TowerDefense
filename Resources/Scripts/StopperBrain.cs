using Godot;
using System;

public partial class StopperBrain : Node
{
    private string ClassName = "StopperBrain";
    Scenes scenes;
    private int debug = 0;
    public override void _Ready()
    {
        string func_name = "_Ready";
        scenes = GetNode<Scenes>("/root/Main/Scenes");
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }
    }

    //public PackedScene _scenePlayerStopper = (PackedScene)GD.Load("res://Resources/Scenes/PlayerStopper.tscn");
    public void SpawnPlayerStopper(Vector2 SpawnPosition)
    {
        string func_name = "SpawnPlayerStopper";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] SpawnPosition " + SpawnPosition);
        }
        //PlayerStopper stopper = scenes._scenePlayerStopper.Instantiate<PlayerStopper>();
        //GetNode<Node>("/root/Main/BulletStopper").AddChild(stopper);
        //stopper.GlobalPosition = SpawnPosition;

        var stopper = scenes._scenePlayerStopper.Instantiate<PlayerStopper>();
        GetNode<Node>("/root/Main/BulletStopper").AddChild(stopper);
        stopper.GlobalPosition = SpawnPosition;
        // Set Bullet Animation  ;
        stopper.PlayAnimationForMe();
    }

    // public PackedScene _sceneEnemyStopper = (PackedScene)GD.Load("res://Resources/Scenes/EnemyStopper.tscn");
    public void SpawnEnemyStopper(Vector2 SpawnPosition)
    {
        string func_name = "SpawnEnemyStopper";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] SpawnPosition " + SpawnPosition);
        }
        //EnemyStopper stopper = scenes._sceneEnemyStopper.Instantiate<EnemyStopper>();
        //GetNode<Node>("/root/Main/BulletStopper").AddChild(stopper);
        //stopper.GlobalPosition = SpawnPosition;

        var stopper = scenes._sceneEnemyStopper.Instantiate<EnemyStopper>();
        GetNode<Node>("/root/Main/BulletStopper").AddChild(stopper);
        stopper.GlobalPosition = SpawnPosition;
        // Set Bullet Animation  ;
        stopper.PlayAnimationForMe();

    }
     

}
