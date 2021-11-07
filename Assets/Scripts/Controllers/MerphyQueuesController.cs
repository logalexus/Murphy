using UnityEngine;
using System.Collections;

public class MerphyQueuesController : MonoBehaviour
{
    [SerializeField] private Queue _queueLeft;
    [SerializeField] private Queue _queueRight;
    [SerializeField] private SpawnCustomer _spawnCustomerLeft;
    [SerializeField] private SpawnCustomer _spawnCustomerRight;
    [SerializeField] private CashBox _cashBoxLeft;
    [SerializeField] private CashBox _cashBoxRight;


    private void Start()
    {
        _queueLeft.PlayerInQueue += () => PlayerEnterLeftQueue();
        _queueLeft.PlayerOutQueue += () => PlayerExitLeftQueue();
        _queueRight.PlayerInQueue += () => PlayerEnterRightQueue();
        _queueRight.PlayerOutQueue += () => PlayerExitRightQueue();

        _spawnCustomerRight.TimeSpawn = Random.Range(4f, 7f) / 10;
        _spawnCustomerLeft.TimeSpawn = Random.Range(4f, 7f) / 10;
    }

    private void PlayerEnterLeftQueue()
    {
        _cashBoxRight.TimeComplete = 1;
        _cashBoxLeft.TimeComplete = 12;
        _spawnCustomerRight.TimeSpawn = 5f;
        _spawnCustomerLeft.TimeSpawn = 5f;
    }

    private void PlayerExitLeftQueue()
    {
        _cashBoxRight.TimeComplete = Random.Range(5, 7);
        _cashBoxLeft.TimeComplete = Random.Range(5, 7);
        _spawnCustomerRight.TimeSpawn = 0.2f;
        _spawnCustomerLeft.TimeSpawn = 5f;

    }

    private void PlayerEnterRightQueue()
    {
        _cashBoxRight.TimeComplete = 12;
        _cashBoxLeft.TimeComplete = 1;
        _spawnCustomerRight.TimeSpawn = 5f;
        _spawnCustomerLeft.TimeSpawn = 5f;
    }

    private void PlayerExitRightQueue()
    {
        _cashBoxRight.TimeComplete = Random.Range(5, 7);
        _cashBoxLeft.TimeComplete = Random.Range(5, 7);
        _spawnCustomerRight.TimeSpawn = 5f;
        _spawnCustomerLeft.TimeSpawn = 0.2f;

    }
}
