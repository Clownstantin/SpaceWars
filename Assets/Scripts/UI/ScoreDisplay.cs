using TMPro;
using UnityEngine;

namespace SpaceWars
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreDisplay : MonoBehaviour
    {
        private TMP_Text _scoreText;
        private GameSession _gameSession;

        private void Start()
        {
            _scoreText = GetComponent<TMP_Text>();
            _gameSession = FindObjectOfType<GameSession>();
        }

        private void Update() => UpdateScore();

        private void UpdateScore()
        {
            if (_gameSession != null)
                _scoreText.text = _gameSession.GetScore().ToString();
        }
    }
}