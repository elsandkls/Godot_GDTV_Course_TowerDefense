using Godot;
using System;

public partial class EnemySpawnerTimer : Timer
{ 
    private int debug = 0;
    private BulletBrain _bulletBrain;
    private string ClassName = "EnemySpawnerTimer";

    public override void _Ready()
    {
        string func_name = "_Ready";
        _bulletBrain = GetNode<BulletBrain>("/root/Main/Bullets/BulletBrain");
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }
    }
 
    private void _on_timeout()
    {
        string func_name = "_on_timeout";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] Timer Ran!");
        } 
        // Call spawnEnemy() in BulletBrain
        _bulletBrain.spawnEnemy();
        
    }
}
