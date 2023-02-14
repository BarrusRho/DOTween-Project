using System;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class OtherFeatures : MonoBehaviour
{
    [SerializeField] private Transform _jumper, _puncher, _shaker, _target;
    [SerializeField] private MeshRenderer _changer;

    private void Start()
    {
        DOVirtual.Float(0, 10, 3, value => print(value)).SetEase(Ease.InBounce).SetLoops(-1, LoopType.Yoyo);
    }

    public void Jump()
    {
        _jumper.DOJump(new Vector3(-2.2f, 1f, 0), 3, 1, 0.5f).SetEase(Ease.InOutSine);
    }

    public void Shake()
    {
        const float duration = 0.5f;
        const float strength = 0.5f;

        //var tween = _shaker.DOShakePosition(duration, strength);

        /*if (tween.IsPlaying())
        {
            return;
        }*/

        _shaker.DOShakePosition(duration, strength);
        _shaker.DOShakeRotation(duration, strength);
        _shaker.DOShakeScale(duration, strength);

        //transform.DOKill();
    }

    public void Punch()
    {
        var duration = 0.5f;
        _puncher.DOPunchPosition(Vector3.left * 2, duration, 0, 0);
        _target.DOShakePosition(0.5f, 0.5f, 10).SetDelay(duration * 0.5f);
    }

    public void Change()
    {
        _changer.material.DOColor(Random.ColorHSV(), 0.3f).OnComplete(Change);
    }
}