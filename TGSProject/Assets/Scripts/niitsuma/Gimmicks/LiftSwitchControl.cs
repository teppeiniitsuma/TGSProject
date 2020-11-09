using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftSwitchControl : MonoBehaviour
{
    [SerializeField] SwitchLiftController switchLift;
    [SerializeField] BoxCollider2D[] _coll;
    [SerializeField] Animator chainAnim;
    int count = 0;
    bool anim = false;
    Vector2 startPos;
    float pushPos;

    void Start()
    {
        chainAnim.speed = 0;
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
    void ColliderActive(bool b)
    {
        if(null != _coll)
        {
            if (b)
            {
                for (int i = 0; i < _coll.Length; i++)
                {
                    _coll[i].gameObject.SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < _coll.Length; i++)
                {
                    _coll[i].gameObject.SetActive(false);
                }
            }
        }
    }
    void OnSwitchPush()
    {
        if(chainAnim.speed == 0) { chainAnim.speed = 1; SoundManager.PlayMusic("Audios/Gimmick/pickupkey", false);  }
        if (switchLift.IsLevel) { return; ColliderActive(false); }
        StartCoroutine(SwitchON());
        if (!switchLift.IsLevel) { switchLift.IsSwitch = true; ColliderActive(false); }
    }
    void OnSwitchExit()
    {
        if (switchLift.IsLevel) {  return; ColliderActive(false); }
        StartCoroutine(SwitchOFF());
        if (!switchLift.IsLevel) { switchLift.IsSwitch = false; ColliderActive(true); }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            count++;
            anim = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            count--;
            anim = false;
        }
    }
    private void Update()
    {
        if (0 < count && !anim) { OnSwitchPush(); anim = !anim; SoundManager.PlayMusic("Audios/Gimmick/switch", false); }
        else if (count == 0 && !anim) { OnSwitchExit(); anim = !anim; }
    }
}
