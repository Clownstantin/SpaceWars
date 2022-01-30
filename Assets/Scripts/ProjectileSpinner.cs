using UnityEngine;

namespace SpaceWars
{
    public class ProjectileSpinner : MonoBehaviour
    {
        [SerializeField] private float _spinSpeed = 360f;

        private Transform _transform;
        private float _randomRotation;

        private void Start()
        {
            _transform = transform;
            _randomRotation = Random.Range(-_spinSpeed, _spinSpeed);
        }

        private void Update() => _transform.Rotate(0, 0, _randomRotation * Time.deltaTime);
    }
}