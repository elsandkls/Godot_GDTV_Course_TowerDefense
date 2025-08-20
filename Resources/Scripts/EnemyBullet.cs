using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class EnemyBullet : Node2D
{
    public int speed = -150;
    Vector2 velocity = new Vector2(0, 0);
    private int debug = 0;

    private string ThisAnimation  = "";

    public AnimatedSprite2D ThisSprite { get; private set; } 

    // ready runs when the scene enteres the scene tree
    public override void _Ready()
    {
        if (debug == 1)
        {
            GD.Print("Hello World Enemy Bullet");
        }
        SetProcess(true);
     
        ThisSprite = GetNode<AnimatedSprite2D>("EnemyBullet/AnimatedSprite2D");
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
        velocity = Vector2.Left.Rotated(Rotation) * speed * deltaF;
        Translate(velocity);
    }
}
