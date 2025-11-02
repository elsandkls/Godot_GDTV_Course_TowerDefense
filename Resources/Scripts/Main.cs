using Godot;
using System;

public partial class Main : Node2D
{

    private string ClassName = "Main";
    private int debug = 0;

    public bool GameOver = false;

    public bool RestartGame = false;

    BoxContainer GameOverHud;
    BulletBrain BulletBrain;
    ExplosionBrain ExplosionBrain;
    StopperBrain StopperBrain;    
    Hud Hud;

    public override void _Ready()
    {
        string func_name = "_Ready";
        base._Ready();
        if (debug == 1)
        {
            GD.Print(ClassName + " [" + func_name + "] ");
        }

        Hud = (Hud)GetNode("/root/Main/Hud/Hud");
        GameOverHud = (BoxContainer)GetNode("/root/Main/GameOverHud");
        BulletBrain = (BulletBrain)GetNode("/root/Main/Bullets/BulletBrain");
        ExplosionBrain = (ExplosionBrain)GetNode("/root/Main/Explosions/ExplosionBrain"); 
        StopperBrain = (StopperBrain)GetNode("/root/Main/BulletStopper/StopperBrain");  
        MakeGameOver_visible(false);
    }

    public void _on_exit_button_pressed()
    {
        GetTree().Quit();
    }

    public void _on_start_over_button_pressed()
    {
        Hud.StartOver();
        BulletBrain.CleanUpBullets();
        ExplosionBrain.CleanUpExplosions();
        StopperBrain.CleanUpStoppers();
        MakeGameOver_visible(false);
    }

    public void MakeGameOver_visible(bool Status)
    {
        GameOverHud.Visible = Status;
    } 


}
