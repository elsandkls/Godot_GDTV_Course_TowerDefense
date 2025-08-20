using Godot;
using System;

public partial class EnemySpawnerTimer : Timer
{ 
    private BulletBrain _bulletBrain;

    public override void _Ready()
    {
        _bulletBrain = GetNode<BulletBrain>("/root/Main/Bullets/BulletBrain");

        // Connect the signal
        //Timeout += OnTimerTimeout;
    }

    //private void OnTimerTimeout()
    //{
     //   GD.Print("Timer finished!");
    //}

    private void _on_timeout()
    {
        GD.Print("Timer Ran!");
        // Call spawnEnemy() in BulletBrain
        _bulletBrain.spawnEnemy();
        
    }
}
