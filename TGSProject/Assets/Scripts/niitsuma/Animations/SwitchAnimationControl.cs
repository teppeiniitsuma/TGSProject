using System.Collections;
using UnityEngine;

public class SwitchAnimationControl : MonoBehaviour
{
    Vector2 startPos;
    float pushPos;

    void Start()
    {
        startPos = transform.position;
        pushPos = startPos.y - 0.3f;
    }

    IEnumerator SwitchON()
    {
        while (pushPos < transform.position.y)
        {
            transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, pushPos, Time.deltaTime));
            yield return null;
        }
    }
    IEnumerator SwitchOFF()
    {
        while (transform.position.y < startPos.y)
        {
            transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, startPos.y, Time.deltaTime));
            yield return null;
        }
    }
    public void OnSwitchPush()
    {
        StartCoroutine(SwitchON());
    }
    public void OnSwitchExit()
    {
        StartCoroutine(SwitchOFF());
    }
}
