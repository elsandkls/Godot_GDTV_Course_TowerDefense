using Godot;
using System;

public partial class ExplosionBrain : Node
{
    Scenes scenes;
    private int debug = 0;
    public override void _Ready()
    {
        scenes = GetNode<Scenes>("/root/Main/Scenes");
    }
    
    //public PackedScene _scenePlayerExplosion = (PackedScene)GD.Load("res://Resources/Scenes/PlayerExplosion.tscn");
    public void SpawnPlayerExplosion(Vector2 SpawnPosition)
    {
        if (debug == 1)
        {
            GD.Print("SpawnPlayerExplosion:SpawnPosition " + SpawnPosition);
        }
        PlayerExplosion explosion = scenes._scenePlayerExplosion.Instantiate<PlayerExplosion>();
        GetNode<Node>("/root/Main/Explosion").AddChild(explosion);
        explosion.GlobalPosition = SpawnPosition;

        // Set Explosion Animation
        var explosionSprite = (AnimatedSprite2D)explosion.GetNode("AnimatedSprite2D");
        explosionSprite.Play("PlayerExplosion");
    }

    // public PackedScene _sceneEnemyExplosion = (PackedScene)GD.Load("res://Resources/Scenes/EnemyExplosion.tscn");
    public void SpawnEnemyExplosion(Vector2 SpawnPosition)
    {
        if (debug == 1)
        {
            GD.Print("SpawnEnemyExplosion:SpawnPosition " + SpawnPosition);
        }
        //var explosion = (explosion)scenes._sceneEnemyExplosion.Instance();
            EnemyExplosion explosion = scenes._sceneEnemyExplosion.Instantiate<EnemyExplosion>();
        GetNode<Node>("/root/Main/Explosion").AddChild(explosion);
        explosion.GlobalPosition = SpawnPosition;

        // Set Explosion Animation
        var explosionSprite = (AnimatedSprite2D)explosion.GetNode("AnimatedSprite2D");
        explosionSprite.Play("PlayerExplosion");

    }
}
