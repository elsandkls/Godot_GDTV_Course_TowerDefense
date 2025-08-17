using Godot;
using System;

public partial class BulletBrain : Node
{
    Scenes scenes = new Scenes();


    public override void _Ready()
    {

    }

    public void SpawnPlayerBullet(Vector2 SpaawnPosition, Vector2 TargetPosition, string AnimationName)
    {
        var bullet = (bullet)scenes._scenePlayerBullet.Instance();
    }

    public void SpawnPlayerExplosion(Vector2 SpaawnPosition, string AnimationName)
    {
        var explosion = (explosion)scenes._scenePlayerExplosion.Instance();

    }
    

    public void SpawnEnemyBullet(Vector2 SpaawnPosition, Vector2 TargetPosition, string AnimationName)
    {
        var bullet = (bullet)scenes._sceneEnemyBullet.Instance();
    }

    public void SpawnEnemyExplosion(Vector2 SpaawnPosition, string AnimationName)
    {
        var explosion = (explosion)scenes._sceneEnemyExplosion.Instance();

    }
    
}
