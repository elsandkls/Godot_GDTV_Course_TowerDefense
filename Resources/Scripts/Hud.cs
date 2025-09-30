using Godot;
using System;

public partial class Hud : Node
{


    public override void _Ready()
    {
        HudUpdate();
    }

    public void HudUpdate()
    {  
        var HUD_Health = (RichTextLabel)GetNode("/root/Main/Hud/TextRect_Hud/HBoxContainer/VBoxContainer2/HUD_Health");
        HUD_Health.Text = "0000";
        var HUD_Points = (RichTextLabel)GetNode("/root/Main/Hud/TextRect_Hud/HBoxContainer/VBoxContainer2/HUD_Points");
        HUD_Points.Text = "0000";
        var HUD_Bullets = (RichTextLabel)GetNode("/root/Main/Hud/TextRect_Hud/HBoxContainer/VBoxContainer2/HUD_Bullets");
        HUD_Bullets.Text = "0000";
        var HUD_Stoppers = (RichTextLabel)GetNode("/root/Main/Hud/TextRect_Hud/HBoxContainer/VBoxContainer2/HUD_Stoppers");
        HUD_Stoppers.Text = "0000";
    }
}
 