using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    [SerializeField] private CashBox _cashBox;
    [SerializeField] private BoxCollider2D _trigger;

    private float _offset = 1.2f;
    private List<Customer> _queue;
    private bool _playerInQueue = false;

    private void Start()
    {
        _queue = new List<Customer>();
    }

    public void JoinInQueue(Customer ñustomer)
    {
        if (_queue.Count == 0)
            ñustomer.Init(null, _cashBox, () => StandTriggerToEndQueue());
        else
        {
            ñustomer.Init(_queue[_queue.Count - 1], _cashBox, () => StandTriggerToEndQueue());
            _queue[_queue.Count - 1].Init(ñustomer);
        }
        _queue.Add(ñustomer);

        //if (!_playerInQueue)
            //_trigger.offset = new Vector2(_trigger.offset.x, _trigger.offset.y + _offset);

    }

    public void ExitFromQueue(Customer ñustomer)
    {


        _queue.Remove(ñustomer);
        Destroy(ñustomer.gameObject);
        ñustomer = null;


        //if (!_playerInQueue)
           // _trigger.offset = new Vector2(_trigger.offset.x, _trigger.offset.y - _offset);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_playerInQueue)
                StopAllCoroutines();
            else
                _queue.Add(player.GetComponent<Customer>());
            _playerInQueue = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            StartCoroutine(Cooldown(player.GetComponent<Customer>()));
        }
    }

    IEnumerator Cooldown(Customer customer)
    {
        yield return new WaitForSeconds(3f);

        int playerQueueIndex = _queue.IndexOf(customer);
        if (_queue.Count - 1 != playerQueueIndex)
        {
            _queue[playerQueueIndex + 1].Init(_queue[playerQueueIndex - 1], _cashBox, () => StandTriggerToEndQueue());
            _queue.Remove(customer);
           // _trigger.offset = new Vector2(_trigger.offset.x, _trigger.offset.y + (_queue.Count - playerQueueIndex) * _offset);
            _playerInQueue = false;
        }
    }

    private void StandTriggerToEndQueue()
    {
        _trigger.offset = _queue[_queue.Count - 1].transform.localPosition + Vector3.up * 1f;
    }
    
}


