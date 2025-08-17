using Godot;
using System;

public partial class Scenes : Node
{
    public PackedScene _scenePlayerBullet = (PackedScene)GD.Load("res://Resources/Scenes/PlayerBullet.tcsn");
    public PackedScene _scenePlayerExplosion = (PackedScene)GD.Load("res://Resources/Scenes/PlayerExplosion.tcsn");
    public PackedScene _sceneEnemyBullet = (PackedScene)GD.Load("res://Resources/Scenes/EnemyBullet.tcsn");
    public PackedScene _sceneEnemyExplosion = (PackedScene)GD.Load("res://Resources/Scenes/EnemyExplosion.tcsn");
}
