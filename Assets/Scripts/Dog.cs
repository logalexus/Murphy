using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Dog : MonoBehaviour
{
    [SerializeField] Transform _attackPosition;

    private Tween tw;
    private Vector3 defaultPosition;

    private void Start()
    {
        defaultPosition = transform.position;
    }
    public void Attack(Player player)
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.Sounds.Dog);

        tw = transform.DOMove(_attackPosition.position, 0.3f).SetEase(Ease.InOutQuad).SetAutoKill(false).OnComplete(()=>
        {
            player.transform.DOMove(player.transform.position + (player.transform.position - defaultPosition).normalized * 5, 0.5f).SetEase(Ease.InOutQuad);
            tw.PlayBackwards();
        });
    }

}
