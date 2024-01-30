using UnityEngine;

public class FollowScreen : MonoBehaviour
{
    [SerializeField]
    [Header("�J�����Œǂ����������I�u�W�F�N�g")]
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
