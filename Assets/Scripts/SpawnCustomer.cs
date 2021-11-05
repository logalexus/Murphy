using UnityEngine;
using System.Collections;

public class SpawnCustomer : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Customer _prefab;
    [SerializeField] private Queue _queue;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Instantiate(_prefab, _spawnPoint);
            _queue.JoinInQueue(_prefab);
        }
    }
}
