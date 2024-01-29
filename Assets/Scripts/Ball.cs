using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int MovingDistance => _movingDistance;
    public int HighScore => _highScore;

    [SerializeField]
    private Vector3 _startPos;

    [SerializeField]
    private int _movingDistance;

    [SerializeField]
    private int _highScore;

    private SpriteRenderer _spriteRenderer;

    private Rigidbody2D _rb;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private UIManager _uiManager;


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = _spriteRenderer.GetComponent<Rigidbody2D>();
        _startPos = this.transform.position;

        this.UpdateAsObservable()
            .Subscribe(_ => CountDistance())
            .AddTo(this);
    }

    private async void OnCollisionEnter2D(Collision2D collision)
    {
        //_spriteRenderer.color = new Color(255f, 0f, 0f);
        //await UniTask.Delay(TimeSpan.FromSeconds(1.0f));
        //_spriteRenderer.color = new Color(255f, 255f, 255f);

        if (collision.gameObject.name == "DeadLine")
        {
            this.gameObject.SetActive(false);
            _player.ResetCreateCount();
            if(_movingDistance >= _highScore)
            {
                _highScore = _movingDistance;
            }
            this.gameObject.transform.position = _startPos;
            this.gameObject.SetActive(true);
        }
    }

    private async void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Goal")
        {
            await UniTask.Delay(TimeSpan.FromSeconds(3.0f));
            Debug.Log("You did It");
        }
    }


    private void CountDistance()
    {
        _movingDistance = (int)(this.gameObject.transform.position.x - _startPos.x);
    }
}
