using Godot;
using System;

public partial class PlayerExplosion : Area2D
{
    private int debug = 0;
    public override void _Ready()
    {
        if (debug == 1)
        {
            GD.Print(" Player Explosion");
        }
    }  
}
