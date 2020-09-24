using UnityEngine;

public class DisplaySpiderCounter : MonoBehaviour
{
    private const int dispSpiders = 4; // 画面内に存在できる蜘蛛の数
    
    [SerializeField] private Transform[] spiders = new Transform[dispSpiders];
    [SerializeField] private GameObject caterpillar;

    private int count = 0;
    private bool isAttackTrigger = false;
    private Vector3 te = new Vector3(0, 4.9f, 0);

    public void spiderAddCount(Transform t)
    {
        spiders[count] = t;
        count++;
    }

    public void spiderDelCount(Transform t)
    {
        count--;
        for (int i = 0; i < spiders.Length; i++)
        {
            if (spiders[i] == t)
            {
                if (i < spiders.Length)
                {
                    spiders[i] = spiders[i + 1];
                    spiders[i + 1] = null;
                }
                else spiders[i] = null;
            }
        }
    }
    /// <summary>
    /// 画面内に蜘蛛がいるかを判断
    /// </summary>
    public bool SpiderInScreen()
    {
        if (null != spiders[0]) return true;
        return false;
    }

    /// <summary>
    /// 画面内の蜘蛛の上に毛虫を作り攻撃する
    /// </summary>
    public void CaterpillarAttack()
    {
        if (GameManager.Instance.GetGameState == GameManager.GameState.Main)
        {
            GameManager.Instance.SetEventState(GameManager.EventState.AttackEvent);
            isAttackTrigger = true;
        }
    }

    // 画面内の蜘蛛を全て非アクティブ化する
    void ClearSpiders()
    {
        int x = 0;
        if(null != spiders[0])
        {
            spiders[0].transform.parent.gameObject.SetActive(false);
            for(int i = 0; i < spiders.Length; i++)
            {
                x = i < spiders.Length - 1 ? 1 : 0;
                spiders[i] = spiders[i + x] ;
            }
        }
        //for (int i = 0; i < spiders.Length; i++)
        //{
        //    if (null != spiders[i])
        //    {
        //        spiders[i].transform.parent.gameObject.SetActive(false);
        //        spiders[i] = null;
        //    }
        //}
        count = 0;
    }

    /// <summary>
    /// 時間ないから一時的に書いた処理
    /// </summary>
    public void SpiderChecks()
    {
        for(int i = 0; i < spiders.Length; i++)
        {
            int x = 0;
            if (null != spiders[i])
            {
                x = i < spiders.Length - 1 ? 1 : 0;
                spiders[i] = spiders[i + x];
            }
        }
        count = 0;
    }

    private void Update()
    {

        if(isAttackTrigger)
        {
            if(null != spiders[0]) Instantiate(caterpillar, spiders[0].transform.position + te, transform.rotation);
            isAttackTrigger = false;
            Invoke("ClearSpiders", 2f);
        }
    }
}
