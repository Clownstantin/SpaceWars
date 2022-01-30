using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceWars
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private float _gameOverDelay = 1f;

        public void LoadStartMenu() => SceneManager.LoadScene(0);

        public void LoadGameScene()
        {
            SceneManager.LoadScene(1);

            var gameSession = FindObjectOfType<GameSession>();

            if (gameSession != null) gameSession.ResetGame();
            else return; 
        }

        public void LoadGameOverScene() => StartCoroutine(WaitAndLoadFinalScene());

        public void QuitGame() => Application.Quit();

        private IEnumerator WaitAndLoadFinalScene()
        {
            yield return new WaitForSeconds(_gameOverDelay);
            SceneManager.LoadScene(2);
        }
    }
}