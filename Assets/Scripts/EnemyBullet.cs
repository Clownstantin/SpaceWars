using UnityEngine;

namespace SpaceWars
{
    public class EnemyBullet : Bullet
    {
        private void Update()
        {
            Move(Vector2.down);
            DestroyBulletOutScreen();
        }
    }
}