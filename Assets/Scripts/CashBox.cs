using UnityEngine;
using System.Collections;

public class CashBox : MonoBehaviour
{
    [SerializeField] private Queue _queue;
    [SerializeField] private Dog _dog;
    [SerializeField] private FinalScreenGoodWork _finalScreenGoodWork;




    public float TimeComplete
    {
        get => _timeComplete;
        set
        {
            _timeComplete = value;
        }

    }

    private float _timeComplete = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Customer customer))
        {
            if (!customer.TryGetComponent(out Player player))
            {
                StartCoroutine(WaitCustomerOnCashBox(customer, TimeComplete));
            }
            else if (customer.TryGetComponent(out Player pl) && _queue.GetIndexCustomer(customer) == 0)
            {
                int value = Random.Range(0, 10);
                if (value > 6)
                    _dog.Attack(pl);
                else
                    _finalScreenGoodWork.Open(gameObject);
            }

        }
    }

    IEnumerator WaitCustomerOnCashBox(Customer customer, float time)
    {
        yield return new WaitForSeconds(time);
        _queue.ExitFromQueue(customer);

    }
}
