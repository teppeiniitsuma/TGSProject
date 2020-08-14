using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySpiderCounter : MonoBehaviour
{
    private int count = 0;
    private const int dispSpiders = 4; // 画面内に存在できる蜘蛛の数
    [SerializeField] private Transform[] spiders = new Transform[dispSpiders];
    [SerializeField] private GameObject caterpillar;

    Vector3 te = new Vector3(0, 4.5f, 0);
    bool t = false;

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
        GameManager.Instance.SetGameState(GameManager.GameState.Main);
        count = 0;
    }
    private void Update()
    {
        Debug.Log(count);
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameManager.Instance.SetGameState(GameManager.GameState.Event);
            t = true;
        }

        if(t)
        {
            if(null != spiders[0])
                Instantiate(caterpillar, spiders[0].transform.position + te, transform.rotation);
            //for(int i = 0; i < spiders.Length; i++)
            //{
            //    if(null != spiders[i])
            //        Instantiate(caterpillar, spiders[i].transform.position + te, transform.rotation);
            //}
            t = false;
            Invoke("ClearSpiders", 2f);
        }
    }
}
