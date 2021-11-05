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
            Customer customer = Instantiate(_prefab, transform.parent);
            customer.transform.position = _spawnPoint.position;
            _queue.JoinInQueue(customer);
        }
    }
}
