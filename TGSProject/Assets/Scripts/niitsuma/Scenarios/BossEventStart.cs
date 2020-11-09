using UnityEngine;

public class BossEventStart : MonoBehaviour
{
    public bool EventStart { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") { EventStart = true; }
    }
}
