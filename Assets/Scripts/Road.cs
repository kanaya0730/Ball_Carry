using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class Road : MonoBehaviour
{
    private async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(4.0f));
        Destroy(this.gameObject);
    }
}
