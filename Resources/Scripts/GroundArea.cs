using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class GroundArea : Area2D
{

    private string ClassName = "GroundArea";
    private int debug = 0;
    private int Points = 0; 

    private int HitPoint = 5; 

    BulletBrain BulletBrain;
    ExplosionBrain ExplosionBrain; 
    PlayerBullet PlayerBullet; 
    PlayerBulletArea2D PlayerBulletArea2D; 
    EnemyBullet EnemyBullet;
    EnemyBulletArea2D EnemyBulletArea2D;
    PlayerCannon PlayerCannon;
    Hud Hud;
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
        Hud = (Hud)GetNode("/root/Main/Hud/Hud"); 
    }
    public void _on_ground_area_entered(Area2D Bullet)
    {
        string func_name = "_on_ground_area_entered"; 
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "] Hit by " + Bullet.Name);
            GD.Print(ClassName + "[" + func_name + "] Player Points " + Hud.old_Points);
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
            BulletBrain.CleanUpSingleBullet(PlayerBullet);
            PlayerCannon.canShoot = true;      
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
            BulletBrain.CleanUpSingleBullet(EnemyBullet);
            Points = Hud.old_Points - HitPoint;            
            if (debug == 1)
            { 
                GD.Print(ClassName + "[" + func_name + "] Player Points Changed: " + Points);
            }
            Hud.HudUpdate_Points(Points); 
        } 
    }
}
