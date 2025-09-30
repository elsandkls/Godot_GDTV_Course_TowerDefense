using Godot;
using System;

public partial class GroundArea : Area2D
{

    private string ClassName = "GroundArea";
    private int debug = 0;
    BulletBrain BulletBrain;
    ExplosionBrain ExplosionBrain; 
    PlayerBullet PlayerBullet; 
    PlayerBulletArea2D PlayerBulletArea2D; 
    EnemyBullet EnemyBullet;
    EnemyBulletArea2D EnemyBulletArea2D;
    PlayerCannon PlayerCannon;
    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        SetProcess(true);        
        BulletBrain = (BulletBrain)GetNode("/root/Main/Bullets/BulletBrain");
        ExplosionBrain = (ExplosionBrain)GetNode("/root/Main/Explosions/ExplosionBrain");    
        PlayerCannon = (PlayerCannon)GetNode("/root/Main/Foreground/PlayerCannon");
    }
    public void _on_ground_area_entered(Area2D Bullet)
    {
        string func_name = "_on_ground_area_entered"; 
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "] Hit by " + Bullet.Name);
        }

        if (Bullet.Name == "PlayerBullet")
        { 
            // disable collisions
            var BulletArea2dPath = Bullet.GetPath();
            PlayerBulletArea2D = (PlayerBulletArea2D)GetNode(BulletArea2dPath);
            PlayerBulletArea2D.DisableCollisionBeforeDestruction();

            // get parent node, and self delete 
            var BulletArea2DParent = Bullet.GetParent();
            var BulletParentPath = BulletArea2DParent.GetPath();
            PlayerBullet = (PlayerBullet)GetNode(BulletParentPath);
            ExplosionBrain.SpawnPlayerExplosion(PlayerBullet.GlobalPosition);
            PlayerBullet.SelfDelete();  
        }
        
        if (Bullet.Name == "EnemyBullet")
        { 
            // disable collisions
            var BulletArea2dPath = Bullet.GetPath();
            EnemyBulletArea2D = (EnemyBulletArea2D)GetNode(BulletArea2dPath);
            EnemyBulletArea2D.DisableCollisionBeforeDestruction();

            // get parent node, and self delete 
            var BulletArea2DParent = Bullet.GetParent();
            var BulletParentPath = BulletArea2DParent.GetPath();
            EnemyBullet = (EnemyBullet)GetNode(BulletParentPath);
            ExplosionBrain.SpawnEnemyExplosion(EnemyBullet.GlobalPosition);
            EnemyBullet.SelfDelete(); 
        } 
    }
}
