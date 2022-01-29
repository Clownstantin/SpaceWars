using UnityEngine;

namespace SpaceWars
{
    public class GameSession : MonoBehaviour
    {
        private int _score;

        private void Awake() => SetUpSingleton();

        public int GetScore() => _score;

        public void AddToScore(int value) => _score += value;

        public void ResetGame() => Destroy(gameObject);

        private void SetUpSingleton()
        {
            int instanceCount = FindObjectsOfType(GetType()).Length;
            if (instanceCount > 1) Destroy(gameObject);
            else DontDestroyOnLoad(gameObject);
        }
    }
}