using UnityEngine;

namespace SpaceWars
{
    public class EnemyPathing : MonoBehaviour
    {
        private WaveConfig _waveConfig;
        private Transform _transform;
        private Transform[] _waypoints;
        private int _waypointIndex = 0;

        private void Start()
        {
            _transform = transform;
            _waypoints = _waveConfig.GetWaypointsArray();
            _transform.position = _waypoints[_waypointIndex].position;
        }

        private void Update()
        {
            WaypointMovement();
        }

        public void SetWaveConfig(WaveConfig wave) => _waveConfig = wave;

        private void WaypointMovement()
        {
            if (_waypointIndex < _waypoints.Length)
            {
                var targetPos = _waypoints[_waypointIndex].position;
                float deltaMoveSpeed = _waveConfig.MoveSpeed * Time.deltaTime;
                _transform.position = Vector2.MoveTowards(_transform.position, targetPos, deltaMoveSpeed);

                if (_transform.position == targetPos)
                    _waypointIndex++;
            }
            else Destroy(gameObject);
        }
    }
}
