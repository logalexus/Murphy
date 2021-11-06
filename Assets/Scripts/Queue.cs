using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Queue : MonoBehaviour
{
    [SerializeField] private CashBox _cashBox;
    [SerializeField] private BoxCollider2D _trigger;

    public UnityAction PlayerInQueue;
    public UnityAction PlayerOutQueue;
    
    private List<Customer> _queue;
    private bool _playerInQueue = false;

    private void Awake()
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
    }

    public void ExitFromQueue(Customer ñustomer)
    {
        _queue.Remove(ñustomer);
        ñustomer.Leave(() =>
        {
            _queue[0].Init(null, _cashBox, () => StandTriggerToEndQueue());
        });
        if (_queue.IndexOf(Player.Instanse.GetComponent<Customer>()) == 0)
            _trigger.offset = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            foreach (var customer in _queue)
                customer.UpdatePosition();

            if (_playerInQueue)
                StopAllCoroutines();
            else
            {
                _queue[_queue.Count - 1].Init(player.GetComponent<Customer>());
                _queue.Add(player.GetComponent<Customer>());
            }
            _playerInQueue = true;
            PlayerInQueue?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_queue[_queue.Count - 1] == player.GetComponent<Customer>())
            {
                StartCoroutine(Cooldown(player.GetComponent<Customer>(), 1f));
            }
            else
                StartCoroutine(Cooldown(player.GetComponent<Customer>(), 1f));

        }
    }

    IEnumerator Cooldown(Customer customer, float time)
    {
        yield return new WaitForSeconds(time);

        int playerQueueIndex = _queue.IndexOf(customer);
        if (_queue.Count - 1 != playerQueueIndex)
        {
            _queue[playerQueueIndex + 1].Init(playerQueueIndex == 0 ? null : _queue[playerQueueIndex - 1], _cashBox, () => StandTriggerToEndQueue());
            _queue[playerQueueIndex - 1].Init(_queue[playerQueueIndex + 1]);
            _trigger.enabled = false;
        }
            _queue.Remove(customer);
            _playerInQueue = false;
            PlayerOutQueue?.Invoke();
    }

    private void StandTriggerToEndQueue()
    {
        if (!_playerInQueue)
        {
            _trigger.offset = _queue[_queue.Count - 1].transform.localPosition + Vector3.up * 1f;
            _trigger.enabled = true;
        }
        else
            _trigger.offset = _queue[_queue.IndexOf(Player.Instanse.GetComponent<Customer>()) - 1].transform.localPosition + Vector3.up * 1f;
    }
    
    public bool CheckCountCustomers(int count)
    {
        return _queue.Count <= count;
    }
}


