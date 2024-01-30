using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int CreateCount => _createCount;

    public int CreateLimit => _createLimit;

    [SerializeField]
    [Header("生成したいオブジェクト")]
    private GameObject _road;

    [SerializeField]
    [Header("生成したオブジェクトを格納")]
    private List<GameObject> _createdRoads = new();

    [SerializeField]
    [Header("生成した数")]
    private int _createCount = 0;

    [SerializeField]
    [Header("生成できる数")]
    private int _createLimit;

    [SerializeField]
    [Header("マウスカーソルの座標")]
    private Vector3 _mousePos;

    [SerializeField]
    [Header("道の寿命カウントダウン用")]
    private float _deleteTime;

    [SerializeField]
    [Header("道の寿命")]
    private float _timeLimit;


    [SerializeField]
    [Header("道の回転数")]
    private int _changeAngle = 0;

    [SerializeField]
    [Header("スコア勝負かステージ制か")]
    private bool _isEndless;

    [SerializeField]
    [Header("生成時におかれる位置を示すためのやつ")]
    private GameObject _shadowRoad;

    private bool _direction;

    private void Start()
    {
        _road.transform.eulerAngles = new Vector3();

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                ControlRoad();
                DeleteRoad();
                ShadowCreatePos();
            })
            .AddTo(this);
    }

    private void ControlRoad()
    {
        if(!_isEndless) if (_createCount >= _createLimit) return;

        CreateRoad();
        CreatedRoadRotate();
        ChangeRotate();
    }

    private void DeleteRoad()
    {
        if (_deleteTime <= 0)
        {
            if (_createdRoads.Count >= 1)
            {
                _createdRoads.RemoveAt(0);
            }
            _deleteTime = _timeLimit;
        }
        else _deleteTime -= Time.deltaTime;
    }

    private void ShadowCreatePos()
    {
        if (!_isEndless) 
        {
            if (_createCount >= _createLimit)
            {
                _shadowRoad.SetActive(false);
                return;
            }
        }

        var mousePos = Input.mousePosition;
        mousePos.z = 5.0f;
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        _shadowRoad.transform.position = worldPos;
    }

    public void ResetCreateCount() => _createCount = 0;

    private void CreateRoad()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _createCount++;

            var clickPos = Input.mousePosition;
            clickPos.z = 5.0f;

            _mousePos = Camera.main.ScreenToWorldPoint(clickPos);

            var roadAngle = _road.transform.eulerAngles;
            _createdRoads.Add(Instantiate(_road, _mousePos, Quaternion.Euler(roadAngle)));

        }
    }

    private void ChangeRotate()
    {
        if (Input.GetMouseButtonDown(2))
        {
            if (_direction == false) _direction = true;
            else _direction = false;
        }
    }

    private void CreatedRoadRotate()
    {
        if (Input.GetMouseButton(1))
        {
            if (_direction == true) _changeAngle++;
            else _changeAngle--;
            if (_changeAngle >= 36) _changeAngle = 0;
            _road.transform.eulerAngles = new Vector3(0f, 0f, -2f * _changeAngle);
            _shadowRoad.transform.eulerAngles = new Vector3(0f, 0f, -2f * _changeAngle);
        }
    }
}
