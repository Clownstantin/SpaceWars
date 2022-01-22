using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 500;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DamageDealer dealer))
            DealDamage(dealer);
    }

    private void DealDamage(DamageDealer dealer)
    {
        _health -= dealer.Damage;
        if (_health <= 0)
            Destroy(gameObject);
    }
}
