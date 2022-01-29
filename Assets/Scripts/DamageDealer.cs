using UnityEngine;

namespace SpaceWars
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private int _damage = 10;

        public int Damage => _damage;

        public void OnHit() => Destroy(gameObject);
    }
}