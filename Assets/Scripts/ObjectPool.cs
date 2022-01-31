using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceWars
{
    public class ObjectPool : MonoBehaviour
    {
        [Header("ObjectPool Settings")]
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;

        private Vector3 _disablePoint;
        private List<GameObject> _pool = new List<GameObject>();

        protected void Init(GameObject prefab)
        {
            _disablePoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 1));

            for (int i = 0; i < _capacity; i++)
            {
                var spawnedPrefab = Instantiate(prefab, _container.transform);
                spawnedPrefab.SetActive(false);

                _pool.Add(spawnedPrefab);
            }
        }

        protected bool TryGetObject(out GameObject result)
        {
            result = _pool.FirstOrDefault(p => !p.activeSelf);
            return result != null;
        }

        protected void DisableObjOutScreen()
        {
            foreach (var item in _pool)
            {
                if (item.activeSelf)
                {
                    if (item.transform.position.y >= _disablePoint.y)
                        item.SetActive(false);
                }
            }
        }

        protected void ResetPool()
        {
            foreach (var item in _pool)
                item.SetActive(false);
        }
    }
}
