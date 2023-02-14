using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class OtherShape : MonoBehaviour
{
    [SerializeField] private Transform[] _shapes;

    private void Start()
    {
        /*var sequence = DOTween.Sequence();

        foreach (var shape in _shapes)
        {
            sequence.Append(shape.DOMoveX(10, Random.Range(1f, 2f)));
        }

        sequence.OnComplete(() =>
        {
            foreach (var shape in _shapes)
            {
                shape.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce);
            }
        });

        _shapes[0].DOMoveX(10, Random.Range(1f, 2f)).OnComplete(() =>
            _shapes[1].DOMoveX(10, Random.Range(1f, 2f)).OnComplete(() =>
                _shapes[2].DOMoveX(10, Random.Range(1f, 2f)).OnComplete((() => 
                        foreach (var shape in _shapes)
                        {
                            shape.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce);
                        }
                        )))));*/
        
        //AsyncFunction();
        AsyncTasks();
                        
    }

    private async void AsyncFunction()
    {
        foreach (var shape in _shapes)
        {
            await shape.DOMoveX(10, Random.Range(1f, 2f)).SetEase(Ease.InOutQuad).AsyncWaitForCompletion();
        }
    }

    private async void AsyncTasks()
    {
        var tasks = new List<Task>();

        foreach (var shape in _shapes)
        {
            tasks.Add(shape.DOMoveX(10, Random.Range(1f, 2f)).SetEase(Ease.InOutQuad).AsyncWaitForCompletion());
        }

        await Task.WhenAll(tasks);

        foreach (var shape in _shapes)
        {
            shape.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce);
        }
    }
}