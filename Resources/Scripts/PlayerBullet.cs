using Godot;
using System;

public partial class PlayerBullet : Node2D
{
    public int speed = 150;
    Vector2 velocity = new Vector2(0, 0);
    private int debug = 0;
    public AnimatedSprite2D ThisSprite { get; private set; }
    private string ThisAnimation  = "";
     

    public override void _Ready()
    {
        if (debug == 1)
        {
            GD.Print("Player Bullet");
        }
        SetProcess(true);

        ThisSprite = GetNode<AnimatedSprite2D>("PlayerBullet/AnimatedSprite2D");
        foreach (var animName in ThisSprite.SpriteFrames.GetAnimationNames())
        {
            ThisAnimation = animName;
        }
    }

    public void PlayAnimationForMe() 
    { 
        // Try playing your animation here
        ThisSprite.Play(ThisAnimation);
    }
     
    // process runs every frame.
    public override void _Process(double delta)
    {
        float deltaF = (float)delta;
        velocity = Vector2.Right.Rotated(Rotation) * speed * deltaF;
        Translate(velocity);
    }
     
}
