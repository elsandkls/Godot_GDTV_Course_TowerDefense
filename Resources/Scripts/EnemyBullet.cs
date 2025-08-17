using Godot;
using System;

public partial class EnemyBullet : Area2D
{
    public int speed = -150;
    Vector2 velocity = new Vector2(0, 0);

    // ready runs when the scene enteres the scene tree
    public override void _Ready()
    {
        GD.Print("Hello World Enemy Bullet");
        SetProcess(true);
    }

    // process runs every frame.
    public override void _Process(double delta)
    {
        float deltaF = (float)delta;
        velocity = Vector2.Left.Rotated(Rotation) * speed * deltaF;
        Translate(velocity);
    }
}
