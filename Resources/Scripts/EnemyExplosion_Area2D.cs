using Godot;
using System;

public partial class EnemyExplosion_Area2D : Area2D
{
    private string ClassName = "EnemyExplosion_Area2D";
    private int debug = 0; 
   public override void _Ready()
    {  
        string func_name = "_Ready";
        if (debug == 1)
        { 
            GD.Print(ClassName + " [" + func_name + "] ");
        } 
    }


    public void _on_timer_timeout()
    {
        string func_name = "_on_timer_timeout";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        SelfDelete();
    }

    public void SelfDelete()
    {
        string func_name = "SelfDelete";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        QueueFree();
    }

}
