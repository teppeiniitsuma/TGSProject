using UnityEngine;

public class BossBGController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    Vector3 delPos;
    

    void Start()
    {
        delPos = new Vector3(_camera.position.x - transform.position.x, 0, _camera.position.z);
    }

    void LateUpdate()
    {
        this.transform.position = _camera.position - delPos;
    }
}
