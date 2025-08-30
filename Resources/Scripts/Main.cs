using Godot;
using System;

public partial class Main : Node2D
{

    private string ClassName = "Main";
    private int debug = 0;
    public override void _Ready()
    {
        string func_name = "_Ready";
        base._Ready();
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }
    }
  
}
