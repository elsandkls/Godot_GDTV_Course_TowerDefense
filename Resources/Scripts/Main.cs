using Godot;
using System;

public partial class Main : Node2D
{

    private int debug = 0;
    public override void _Ready()
    {
        base._Ready();
        if (debug == 1)
        {
            GD.Print("Main");
        }
    }
  
}
