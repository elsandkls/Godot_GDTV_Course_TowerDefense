using Godot;
using System;
using System.Threading.Tasks;

public partial class PlayerStopperArea : Area2D
{
    
    private string ClassName = "PlayerStopperArea";
    Scenes scenes;
    BulletBrain BulletBrain;
    ExplosionBrain ExplosionBrain; 
    PlayerBullet PlayerBullet; 
    PlayerBulletArea2D PlayerBulletArea2D; 
    PlayerStopper PlayerStopper;
    EnemyBullet EnemyBullet;
    EnemyBulletArea2D EnemyBulletArea2D;
    private int debug = 1;
    private double DelayDelete = 2.0;

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
    }

    //public async Task _on_area_entered(Area2D Bullet)
    public void _on_area_entered(Area2D Bullet)
    { 
        string func_name = "_on_area_entered";
        int triggered = 0;
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "] Hit by " + Bullet.Name);
        }

        if (Bullet.Name == "PlayerBullet")
        {
            ExplosionBrain.SpawnPlayerExplosion(GlobalPosition);
            // disable collisions
            var BulletArea2dPath = Bullet.GetPath();
            PlayerBulletArea2D = (PlayerBulletArea2D)GetNode(BulletArea2dPath);
            PlayerBulletArea2D.DisableCollisionBeforeDestruction();

            // get parent node, and self delete 
            var BulletArea2DParent = Bullet.GetParent();
            var BulletParentPath = BulletArea2DParent.GetPath();
            PlayerBullet = (PlayerBullet)GetNode(BulletParentPath);
            PlayerBullet.SelfDelete();
            triggered++;
        }
        
        if (Bullet.Name == "EnemyBullet")
        {
            ExplosionBrain.SpawnEnemyExplosion(GlobalPosition);
            // disable collisions
            var BulletArea2dPath = Bullet.GetPath();
            EnemyBulletArea2D = (EnemyBulletArea2D)GetNode(BulletArea2dPath);
            EnemyBulletArea2D.DisableCollisionBeforeDestruction();

            // get parent node, and self delete 
            var BulletArea2DParent = Bullet.GetParent();
            var BulletParentPath = BulletArea2DParent.GetPath();
            EnemyBullet = (EnemyBullet)GetNode(BulletParentPath);
            EnemyBullet.SelfDelete();
            triggered++;
        }

        if (triggered > 0)
        {
            // delete stopper
            var Stopper = GetParent();
            var StopperParentPath = Stopper.GetPath();
            PlayerStopper = (PlayerStopper)GetNode(StopperParentPath);
            PlayerStopper.SelfDelete();
        }
    }

    public void DisableCollision(Area2D Bullet)
    {
        string func_name = "DisableCollision";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]Triggered once by: " + Bullet.Name);
        }
        Monitoring = false;

        foreach (var ChildOfArea in GetChildren())
        {
            if (ChildOfArea is CollisionShape2D collisionShape)
            {
                collisionShape.SetDeferred("disabled", true);
            }
        }
    }

    public void SelfDelete()
    {
        string func_name = "SelfDelete";
        if (debug == 1)
        {
            GD.Print(ClassName +  "["+func_name+"]"); 
        }
        QueueFree();
    }

}

 