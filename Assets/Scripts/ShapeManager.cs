using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    [SerializeField] private Shape[] _shapes;
    [SerializeField] private GameObject _finishedText;

    public async void BeginTest()
    {
        _finishedText.SetActive(false);

        await _shapes[0].RotateForSecondsAsync(1 + 1 * 0);

        //var tasks = new Task[_shapes.Length];
        var tasks = new List<Task>();
        
        for (var i = 1; i < _shapes.Length; i++)
        {
            //StartCoroutine(_shapes[i].RotateForSeconds(1 + 1 * i));
            //await _shapes[i].RotateForSecondsAsync(1 + 1 * i);
            
            //tasks[i] = _shapes[i].RotateForSecondsAsync(1 + 1 * i);
            tasks.Add(_shapes[i].RotateForSecondsAsync(1 + 1 * i));
        }

        await Task.WhenAll(tasks);
        
        _finishedText.SetActive(true);

        var randomNumber = await GetRandomNumber();
        Debug.Log($"{randomNumber}");
        
        //BeginAnotherTest();   This crashes Unity
        
        
    }

    public void BeginAnotherTest()
    {
        var randomNumber = GetRandomNumber().GetAwaiter().GetResult();
        Debug.Log($"{randomNumber}");
    }

    private async Task<int> GetRandomNumber()
    {
        var randomNumber = Random.Range(500, 1000);
        await Task.Delay(randomNumber);
        return randomNumber;
    }
    
    private async Task<int> GetRandomNumber(float delay)
    {
        var randomNumber = Random.Range(0, 1000);
        await Task.Delay((int)delay * 1000);
        return randomNumber;
    }
}
