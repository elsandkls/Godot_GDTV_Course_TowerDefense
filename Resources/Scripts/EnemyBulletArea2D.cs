using Godot;
using System;

public partial class EnemyBulletArea2D : Area2D
{
    private string ClassName = "EnemyBulletArea2D";
    private int debug = 0;

    public CollisionShape2D ThisColision { get; private set; }
    public Area2D ThisArea { get; private set; }

    public void DisableCollisionBeforeDestruction()
    {
        string func_name = "DisableCollisionBeforeDestruction";
        ThisArea = GetNode<Area2D>(".");
        foreach (var ChildOfArea in ThisArea.GetChildren())
        {
            if (debug == 1)
            {
                GD.Print(ClassName + " [" + func_name + "]  Triggered by: " + ChildOfArea.Name);
            }
            if (ChildOfArea is CollisionShape2D collisionShape)
            {
                //collisionShape.Disabled = true;
                collisionShape.SetDeferred("monitoring", true);
                collisionShape.SetDeferred("disabled", true);
            }
        } 
    }
}
