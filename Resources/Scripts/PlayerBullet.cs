using Godot;
using System;

public partial class PlayerBullet : Node2D
{
    private string ClassName = "PlayerBullet";
    public int speed = 150;
    Vector2 velocity = new Vector2(0, 0);
    private int debug =0;
    public AnimatedSprite2D ThisSprite { get; private set; } 
    private string ThisAnimation = "";


    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
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
        string func_name = "PlayAnimationForMe";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        // Try playing your animation here
        ThisSprite.Play(ThisAnimation);
    }

    // process runs every frame.
    public override void _Process(double delta)
    {
        string func_name = "_Process";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        float deltaF = (float)delta;
        velocity = Vector2.Right.Rotated(Rotation) * speed * deltaF;
        Translate(velocity);
    }

    public void _on_timer_timeout()
    {
        string func_name = "_on_timer_timeout";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        Boolean PositionTest = false;
        //Width = 1600 Height = 800
        Vector2 PositionInFG = GlobalPosition;
        if (PositionInFG.Y > (double)1920.0)
        {
            PositionTest = true;
        }
        if (PositionInFG.Y < (double)0.0)
        {
            PositionTest = true;
        }
        if (PositionInFG.X > (double)1080.0)
        {
            PositionTest = true;
        }
        if (PositionInFG.X < (double)0.0)
        {
            PositionTest = true;
        }
        if (PositionTest == true)
        {
            SelfDelete();
        }
    }

    public void SelfDelete()
    {
        string func_name = "SelfDelete";
        if (debug == 1)
        {
            GD.Print(ClassName +  "["+func_name+"]  Delete Player Bullet"); 
        }
        QueueFree();
    }

}
