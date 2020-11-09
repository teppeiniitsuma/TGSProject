using UnityEngine;

public class StoneItem : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    Vector2 vector = new Vector2(500, 0);
    float time = 0;
    DisplaySpiderCounter disp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damege = collision.gameObject.GetComponent<IDamager>();
        if (damege != null) 
        {
            damege.ApplyDamage(EnemyType.None); disp.SpiderChecks();
            SoundManager.PlayEffect("Audios/Enemy/spider_lock-on", false);
            ResultManager.Instance.SetEnemyKillCount();
        }
    }
    private void Awake()
    {
        disp = FindObjectOfType<DisplaySpiderCounter>();
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        var gm = GameManager.Instance.Information.GetParameter.direction;
        if(gm == 1)
            _rigidbody.AddForce(vector);
        else
            _rigidbody.AddForce(-vector);
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time > 2) { Destroy(gameObject); }
    }

}
