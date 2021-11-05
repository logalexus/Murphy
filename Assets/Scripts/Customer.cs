using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Customer : MonoBehaviour
{
    private Customer _nextCustomer;
    private CashBox _cashBox;
    private float _offset = 5;

    public void Init(Customer nextCustomer, CashBox cashBox)
    {
        _nextCustomer = nextCustomer;
        _cashBox = cashBox;
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        if (_nextCustomer != null)
            StandBehind();
        else
            StandFrontCashBox();
    }

    public void StandBehind()
    {
        transform.DOMove(_nextCustomer.transform.position + Vector3.up * _offset, 2).SetEase(Ease.InOutQuad);
    }

    public void StandFrontCashBox()
    {
        transform.DOMove(_cashBox.transform.position + Vector3.up * _offset, 2).SetEase(Ease.InOutQuad);

    }
}
