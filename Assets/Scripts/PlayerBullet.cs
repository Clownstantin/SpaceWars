using UnityEngine;

namespace SpaceWars
{
    public class PlayerBullet : Bullet
    {
        private void Update() => Move(Vector2.up);
    }
}