using UnityEngine;

namespace SpaceWars
{
    public class MusicPlayer : MonoBehaviour
    {
        private void Awake() => SetUpSingleton();

        private void SetUpSingleton()
        {
            int instanceCount = FindObjectsOfType(GetType()).Length;
            if (instanceCount > 1) Destroy(gameObject);
            else DontDestroyOnLoad(gameObject);
        }
    }
}