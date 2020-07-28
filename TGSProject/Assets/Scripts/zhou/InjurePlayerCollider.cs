using UnityEngine;

public class InjurePlayerCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("HP減り処理");
            GameManager.Instance.Information.DecreaseHP();
        }
    }
}
