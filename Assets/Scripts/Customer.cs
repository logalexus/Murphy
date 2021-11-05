using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.Events;

public class Customer : MonoBehaviour
{
    private Customer _nextCustomer;
    private Customer _backCustomer;

    private CashBox _cashBox;
    private const float _offset = 1.2f;
    private const float _duration = 0.5f;
    private bool _isPlayer = false;
    private UnityAction _callbackLastCustomer;

    private void Start()
    {
        _isPlayer = TryGetComponent(out Player player);
    }

    public void Init(Customer nextCustomer, CashBox cashBox, UnityAction callbackLastCustomer)
    {
        if (!_isPlayer)
        {
            _nextCustomer = nextCustomer;
            _cashBox = cashBox;
            _callbackLastCustomer = callbackLastCustomer;
            UpdatePosition();
        }
        
    }
    public void Init(Customer backCustomer)
    {
        _backCustomer = backCustomer;
    }
    

    public void UpdatePosition()
    {
        if (!_isPlayer)
        {
        if (_nextCustomer != null)
            StandBehind();
        else
            StandFrontCashBox();
        }
    }

    public void StandBehind()
    {
        transform.DOMove(_nextCustomer.transform.position + Vector3.up * _offset, _duration).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            if (_backCustomer != null)
                _backCustomer.UpdatePosition();
            else
                _callbackLastCustomer?.Invoke();
        });
    }

    public void StandFrontCashBox()
    {
        transform.DOMove(_cashBox.transform.position + Vector3.up * _offset, _duration).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            if (_backCustomer != null)
                _backCustomer.UpdatePosition();
            else
                _callbackLastCustomer?.Invoke();
        });
    }
}
