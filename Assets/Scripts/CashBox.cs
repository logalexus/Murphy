using UnityEngine;
using System.Collections;

public class CashBox : MonoBehaviour
{
    [SerializeField] private Queue _queue;
    

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

        }
    }

    IEnumerator WaitCustomerOnCashBox(Customer customer, float time)
    {
        yield return new WaitForSeconds(time);
        _queue.ExitFromQueue(customer);

    }
}
