using UnityEngine;

namespace SpaceWars
{
    public class SpaceShip : MonoBehaviour
    {
        [SerializeField] private float _health = 1000;
        [SerializeField] private int _score = 0;
        [Header("VFX Settings")]
        [SerializeField] private GameObject _deathVFX;
        [SerializeField] private float _effectDuration = 1f;
        [Header("SFX Settings")]
        [SerializeField] private AudioClip _deathSFX;
        [SerializeField] [Range(0, 1)] private float _soundVolume = 0.5f;

        private GameSession _gameSession;

        private void Start() => _gameSession = FindObjectOfType<GameSession>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out DamageDealer damageDealer))
                DealDamage(damageDealer);
        }

        public float GetHealth() => _health;

        private void DealDamage(DamageDealer dealer)
        {
            _health -= dealer.Damage;
            dealer.OnHit();
            if (_health <= 0) Die();
        }

        protected virtual void Die()
        {
            if (gameObject.layer == 7) _gameSession.AddToScore(_score);

            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(_deathSFX, Camera.main.transform.position, _soundVolume);

            var deathEffect = Instantiate(_deathVFX, transform.position, transform.rotation);
            Destroy(deathEffect, _effectDuration);
        }
    }
}