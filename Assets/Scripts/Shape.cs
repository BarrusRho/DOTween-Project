using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class Shape : MonoBehaviour
{
    [SerializeField] private Transform _innerShape, _outershape;
    [SerializeField] private float _cycleLength = 2f;

    private void Start()
    {
        transform.DOMove(new Vector3(10, 0, 0), _cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

        _innerShape.DORotate(new Vector3(0, 360, 0), _cycleLength * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);

        _outershape.DOLocalMove(new Vector3(0, -3, 0), _cycleLength * 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    public void Move()
    {
        transform.DOMoveX(10, 2).SetSpeedBased(true);
    }

    public IEnumerator RotateForSeconds(float duration)
    {
        var end = Time.time + duration;
        while (Time.time < end)
        {
            transform.Rotate(new Vector3(1, 1) * Time.deltaTime * 150);
            yield return null;
        }
    }
    
    public async Task RotateForSecondsAsync(float duration)
    {
        var end = Time.time + duration;
        while (Time.time < end)
        {
            transform.Rotate(new Vector3(1, 1) * Time.deltaTime * 150);
            await Task.Yield();
        }
    }
}
