using UnityEngine;
using System.Collections;

public class SpawnCustomer : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _leavePoint;
    [SerializeField] private Customer _prefab;
    [SerializeField] private Queue _queue;
    

    public float TimeSpawn
    {
        get => _timeSpawn;
        set
        {
            _timeSpawn = value;
            StopAllCoroutines();
            StartCoroutine(Spawn(value));
        }

    }

    private float _timeSpawn = 2;

    private void Start()
    {
        CreateCustomer();
        StartCoroutine(Spawn(TimeSpawn));
    }

    IEnumerator Spawn(float time)
    {
        while (true)
        {
            
            CreateCustomer();
            yield return new WaitForSeconds(time);
        }
    }

    public void CreateCustomer()
    {
        if (_queue.CheckCountCustomers(5))
        {
            Customer customer = Instantiate(_prefab, transform.parent);
            customer.SetLeavePoint(_leavePoint.position);
            customer.transform.position = _spawnPoint.position;
            _queue.JoinInQueue(customer);
        }
    }
}
