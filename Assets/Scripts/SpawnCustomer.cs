using UnityEngine;
using System.Collections;

public class SpawnCustomer : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _leavePoint;
    [SerializeField] private Customer _prefab;
    [SerializeField] private Queue _queue;

    private void Start()
    {
        CreateCustomer();
        StartCoroutine(Spawn(Random.Range(1,4)));
    }

    IEnumerator Spawn(int time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (_queue.CheckCountCustomers(5))
                CreateCustomer();
        }
    }

    private void CreateCustomer()
    {
        Customer customer = Instantiate(_prefab, transform.parent);
        customer.SetLeavePoint(_leavePoint.position);
        customer.transform.position = _spawnPoint.position;
        _queue.JoinInQueue(customer);
    }
}
