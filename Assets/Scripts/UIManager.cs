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
                _text.text = $"�Ȃ��Ȃ���邶���";
                break;
            case 50:
                _text.text = $"�������ɔ��Ă�������";
                break;
            case 75:
                _text.text = $"�����܂ł����̂���������";
                break;
            case 100:
                _text.text = $"�O���܂ł��������";
                break;
            case 125:
                _text.text = $"�܂��܂��������I";
                break;
            default:
                _text.text = $"";
                break;
        }
    }
}
