using Godot;
using System;

public partial class Hud : Node2D
{
    private string ClassName = "Hud";

    public int ActiveHealth = 0;
    [Export] private int lose_health_min = 0;
    public int start_Health = 100;
    public int old_Health = 1;

    public int ActivePoints = 0;
    public int start_Points = 000;
    public int old_Points = 1;
    [Export] private int win_points_max = 100;
    [Export] private int lose_points_min = -100;

    public int start_Bullets= 000;
    public int old_Bullets = 1;

    public int start_Stoppers = 000;
    public int old_Stoppers = 1;

    private int debug = 1;
 
    Main Main;

    public override void _Ready()
    {
        Main = (Main)GetNode("/root/Main");
        string func_name = "_Ready";

        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HudUpdate_Health"); }
        HudUpdate_Health(start_Health);

        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HudUpdate_Points"); }
        HudUpdate_Points(start_Points);

        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HudUpdate_Bullets"); }
        HudUpdate_Bullets(start_Bullets);

        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HudUpdate_Stoppers"); }
        HudUpdate_Stoppers(start_Stoppers);
    }

    public void StartOver()
    {
        string func_name = "StartOver";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HudUpdate_Health"); }
        HudUpdate_Health(start_Health);

        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HudUpdate_Points"); }
        HudUpdate_Points(start_Points);

        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HudUpdate_Bullets"); }
        HudUpdate_Bullets(start_Bullets);

        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HudUpdate_Stoppers"); }
        HudUpdate_Stoppers(start_Stoppers);

    }
    



    public void HudUpdate_Health(int Health)
    {
        string func_name = "HudUpdate_Health";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] " + Health); }

        ActiveHealth = Health;
        if (Health != old_Health)
        {
            old_Health = Health;
            var HUD_Health = GetNodeOrNull<RichTextLabel>("TextRect_Hud/HBoxContainer/VBoxContainer2/HUD_Health");
            if (HUD_Health != null)
            {
                HUD_Health.Text = Health.ToString();
                if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HUD_Health [" + Health + "]"); }
            }
        }
        else
        {
            if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Health did not change." + Health); }
        }

        if (lose_health_min == ActiveHealth)
        {
            PlayerLose(true);
        }

    }
    public void HudUpdate_Points(int Points)
    {
        string func_name = "HudUpdate_Points";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] " + Points); }
        
        ActivePoints = Points;
        if (Points != old_Points)
        {
            old_Points = Points;
            var HUD_Points = GetNodeOrNull<RichTextLabel>("TextRect_Hud/HBoxContainer/VBoxContainer2/HUD_Points");
            if (HUD_Points != null)
            {
                HUD_Points.Text = Points.ToString();
                if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HUD_Points [" + Points + "]"); }
            }
        }
        else
        {
            if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Points did not change." + Points); }
        }

        if (ActivePoints <= lose_points_min)
        {
            PlayerLose(true);
        }

        if (ActivePoints >= win_points_max)
        {
            PlayerWin(true);
        }

    }
    public void HudUpdate_Bullets(int Bullets)
    { 
        string func_name = "HudUpdate_Bullets";
        if (debug == 1){GD.Print(ClassName + "[" + func_name + "] "+Bullets);}
        if (Bullets != old_Bullets)
        {
            old_Bullets = Bullets;
            var HUD_Bullets = GetNodeOrNull<RichTextLabel>("TextRect_Hud/HBoxContainer/VBoxContainer2/HUD_Bullets");
            if (HUD_Bullets != null)
            {
                HUD_Bullets.Text = Bullets.ToString();
                if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HUD_Bullets [" + Bullets + "]"); }
            }
        } 
        else
        {            
            if (debug == 1){GD.Print(ClassName + "[" + func_name + "] Points did not change." + Bullets);}
        }
    }
    public void HudUpdate_Stoppers(int Stoppers)
    {
        string func_name = "HudUpdate_Stoppers";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] " + Stoppers); }
        if (Stoppers != old_Stoppers)
        {
            old_Stoppers = Stoppers;
            var HUD_Stoppers = GetNodeOrNull<RichTextLabel>("TextRect_Hud/HBoxContainer/VBoxContainer2/HUD_Stoppers");
            if (HUD_Stoppers != null)
            {
                HUD_Stoppers.Text = Stoppers.ToString();
                if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] HUD_Stoppers [" + Stoppers + "]"); }
            }
        }
        else
        {
            if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Stoppers did not change." + Stoppers); }
        }
    }

    public void PlayerLose(bool Status)
    {
        string func_name = "PlayerLose";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Points:" + ActivePoints); }
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Health: " + ActiveHealth); }
        Main.MakeGameOver_visible(true);
    }

    public void PlayerWin(bool Status)
    {
        string func_name = "PlayerWin";
        if (debug == 1) { GD.Print(ClassName + "[" + func_name + "] Points:" + ActivePoints); }
        Main.MakeGameOver_visible(true);
        
    }

}
