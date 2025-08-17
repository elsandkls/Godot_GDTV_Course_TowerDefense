using Godot;
using System;

public partial class PlayerBullet : Area2D
{
    public int speed = 150;
    Vector2 velocity = new Vector2(0, 0);

    public override void _Ready()
    {
        GD.Print("Hello World Player Bullet");
        SetProcess(true);
    }   
    // process runs every frame.
    public override void _Process(double delta)
    {
        float deltaF = (float)delta;
        velocity = Vector2.Right.Rotated(Rotation) * speed * deltaF;
        Translate(velocity);
    }
}
