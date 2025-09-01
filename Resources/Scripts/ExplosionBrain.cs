using Godot;
using System;

public partial class ExplosionBrain : Node
{
    Scenes scenes;
    private int debug = 0;

    private string ClassName = "ExplosionBrain";

    public override void _Ready()
    {
        string func_name = "_Ready";
        scenes = GetNode<Scenes>("/root/Main/Scenes");
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }
    }

    //public PackedScene _scenePlayerExplosion = (PackedScene)GD.Load("res://Resources/Scenes/PlayerExplosion.tscn");
    public void SpawnPlayerExplosion(Vector2 SpawnPosition)
    {
        string func_name = "SpawnPlayerExplosion";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "]  SpawnPosition " + SpawnPosition);
        }
        //Spawn potionsion 
        var explosion = scenes._scenePlayerExplosion.Instantiate<PlayerExplosion>();
        //GetNode<Node>("/root/Main/Explosions").AddChild(explosion);

        GetNode<Node>("/root/Main/Explosions").CallDeferred(Node.MethodName.AddChild, explosion);
        explosion.GlobalPosition = SpawnPosition;
        // Set Bullet Animation  ;
        explosion.PlayAnimationForMe();
    }

    // public PackedScene _sceneEnemyExplosion = (PackedScene)GD.Load("res://Resources/Scenes/EnemyExplosion.tscn");
    public void SpawnEnemyExplosion(Vector2 SpawnPosition)
    {
        string func_name = "SpawnEnemyExplosion";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "]  SpawnPosition " + SpawnPosition);
        }
        //Spawn potionsion 
        var explosion = scenes._sceneEnemyExplosion.Instantiate<EnemyExplosion>();
        GetNode<Node>("/root/Main/Explosions").CallDeferred(Node.MethodName.AddChild, explosion); 
        explosion.GlobalPosition = SpawnPosition;
        // Set Bullet Animation  ;
        explosion.PlayAnimationForMe();
    }
    
}
