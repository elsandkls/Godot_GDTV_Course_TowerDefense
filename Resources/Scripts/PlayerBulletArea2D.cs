using Godot;
using System;

public partial class PlayerBulletArea2D : Area2D
{
    private string ClassName = "PlayerBulletArea2D";
    private int debug = 0;

    public CollisionShape2D ThisColision { get; private set; }
    public Area2D ThisArea { get; private set; }

    public void DisableCollisionBeforeDestruction()
    {
        string func_name = "DisableCollisionBeforeDestruction";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }
        ThisArea = GetNode<Area2D>(".");
        foreach (var child in ThisArea.GetChildren())
        {
            if (child is CollisionShape2D collisionShape)
                //collisionShape.Disabled = true;
                collisionShape.SetDeferred("disabled", true);
        } 
    }
    
}
