using UnityEngine;

public class FollowScreen : MonoBehaviour
{
    [SerializeField]
    [Header("カメラで追いかけたいオブジェクト")]
    private GameObject _ball;

    private Transform _ballTrans;

    private void Start()
    {
        _ballTrans = _ball.transform;
    }

    private void LateUpdate() => MoveCamera();

    private void MoveCamera()
    {
        transform.position = new Vector3(_ballTrans.position.x, transform.position.y, transform.position.z);
    }

}
