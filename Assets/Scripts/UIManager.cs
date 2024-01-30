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
    [Header("�ő吶�����\���e�L�X�g")]
    private Text _createRoadText;

    [SerializeField]
    [Header("�ړ������\���e�L�X�g")]
    private Text _movingDistanceText;

    [SerializeField]
    [Header("�n�C�X�R�A�\���e�L�X�g")]
    private Text _highScoreText;

    [SerializeField]
    [Header("�Z���t�\���e�L�X�g")]
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
            _text.text = $"HighScore�X�V�܂�{_ball.HighScore - _ball.MovingDistance}�q";
        else _text.text = $"�ڎw��150km!!";
    }
}
