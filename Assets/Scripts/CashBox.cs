using UnityEngine;
using System.Collections;

public class CashBox : MonoBehaviour
{
    [SerializeField] private Queue _queue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Customer customer))
        {
            if (!customer.TryGetComponent(out Player player))
            {
                StartCoroutine(WaitCustomerOnCashBox(customer, Random.Range(2, 5)));

            }

        }
    }

    IEnumerator WaitCustomerOnCashBox(Customer customer, int time)
    {
        yield return new WaitForSeconds(time);
        _queue.ExitFromQueue(customer);

    }
}
