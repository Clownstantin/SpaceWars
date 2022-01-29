using UnityEngine;

namespace SpaceWars
{
    [RequireComponent(typeof(Renderer))]
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] private float _scrollSpeed = 0.1f;

        private Material _backgroundMat;

        private void Start()
        {
            _backgroundMat = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            Vector2 offset = _backgroundMat.mainTextureOffset;
            offset.y += _scrollSpeed * Time.deltaTime;

            if (offset.y >= 1)
                offset.y = 0;

            _backgroundMat.mainTextureOffset = offset;
        }
    }
}