using Godot;
using System;

public partial class EnemyExplosion : Area2D
{
    
    private string ClassName = "EnemyExplosion";
    private int debug = 0; 

    private string ThisAnimation  = "";

    public AnimatedSprite2D ThisSprite { get; private set; } 

    // ready runs when the scene enteres the scene tree
    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        SetProcess(true);
     
        ThisSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
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
    }


    public void _on_timer_timeout()
    {
        string func_name = "_on_timer_timeout";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        SelfDelete();
    }

    public void SelfDelete()
    {
        string func_name = "SelfDelete";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        QueueFree();
    }


}
