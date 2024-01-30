using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField]
    [Header("ê∂ê¨ÇµÇΩìπÇÃéıñΩ")]
    private float _deleteTime = 1.0f;

    private async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_deleteTime));
        Destroy(this.gameObject);
    }
}
