using UnityEngine;

public class ReloadPositionSetter : MonoBehaviour
{
    PlayerReload _reload;

    void Start()
    {
        _reload = transform.parent.GetComponent<PlayerReload>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") _reload.LoadPositionRewriting(transform);
    }
}
