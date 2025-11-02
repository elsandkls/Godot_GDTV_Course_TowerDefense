using Godot;
using System;
using System.Collections.Generic;

public partial class StopperBrain : Node
{
    private string ClassName = "StopperBrain";
    Hud Hud;
    Scenes scenes;
    private int debug = 0;
    private List<Node> spawnedStopperNodes = new();
    
    public int PlayerStopperCount = 0;
    public int EnemyStopperCount = 0;
    public override void _Ready()
    {
        string func_name = "_Ready";
        scenes = GetNode<Scenes>("/root/Main/Scenes");
        Hud = (Hud)GetNode("/root/Main/Hud/Hud");
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

        var stopper = scenes._scenePlayerStopper.Instantiate<PlayerStopper>();
        GetNode<Node>("/root/Main/BulletStopper").AddChild(stopper);
        spawnedStopperNodes.Add(stopper);
        stopper.GlobalPosition = SpawnPosition;
        // Set Bullet Animation  ;
        stopper.PlayAnimationForMe();
        PlayerStopperCount++;
        Hud.HudUpdate_Stoppers(PlayerStopperCount);
    }

    // public PackedScene _sceneEnemyStopper = (PackedScene)GD.Load("res://Resources/Scenes/EnemyStopper.tscn");
    public void SpawnEnemyStopper(Vector2 SpawnPosition)
    {
        string func_name = "SpawnEnemyStopper";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] SpawnPosition " + SpawnPosition);
        }

        var stopper = scenes._sceneEnemyStopper.Instantiate<EnemyStopper>();
        GetNode<Node>("/root/Main/BulletStopper").AddChild(stopper);
        spawnedStopperNodes.Add(stopper);
        stopper.GlobalPosition = SpawnPosition;
        // Set Bullet Animation  ;
        stopper.PlayAnimationForMe();
        EnemyStopperCount++;
    }

    public void CleanUpStoppers()
    {
        foreach (var node in spawnedStopperNodes)
        {
            if (IsInstanceValid(node))
                node.QueueFree();
        }
        spawnedStopperNodes.Clear();
        PlayerStopperCount = 0;
        EnemyStopperCount = 0;
    }
    
    public void CleanUpSingleStopper(Node NodeDeleted)
    {
        foreach (var node in spawnedStopperNodes.ToArray())
        {
            if (node == NodeDeleted)
            {
                spawnedStopperNodes.Remove(NodeDeleted);
            }
        } 
    }
}
