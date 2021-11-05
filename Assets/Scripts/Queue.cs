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

    public void JoinInQueue(Customer �ustomer)
    {
        if (_queue.Count == 0)
            �ustomer.Init(null, cashBox);
        else
            �ustomer.Init(_queue[_queue.Count - 1], cashBox);
        _queue.Add(�ustomer);

    }


}


