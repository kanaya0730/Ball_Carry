using Cysharp.Threading.Tasks;
using UniRx.Triggers;
using UniRx;
using UnityEngine;
using Unity.VisualScripting.Antlr3.Runtime;
using System.Threading;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private SoundManager _soundManager;

    [SerializeField]
    private EffectManager _effectManager;

    [SerializeField]
    private UIManager _uiManager;

    [SerializeField]
    private SceneLoader _sceneLoader;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private Ball _ball;

    private CancellationToken _token;

    private void Start()
    {
        CountStart();

        this.UpdateAsObservable()
            .Subscribe(_ => EndGame())
            .AddTo(this);
    }

    private async void CountStart()
    {
        Time.timeScale = 0;
        await UniTask.WaitUntil(() => IsClick(), cancellationToken: _token);
        Time.timeScale = 1;
    }

    private bool IsClick()
    {
        return Input.GetMouseButtonDown(0);
    }

    private void EndGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _sceneLoader.FadeIn(SceneLoader.SceneName.Title);
        }
    }
}