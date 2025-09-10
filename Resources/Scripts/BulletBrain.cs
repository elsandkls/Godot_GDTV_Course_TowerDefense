using Godot;
using System;

public partial class BulletBrain : Node
{
    Scenes scenes;
    private int debug = 0;
    public int PlayerBulletCount = 0;
    public int EnemyBulletCount = 0;
    
    private string ClassName = "BulletBrain";
    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName +  "["+func_name+"]"); 
        }
        scenes = GetNode<Scenes>("/root/Main/Scenes");
    }

    // public PackedScene _scenePlayerBullet = (PackedScene)GD.Load("res://Resources/Scenes/PlayerBullet.tscn");
    public void SpawnPlayerBullet(Vector2 SpawnPosition, Vector2 TargetPosition)
    {
        string func_name = "SpawnPlayerBullet";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "] SpawnPosition " + SpawnPosition);
            GD.Print(ClassName + "[" + func_name + "] TargetPosition " + TargetPosition);
        }
        //Spawn potionsion 
        var playerBullet = scenes._scenePlayerBullet.Instantiate<PlayerBullet>();
        GetNode<Node>("/root/Main/Bullets").AddChild(playerBullet);
        playerBullet.GlobalPosition = SpawnPosition;
        // Look at target position
        playerBullet.LookAt(TargetPosition);
        // Set Bullet Animation  ;
        playerBullet.PlayAnimationForMe();
        PlayerBulletCount++;
    }


    //public PackedScene _sceneEnemyBullet = (PackedScene)GD.Load("res://Resources/Scenes/EnemyBullet.tscn");
    public void SpawnEnemyBullet(Vector2 SpawnPosition, Vector2 TargetPosition)
    {
        string func_name = "SpawnEnemyBullet";
        if (debug == 1)
        {
            GD.Print(ClassName + "["+func_name+"] SpawnPosition " + SpawnPosition);
            GD.Print(ClassName + "["+func_name+"] TargetPosition " + TargetPosition);
        }
        //Spawn potionsion 
        var enemyBullet = scenes._sceneEnemyBullet.Instantiate<EnemyBullet>();
        GetNode<Node>("/root/Main/Bullets").AddChild(enemyBullet);
        enemyBullet.GlobalPosition = SpawnPosition;
        // Look at target position
        enemyBullet.LookAt(TargetPosition);
        // Set Bullet Animation 
        enemyBullet.PlayAnimationForMe();
        EnemyBulletCount++;
    }

    // raining enemy bullets
    public void spawnEnemy()
    {
        string func_name = "spawnEnemy";
        if (debug == 1)
        {
            GD.Print(ClassName +  "["+func_name+"]"); 
        }
        float RandomNumber1 = GD.RandRange(0, 1000);
        int XCoord1 = (int)Convert.ToSingle(RandomNumber1);
        Vector2 SpawnPosition = new Vector2(XCoord1, -30);

        float RandomNumber2 = GD.RandRange(0, 1000);
        int XCoord2 = (int)Convert.ToSingle(RandomNumber2);
        Vector2 TargetPosition = new Vector2(XCoord2, 550);

        SpawnEnemyBullet(SpawnPosition, TargetPosition);
    }

} 
  