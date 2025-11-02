using Godot;
using System;

public partial class EnemyStopper_Area2D : Area2D
{

    private string ClassName = "EnemyStopper_Area2D";
    private int debug = 0;
    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName +  "["+func_name+"] ");
        }
        SetProcess(true); 
    }
}
