using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : BaseEnemy
{
    private float _hoge = 5;
    //[SerializeField]
    private float _aho = -17f;
    private float _taim = 3f;

    // Start is called before the first frame update
    void Start()
    {
        base.enemyID = EnemyType.Plant;
        _hoge += Time.deltaTime;
        _anim = GetComponent<Animator>();
        startPosition = transform.position;
    }

    private void LuisuKill()
    {
        Vector2 LuisPos = player.transform.position;
        if (GameManager.Instance.GetGameState == GameManager.GameState.Damage)
        {
            transform.position = new Vector2(LuisPos.x,
                Mathf.MoveTowards(transform.position.y, LuisPos.y + _aho, _hoge));
            GetComponent<Animator>().enabled = true;
            _taim -= Time.deltaTime;
            if(_taim <=  0)
            {
                PlayerInfoCounter.Instance.DecreaseHP();
                _taim = 0;
            }
        }
        else
        {  
            transform.position = new Vector2(LuisPos.x, transform.position.y);
            _taim = 3;
            GetComponent<Animator>().enabled = false;
            _anim.Play("Base Layer.Plant_body 03", 0, 0);
            if(GameManager.Instance.GetGameState == GameManager.GameState.Road) { transform.position = startPosition; }
        }
    }

    private void LuisEnd()
    {
        //if()
    }

    // Update is called once per frame
    void Update()
    {
        LuisuKill();
    }
}
