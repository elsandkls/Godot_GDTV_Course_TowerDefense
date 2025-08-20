using Godot;
using System;

public partial class BulletBrain : Node
{
    Scenes scenes;
    private int debug = 0;
    public override void _Ready()
    {
        scenes = GetNode<Scenes>("/root/Main/Scenes");
    }

    // public PackedScene _scenePlayerBullet = (PackedScene)GD.Load("res://Resources/Scenes/PlayerBullet.tscn");
    public void SpawnPlayerBullet(Vector2 SpawnPosition, Vector2 TargetPosition)
    {
        if (debug == 1)
        {
            GD.Print("SpawnPlayerBullet:SpawnPosition " + SpawnPosition);
            GD.Print("SpawnPlayerBullet:TargetPosition " + TargetPosition);
        }
        //Spawn potionsion 
        var playerBullet = scenes._scenePlayerBullet.Instantiate<PlayerBullet>();
        GetNode<Node>("/root/Main/Bullets").AddChild(playerBullet);
        playerBullet.GlobalPosition = SpawnPosition;
        // Look at target position
        playerBullet.LookAt(TargetPosition);
        // Set Bullet Animation  ;
        playerBullet.PlayAnimationForMe();
    }


    //public PackedScene _sceneEnemyBullet = (PackedScene)GD.Load("res://Resources/Scenes/EnemyBullet.tscn");
    public void SpawnEnemyBullet(Vector2 SpawnPosition, Vector2 TargetPosition)
    {
        if (debug == 1)
        {
            GD.Print("SpawnEnemyBullet:SpawnPosition " + SpawnPosition);
            GD.Print("SpawnEnemyBullet:TargetPosition " + TargetPosition);
        }
        //Spawn potionsion 
        var enemyBullet = scenes._sceneEnemyBullet.Instantiate<EnemyBullet>();
        GetNode<Node>("/root/Main/Bullets").AddChild(enemyBullet);
        enemyBullet.GlobalPosition = SpawnPosition;
        // Look at target position
        enemyBullet.LookAt(TargetPosition);
        // Set Bullet Animation 
        enemyBullet.PlayAnimationForMe();
    }

    public void spawnEnemy()
    {
        float RandomNumber1 = GD.RandRange(0, 1000);
        int XCoord1 = (int)Convert.ToSingle(RandomNumber1);
        Vector2 SpawnPosition = new Vector2(XCoord1, -30);


        float RandomNumber2 = GD.RandRange(0, 1000);
        int XCoord2 = (int)Convert.ToSingle(RandomNumber2);
        Vector2 TargetPosition = new Vector2(XCoord2, 550);

        SpawnEnemyBullet(SpawnPosition, TargetPosition);
        
    }

} 
  