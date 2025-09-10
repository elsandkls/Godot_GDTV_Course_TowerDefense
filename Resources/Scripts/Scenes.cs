using Godot;
using System;

public partial class Scenes : Node
{
    private string ClassName = "Scenes"; 
    public PackedScene _scenePlayerBullet = (PackedScene)GD.Load("res://Resources/Scenes/PlayerBullet.tscn");
    public PackedScene _scenePlayerExplosion = (PackedScene)GD.Load("res://Resources/Scenes/PlayerExplosion.tscn");
    public PackedScene _sceneEnemyBullet = (PackedScene)GD.Load("res://Resources/Scenes/EnemyBullet.tscn");
    public PackedScene _sceneEnemyExplosion = (PackedScene)GD.Load("res://Resources/Scenes/EnemyExplosion.tscn");
    public PackedScene _scenePlayerStopper = (PackedScene)GD.Load("res://Resources/Scenes/PlayerStopper.tscn");
    public PackedScene _sceneEnemyStopper = (PackedScene)GD.Load("res://Resources/Scenes/EnemyStopper.tscn");
    public PackedScene _scenePlayerCannon = (PackedScene)GD.Load("res://Resources/Scenes/PlayerCannon.tscn");

}
