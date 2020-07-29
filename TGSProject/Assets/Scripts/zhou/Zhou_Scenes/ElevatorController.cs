using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    //これは入力たびに動くエレベーター　かどうか
    public bool isManual = false, isManualMove = false;


    [SerializeField] Material up, down, stop;
    [SerializeField] Material[] material;
    Material chain_rightMaterial, chain_leftMaterial;
    [SerializeField] GameObject chain_right, chain_left, floor, gear_Up, gear_down;
    [SerializeField] bool isMove, isUp;
    [SerializeField] float stopTime = 3, upSpeed = 1, rotsSpeed = 180, targetPos, targetUpPos = 1.2f, targetDownPos = -2.8f, time = 0;

    //-2.8   1.2

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = floor.GetComponent<Rigidbody>();
        targetPos = targetUpPos;
        //もし　少しランダムしかったら
        if (isManual)
        {
            time = 0;
            isMove = false;
            isUp = false;
        }
        else
        {
            time = Random.Range(0.0f, 3.0f);
        }

        upSpeed = upSpeed + Random.Range(-2.0f, 2.0f);


    }

    // Update is called once per frame
    void Update()
    {
        // if(GameManager.Instance.GetGameState == GameManager.GameState.Main)
        ElevatorMove();

    }
    //エレベーターコントロール
    void ElevatorMove()
    {



        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if (isMove)
        {
            FloorMove();
            GearRotate();


        }
        //自動式
        else if (!isMove && time <= 0 && !isManual)
        {
            ManualMove();
        }
        //入力式
        else if ((!isMove && time <= 0 && isManual && isManualMove))
        {
            ManualMove();
            isManualMove = false;
        }

    }
    void ManualMove()
    {
        if (isUp == true)
        {
            isUp = false;
            targetPos = targetDownPos;
        }
        else
        {
            isUp = true;
            targetPos = targetUpPos;

        }

        isMove = true;
        ChainMaterialMove();

    }
    //上げ下げる
    void ChainMaterialMove()
    {
        if (isUp && isMove)
        {
            chain_rightMaterial = up;
            chain_leftMaterial = down;
        }
        else if (!isUp && isMove)
        {
            chain_rightMaterial = down;
            chain_leftMaterial = up;
        }
        else if (!isMove)
        {
            chain_rightMaterial = stop;
            chain_leftMaterial = stop;
        }
        chain_right.GetComponent<SpriteRenderer>().materials[0] = chain_rightMaterial;
        chain_right.GetComponent<SpriteRenderer>().materials[0].CopyPropertiesFromMaterial(chain_rightMaterial);
        chain_left.GetComponent<SpriteRenderer>().materials[0] = chain_leftMaterial;
        chain_left.GetComponent<SpriteRenderer>().materials[0].CopyPropertiesFromMaterial(chain_leftMaterial);


    }


    //回る
    void GearRotate()
    {
        gear_Up.transform.Rotate(0, 0, this.rotsSpeed * Time.deltaTime);
        gear_down.transform.Rotate(0, 0, this.rotsSpeed * Time.deltaTime);
    }


    //装置動く
    void FloorMove()
    {
        float step = upSpeed * Time.deltaTime;
        floor.transform.position = Vector3.MoveTowards(floor.transform.position, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + targetPos, this.gameObject.transform.position.z), step);
        if (isUp && floor.transform.position.y > gameObject.transform.position.y + targetPos - 0.1f || !isUp && floor.transform.position.y < gameObject.transform.position.y + targetPos + 0.1f)
        {
            floor.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + targetPos, this.gameObject.transform.position.z);
            ; isMove = false;
            ChainMaterialMove();
            time = stopTime;

        }
    }
}
