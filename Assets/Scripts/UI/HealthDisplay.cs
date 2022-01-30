using TMPro;
using UnityEngine;

namespace SpaceWars
{
    [RequireComponent(typeof(TMP_Text))]
    public class HealthDisplay : MonoBehaviour
    {
        private TMP_Text _healthTxt;
        private PlayerShip _player;

        private const string HealthOnDie = "0";

        private void Start()
        {
            _healthTxt = GetComponent<TMP_Text>();
            _player = FindObjectOfType<PlayerShip>();
        }

        private void Update() => UpdateHealth();

        private void UpdateHealth() => _healthTxt.text = _player != null ? _player.GetHealth().ToString() : HealthOnDie;
    }
}