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
    private Text _createRoadText;

    [SerializeField]
    private Text _movingDistanceText;

    [SerializeField]
    private Text _highScoreText;

    [SerializeField]
    private Text _text;
    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => TextAssignment())
            .AddTo(this);
    }

    private void TextAssignment()
    {
        _createRoadText.text = $"{_player.CreateCount.ToString()}/{_player.CreateLimit}";
        _movingDistanceText.text = $"Socre\n{_ball.MovingDistance.ToString()}km";
        _highScoreText.text = $"HighScore\n{_ball.HighScore.ToString()}km";

        switch(_ball.MovingDistance)
        {
            case 25:
                _text.text = $"なかなかやるじゃん";
                break;
            case 50:
                _text.text = $"さすがに疲れてきたかな";
                break;
            case 75:
                _text.text = $"ここまできたのかすごいな";
                break;
            case 100:
                _text.text = $"三桁まできたじゃん";
                break;
            case 125:
                _text.text = $"まだまだいけるよ！";
                break;
            default:
                _text.text = $"";
                break;
        }
    }
}
