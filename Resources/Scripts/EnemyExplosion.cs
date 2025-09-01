using Godot;
using System;

public partial class EnemyExplosion : Area2D
{
    
    private string ClassName = "EnemyExplosion";
    private int debug = 0; 
    private string AnimationName = "default";

    private string ThisAnimation = "";
    private int loops = 0;

    public AnimatedSprite2D ThisSprite { get; private set; } 

    // ready runs when the scene enteres the scene tree
    public override void _Ready()
    {
        loops++;
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] AnimationName [" + AnimationName + "]");
            GD.Print(ClassName + " [" + func_name + "] ThisAnimation [" + ThisAnimation + "]");
        }
        SetProcess(true);
        if (loops <= 1)
        {
            FindSpriteFrame();
        }
    }


    public void FindSpriteFrame()
    {
        string func_name = "FindSpriteFrame";
        if (ThisAnimation == "" || ThisAnimation == null)
        { 
            ThisSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
            if (ThisSprite?.SpriteFrames == null)
            {
                GD.PrintErr(ClassName + " [" + func_name + "] No SpriteFrames found on AnimatedSprite2D!");
                return;
            }
            else
            {
                foreach (var animName in ThisSprite.SpriteFrames.GetAnimationNames())
                {
                    if (debug == 1)
                    {
                        GD.Print(ClassName + " [" + func_name + "] ThisSprite.SpriteFrames.GetAnimationNames()[" + animName + "]");
                    }
                    ThisAnimation = animName;
                }
            }
        }
        else
        {
            if (debug == 1)
            {
                GD.Print(ClassName + " [" + func_name + "] ThisAnimation already set to [" + ThisAnimation + "]");
            }
        }
    }

    public void PlayAnimationForMe()
    {
        string func_name = "PlayAnimationForMe";
        if (ThisAnimation == "" || ThisAnimation == null)
        {
            FindSpriteFrame();
        }
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] Play [" + ThisAnimation + "]");
        }
        // Try playing your animation here
        ThisSprite.Play(ThisAnimation);
    }
    public void _on_animated_sprite_2d_animation_finished()
    {
        SelfDelete();
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
