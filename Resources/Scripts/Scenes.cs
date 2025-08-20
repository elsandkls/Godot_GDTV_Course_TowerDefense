using Godot;
using System;

public partial class Scenes : Node
{
    public PackedScene _scenePlayerBullet = (PackedScene)GD.Load("res://Resources/Scenes/PlayerBullet.tscn");
    public PackedScene _scenePlayerExplosion = (PackedScene)GD.Load("res://Resources/Scenes/PlayerExplosion.tscn");
    public PackedScene _sceneEnemyBullet = (PackedScene)GD.Load("res://Resources/Scenes/EnemyBullet.tscn");
    public PackedScene _sceneEnemyExplosion = (PackedScene)GD.Load("res://Resources/Scenes/EnemyExplosion.tscn");
}
