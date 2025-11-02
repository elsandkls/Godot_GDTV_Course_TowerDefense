using Godot;
using System;

public partial class VisualTimer : RichTextLabel
{
    public int debug = 0;
    public int minutes = 10;
    public int seconds = 0;
    public int timesup = 0;
    public int time = 0;
    public int time_period = 1;

    private string ClassName = "Timer";
    Scenes scenes;
    Hud Hud;
    RichTextLabel HudTimer;
    public override void _Ready()
    {
        string func_name = "_Ready";
        if (debug == 1)
        {
            GD.Print(ClassName + "[" + func_name + "]");
        }
        scenes = GetNode<Scenes>("/root/Main/Scenes");
        Hud = (Hud)GetNode("/root/Main/Hud/Hud");
        HudTimer = (RichTextLabel)GetNode("/root/Main/Hud/Hud/TextureRect/HBoxContainer/Timer");
    }

    // public PackedScene _scenePlayerBullet = (PackedScene)GD.Load("res://Resources/Scenes/PlayerBullet.tscn");
    public void update_timer()
    {
        if (timesup == 0)
        {
            if (seconds < 1)
            {
                minutes = minutes - 1;
                seconds = 59;
            }
            else
            {
                seconds = seconds - 1;
            }
        }
        else
        {
            seconds = seconds + 1;
        }

        HudTimer.Text = minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');

        if (seconds <= 0)
        {
            if (minutes <= 0)
            {
                play_alarm_bell();
                timesup = 1;
            }
            else
            {

            }

        }
        else
        {

        }
    }

    public void play_alarm_bell()
    {

        //	Player.stream = AlarmBell;
        //  Player.play()		

    }

    public void _Process(int delta)
    {
        time += delta;
        if (time > time_period)
        {
            update_timer();
            time = 0;
        }
        else
        {

        }
    }

}

 