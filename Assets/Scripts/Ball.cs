using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int MovingDistance => _movingDistance;
    public int HighScore => _highScore;

    [SerializeField]
    [Header("ボールの種類")]
    private List<Sprite> _sprits = new();

    [SerializeField]
    [Header("初期座標")]
    private Vector3 _startPos;

    [SerializeField]
    [Header("移動距離")]
    private int _movingDistance;

    [SerializeField]
    [Header("移動距離の最大値")]
    private int _highScore;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private UIManager _uiManager;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    private int num;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = _spriteRenderer.GetComponent<Rigidbody2D>();
        _startPos = this.transform.position;

        this.UpdateAsObservable()
            .Subscribe(_ => CountDistance())
            .AddTo(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "DeadLine")
        {
            this.gameObject.SetActive(false);
            _player.ResetCreateCount();
            if(_movingDistance >= _highScore)
            {
                _highScore = _movingDistance;
            }

            if(num == _sprits.Count) num = 0;
            _spriteRenderer.sprite = _sprits[num];
            num++;

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

    private void CountDistance() => _movingDistance = (int)(this.gameObject.transform.position.x - _startPos.x);
}
