using Cysharp.Threading.Tasks;
using System.Threading;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private Ball _ball;

    [SerializeField]
    [Header("最大生成数表示テキスト")]
    private Text _createRoadText;

    [SerializeField]
    [Header("移動距離表示テキスト")]
    private Text _movingDistanceText;

    [SerializeField]
    [Header("ハイスコア表示テキスト")]
    private Text _highScoreText;

    [SerializeField]
    [Header("セリフ表示テキスト")]
    private Text _text;

    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => TextAssignment())
            .AddTo(this);
    }

    private void TextAssignment()
    {
        _createRoadText.text = $"{_player.CreateCount}/{_player.CreateLimit}";
        _movingDistanceText.text = $"Socre\n{_ball.MovingDistance}km";
        _highScoreText.text = $"HighScore\n{_ball.HighScore}km";

        if (_ball.HighScore > _ball.MovingDistance)
            _text.text = $"HighScore更新まで{_ball.HighScore - _ball.MovingDistance}㎞";
        else _text.text = $"目指せ150km!!";
    }
}
