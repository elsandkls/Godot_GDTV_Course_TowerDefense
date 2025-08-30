using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class PlayerCannon : Sprite2D
{  
    private string ClassName = "PlayerCannon";
    public double LastKnownPosition = 0.0;
        
    Vector2 PositionInFG = new Vector2(0, 0);
    Vector2 ScaleAsVec2 = new Vector2(0, 0);
    private int debug = 0;
 
    public override void _Ready()
    { 
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }
        SetProcess(true); 
    }   
    // process runs every frame.
    public override void _Process(double delta)
    {  
        string func_name = "_Process";
        Vector2 PositionInFG = GlobalPosition;      
        Vector2 ScaleAsVec2 = Scale;
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] Position " + GlobalPosition);
            GD.Print(ClassName + " [" + func_name + "] Scale " + Scale);
            GD.Print(ClassName + " [" + func_name + "] LastKnownPosition " + LastKnownPosition);
            GD.Print(ClassName + " [" + func_name + "] PositionInFG.Y " + PositionInFG.Y);
        }
            
        if (LastKnownPosition != PositionInFG.Y)
            {
                if (PositionInFG.Y < (double)850.0)
                {
                    ScaleAsVec2 = new Vector2(0.5f, 0.5f);
                    Scale = ScaleAsVec2;
                    GD.Print(ClassName + " [" + func_name + "] 0.5 Scale at Y coordinate: " + PositionInFG.Y);
                    LastKnownPosition = PositionInFG.Y;
                }
                if (PositionInFG.Y > (double)850.0 && PositionInFG.Y <= (double)950)
                {
                    ScaleAsVec2 = new Vector2(0.75f, 0.75f);
                    Scale = ScaleAsVec2;
                   GD.Print(ClassName + " [" + func_name + "] 0.75 Scale at Y coordinate: " + PositionInFG.Y);
                    LastKnownPosition = PositionInFG.Y;
                }
                if (PositionInFG.Y > (double)950)
                {
                    ScaleAsVec2 = new Vector2(1.0f, 1.0f);
                    Scale = ScaleAsVec2;
                    GD.Print(ClassName + " [" + func_name + "] 1.0 Scale at Y coordinate: " + PositionInFG.Y);
                    LastKnownPosition = PositionInFG.Y;
                }
            }
    }
}
