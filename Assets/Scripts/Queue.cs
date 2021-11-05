using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    [SerializeField] private CashBox cashBox;

    private List<Customer> _queue;

    private void Start()
    {
        _queue = new List<Customer>();
    }

    public void JoinInQueue(Customer ñustomer)
    {
        if (_queue.Count == 0)
            ñustomer.Init(null, cashBox);
        else
            ñustomer.Init(_queue[_queue.Count - 1], cashBox);
        _queue.Add(ñustomer);

    }


}


