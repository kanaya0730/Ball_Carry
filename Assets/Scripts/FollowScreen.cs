using UnityEngine;

public class FollowScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject _ball;

    private Transform _ballTrans;

    void Start()
    {
        _ballTrans = _ball.transform;
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        transform.position = new Vector3(_ballTrans.position.x, transform.position.y, transform.position.z);
    }

}
