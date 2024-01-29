using Cysharp.Threading.Tasks;
using UniRx.Triggers;
using UniRx;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private SoundManager _soundManager;

    [SerializeField]
    private EffectManager _effectManager;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private Ball _ball;

    void Start()
    {
        CountStart();
    }

    private async void CountStart()
    {
        var token = this.GetCancellationTokenOnDestroy();

        Time.timeScale = 0;
        await UniTask.WaitUntil(() => IsClick(), cancellationToken: token);
        Time.timeScale = 1;
    }

    private bool IsClick()
    {
        return Input.GetMouseButtonDown(0);
    }
}
