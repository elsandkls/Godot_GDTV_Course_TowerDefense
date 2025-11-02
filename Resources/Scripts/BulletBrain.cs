using Godot;
using System;
using System.Collections.Generic;

public partial class BulletBrain : Node
{
    Scenes scenes;
    private int debug = 0;
    public int PlayerBulletCount = 0;
    public int MaxPlayerBullet = 5;
    public int EnemyBulletCount = 0;
    public int MaxEnemyBullets = 10;

    private List<Node> spawnedBulletNodes = new();
    
    private string ClassName = "BulletBrain";
    PlayerCannon PlayerCannon;
    EnemyCannon EnemyCannon;
    Hud Hud;
    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        scenes = GetNode<Scenes>("/root/Main/Scenes");
        PlayerCannon = (PlayerCannon)GetNode("/root/Main/Foreground/PlayerCannon");
        EnemyCannon = (EnemyCannon)GetNode("/root/Main/Foreground/EnemyCannon");
        Hud = (Hud)GetNode("/root/Main/Hud/Hud");
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
        spawnedBulletNodes.Add(playerBullet);

        playerBullet.GlobalPosition = SpawnPosition;
        // Look at target position
        playerBullet.LookAt(TargetPosition);
        // Set Bullet Animation  ;
        playerBullet.PlayAnimationForMe();
        PlayerBulletCount++;
        Hud.HudUpdate_Bullets( PlayerBulletCount );
        if (PlayerBulletCount >= MaxPlayerBullet)
        {
            PlayerCannon.canShoot = false;
        }          
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
        spawnedBulletNodes.Add(enemyBullet);

        enemyBullet.GlobalPosition = SpawnPosition;
        // Look at target position
        enemyBullet.LookAt(TargetPosition);
        // Set Bullet Animation 
        enemyBullet.PlayAnimationForMe();
        EnemyBulletCount++;
        if (EnemyBulletCount >= MaxEnemyBullets)
        {
            EnemyCannon.canShoot = false;
        } 
    }

    // raining enemy bullets
    public void spawnEnemy()
    {
        string func_name = "spawnEnemy";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        float RandomNumber1 = GD.RandRange(0, 1000);
        int XCoord1 = (int)Convert.ToSingle(RandomNumber1);
        Vector2 SpawnPosition = new Vector2(XCoord1, -30);

        float RandomNumber2 = GD.RandRange(0, 1000);
        int XCoord2 = (int)Convert.ToSingle(RandomNumber2);
        Vector2 TargetPosition = new Vector2(XCoord2, 550);

        SpawnEnemyBullet(SpawnPosition, TargetPosition);
    }


    public void CleanUpBullets()
    {
        foreach (var node in spawnedBulletNodes)
        {
            if (IsInstanceValid(node))
                node.QueueFree();
        }
        spawnedBulletNodes.Clear();
        PlayerBulletCount = 0;
        EnemyBulletCount = 0;
    }
    
    public void CleanUpSingleBullet(Node NodeDeleted)
    {
        foreach (var node in spawnedBulletNodes.ToArray())
        {
            if (node == NodeDeleted)
            {
                spawnedBulletNodes.Remove(NodeDeleted);
            }
        } 
    }   

} 
  