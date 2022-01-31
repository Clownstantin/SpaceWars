using UnityEngine;

namespace SpaceWars
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private int _damage = 10;

        public int Damage => _damage;

        public void OnHit()
        {
            if (gameObject.layer == 8) gameObject.SetActive(false);
            else Destroy(gameObject);
        }
    }
}