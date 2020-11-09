using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour
{
    [SerializeField] BridgeScript bri;

    [SerializeField] GameObject colli;
    int count = 0;
    bool anim = false;
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
    void OnSwitchPush()
    {
        if (bri.isLevel) { if (null != colli) { colli.SetActive(false); } return; }
        if (null != colli) { colli.SetActive(false); }
        SoundManager.PlayMusic("Audios/Gimmick/switch", false);
        StartCoroutine(SwitchON());
        if(!bri.isLevel) bri.isSwitchUp = true;
    }
    void OnSwitchExit()
    {
        if (bri.isLevel) { if (null != colli) { colli.SetActive(false); } return; }
        if (null != colli) { colli.SetActive(true); }
        StartCoroutine(SwitchOFF());
        if (!bri.isLevel) bri.isSwitchUp = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
        if (0 < count && !anim) { OnSwitchPush(); anim = !anim; }
        else if (count == 0 && !anim) { OnSwitchExit(); anim = !anim; }
    }
}
