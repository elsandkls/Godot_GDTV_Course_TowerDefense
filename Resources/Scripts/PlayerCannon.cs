using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class PlayerCannon : Sprite2D
{  
    public double LastKnownPosition = 0.0;
        
    Vector2 PositionInFG = new Vector2(0, 0);
    Vector2 ScaleAsVec2 = new Vector2(0, 0);
    private int debug = 0;
 
    public override void _Ready()
    { 
        GD.Print("Player Cannon");
        SetProcess(true); 
    }   
    // process runs every frame.
    public override void _Process(double delta)
    {  
        Vector2 PositionInFG = GlobalPosition;      
        Vector2 ScaleAsVec2 = Scale;
        if (debug == 1)
        {
            GD.Print("Player Cannon: Position " + GlobalPosition);
            GD.Print("Player Cannon: Scale " + Scale);
            GD.Print("Player Cannon: LastKnownPosition " + LastKnownPosition);
            GD.Print("Player Cannon: PositionInFG.Y " + PositionInFG.Y);
        }
            
        if (LastKnownPosition != PositionInFG.Y)
            {
                if (PositionInFG.Y < (double)850.0)
                {
                    ScaleAsVec2 = new Vector2(0.5f, 0.5f);
                    Scale = ScaleAsVec2;
                    GD.Print("0.5 Scale at Y coordinate: " + PositionInFG.Y);
                    LastKnownPosition = PositionInFG.Y;
                }
                if (PositionInFG.Y > (double)850.0 && PositionInFG.Y <= (double)950)
                {
                    ScaleAsVec2 = new Vector2(0.75f, 0.75f);
                    Scale = ScaleAsVec2;
                    GD.Print("0.75 Scale at Y coordinate: " + PositionInFG.Y);
                    LastKnownPosition = PositionInFG.Y;
                }
                if (PositionInFG.Y > (double)950)
                {
                    ScaleAsVec2 = new Vector2(1.0f, 1.0f);
                    Scale = ScaleAsVec2;
                    GD.Print("1.0 Scale at Y coordinate: " + PositionInFG.Y);
                    LastKnownPosition = PositionInFG.Y;
                }
            }
    }
}
