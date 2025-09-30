using Godot;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;

public partial class PlayerStopperArea : Area2D
{
    private string ClassName = "PlayerStopperArea";
    Scenes scenes;
    StopperBrain StopperBrain;
    BulletBrain BulletBrain;
    ExplosionBrain ExplosionBrain;  
    EnemyBullet EnemyBullet;
    EnemyBulletArea2D EnemyBulletArea2D;
    EnemyExplosion EnemyExplosion; 
    PlayerCannon PlayerCannon;
    PlayerBullet PlayerBullet; 
    PlayerBulletArea2D PlayerBulletArea2D; 
    PlayerStopper PlayerStopper;
    PlayerExplosion PlayerExplosion; 


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
        StopperBrain = (StopperBrain)GetNode("/root/Main/BulletStopper/StopperBrain");   
        PlayerCannon = (PlayerCannon)GetNode("/root/Main/Foreground/PlayerCannon");      
    }

    public bool _regex_tester(string MyPattern, string ObjectName)
    {
        string func_name = "_regex_tester";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "] Pattern [" +MyPattern +"] Objects Name ["+ ObjectName + "]  ");
        }
        Regex regex = new Regex("^"+MyPattern+"(\\d*)$");
        Match match = regex.Match(ObjectName);
        if (match.Success)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }

    public void DeleteEnemyBullet(Area2D ObjectsCollided)
    { 
        var BulletArea2dPath = ObjectsCollided.GetPath();
        EnemyBulletArea2D = (EnemyBulletArea2D)GetNode(BulletArea2dPath);
        EnemyBulletArea2D.DisableCollisionBeforeDestruction();

        // get parent node, and self delete 
        var BulletArea2DParent = ObjectsCollided.GetParent();
        var BulletParentPath = BulletArea2DParent.GetPath();
        EnemyBullet = (EnemyBullet)GetNode(BulletParentPath);
        EnemyBullet.SelfDelete();
        BulletBrain.EnemyBulletCount--;
    }

    public void DeletePlayerBullet(Area2D ObjectsCollided)
    { 
        var BulletArea2dPath = ObjectsCollided.GetPath();
        PlayerBulletArea2D = (PlayerBulletArea2D)GetNode(BulletArea2dPath);
        PlayerBulletArea2D.DisableCollisionBeforeDestruction();

        // get parent node, and self delete 
        var BulletArea2DParent = ObjectsCollided.GetParent();
        var BulletParentPath = BulletArea2DParent.GetPath();
        PlayerBullet = (PlayerBullet)GetNode(BulletParentPath);
        PlayerBullet.SelfDelete(); 
    }

    public void DeletePlayerExplosion(Area2D ObjectsCollided)
    {
        var ExplosionArea2dParent = ObjectsCollided.GetParent();
        var ExplosionPath = ExplosionArea2dParent.GetPath();
        PlayerExplosion = (PlayerExplosion)GetNode(ExplosionPath);
        PlayerExplosion.SelfDelete();
    }
    public void DeleteEnemyExplosion(Area2D ObjectsCollided)
    {
        var ExplosionArea2dParent = ObjectsCollided.GetParent();
        var ExplosionPath = ExplosionArea2dParent.GetPath();
        EnemyExplosion = (EnemyExplosion)GetNode(ExplosionPath);
        EnemyExplosion.SelfDelete();
    }
    public void DeletePlayerStopper(Area2D ObjectsCollided)
    {
        var StopperArea2dParent = ObjectsCollided.GetParent();
        var StopperPath = StopperArea2dParent.GetPath(); 
        PlayerStopper = (PlayerStopper)GetNode(StopperPath);
        PlayerStopper.SelfDelete();
    }


    //public async Task _on_area_entered(Area2D Bullet)
    public void _on_area_entered(Area2D ObjectsCollided)
    {
        string func_name = "_on_area_entered";
        int triggered = 0;
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "] Hit by " + ObjectsCollided.Name);
        }

        bool RegexTest1 = _regex_tester("PlayerBullet", ObjectsCollided.Name);
        if (RegexTest1 == true)
        {
            if (debug == 1)
            {
                GD.Print(ClassName + "[" + func_name + "] Hit by  [PlayerBullet]" + ObjectsCollided.Name);
            }
            ExplosionBrain.SpawnPlayerExplosion(GlobalPosition); 
            DeletePlayerBullet(ObjectsCollided);
            triggered++;
        }

        bool RegexTest2 = _regex_tester("EnemyBullet", ObjectsCollided.Name);
        if (RegexTest2 == true)
        {
            if (debug == 1)
            {
                GD.Print(ClassName + "[" + func_name + "] Hit by  [EnemyBullet]" + ObjectsCollided.Name);
            }
            ExplosionBrain.SpawnEnemyExplosion(GlobalPosition); 
            DeleteEnemyBullet(ObjectsCollided);
            triggered++;
        }

        bool RegexTest3 = _regex_tester("PlayerExplosion", ObjectsCollided.Name);
        if (RegexTest3 == true)
        {
            if (debug == 1)
            {
                GD.Print(ClassName + "[" + func_name + "] Match by  [PlayerExplosion]" + ObjectsCollided.Name);
            } 
            DeletePlayerExplosion(ObjectsCollided);
            triggered++;
        }

        bool RegexTest4 = _regex_tester("EnemyExplosion", ObjectsCollided.Name);
        if (RegexTest4 == true)
        {
            if (debug == 1)
            {
                GD.Print(ClassName + "[" + func_name + "] Match by [EnemyExplosion]" + ObjectsCollided.Name);
            } 
            DeleteEnemyExplosion(ObjectsCollided);
            triggered++;
        }

        bool RegexTest5 = _regex_tester("@Area", ObjectsCollided.Name);
        if (RegexTest5 == true)
        {
            if (debug == 1)
            {
                GD.Print(ClassName + "[" + func_name + "] FAIL - Match by [Area]" + ObjectsCollided.Name);
            }
            var Area2dPath = ObjectsCollided.GetPath();
            var Area2DParent = ObjectsCollided.GetParent();
            bool RegexTest51 = _regex_tester("EnemyExplosion", Area2DParent.Name);
            if (RegexTest51 == true)
            {
                DeleteEnemyExplosion(ObjectsCollided);
            }
            bool RegexTest52 = _regex_tester("PlayerExplosion", Area2DParent.Name);
            if (RegexTest52 == true)
            {
                DeletePlayerExplosion(ObjectsCollided);
            }
            triggered++;
        }

        bool RegexTest6 = _regex_tester("PlayerStopper", ObjectsCollided.Name);
        if (RegexTest6 == true)
        {
            if (debug == 1)
            {
                GD.Print(ClassName + "[" + func_name + "] Match by [PlayerStopper]" + ObjectsCollided.Name);
            } 
            DeletePlayerStopper(ObjectsCollided);
            triggered++;
        }

        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "] Match by [triggered]" + triggered);
        } 
        if (triggered >= 1)
        { 
            var Stopper = GetParent();
            var StopperParentPath = Stopper.GetPath();
            PlayerStopper = (PlayerStopper)GetNode(StopperParentPath);
            DisableCollisionBeforeDestruction(); 
            PlayerStopper.SelfDelete();
        }
    }

    public void DisableCollisionBeforeDestruction()
    {
        string func_name = "DisableCollision";
 
        Monitoring = false;

        foreach (var ChildOfArea in GetChildren())
        {
            if (debug == 1)
            {
                GD.Print(ClassName + "[" + func_name + "] Triggered by: " + ChildOfArea.Name);
            }
            if (ChildOfArea is CollisionShape2D collisionShape)
            {
                collisionShape.SetDeferred("monitoring", true); 
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

 