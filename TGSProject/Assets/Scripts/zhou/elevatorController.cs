using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class elevatorController : MonoBehaviour
{
    [SerializeField] Material up, down, stop;
    [SerializeField] Material []material ;
    Material chain_rightMaterial, chain_leftMaterial;
    [SerializeField] GameObject chain_right, chain_left, floor, gear_Up, gear_down;
    [SerializeField] bool isMove, isUp;
    [SerializeField] float stopTime = 3, upSpeed = 1, rotsSpeed = 180, targetPos,targetUpPos = 1.2f, targetDownPos = -2.8f,time=0;

    //-2.8   1.2

    // Start is called before the first frame update
    void Start()
    {
        targetPos = targetUpPos;
    }

    // Update is called once per frame
    void Update()
    {
        ElevatorMove();
    }
    //エレベーターコントロール
    void ElevatorMove() {



        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if (isMove)
        {
            FloorMove();
            GearRotate();


        }
        else if (!isMove && time <= 0)
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
            ChainMaterialMove();
            isMove = true;
        }

       

        
    }

    //上げ下げる
    void ChainMaterialMove() {
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
        else {
            chain_rightMaterial = stop;
            chain_leftMaterial = stop;
        }
            chain_right.GetComponent<SpriteRenderer>().materials[0] = chain_rightMaterial;
            chain_right.GetComponent<SpriteRenderer>().materials[0].CopyPropertiesFromMaterial(chain_rightMaterial);
            chain_left.GetComponent<SpriteRenderer>().materials[0] = chain_leftMaterial;
            chain_left.GetComponent<SpriteRenderer>().materials[0].CopyPropertiesFromMaterial(chain_leftMaterial);
      
        
        }


    //回る
    void GearRotate() {
        gear_Up.transform.Rotate(0, 0, this.rotsSpeed*Time.deltaTime);
        gear_down.transform.Rotate(0, 0, this.rotsSpeed * Time.deltaTime);
    }


    //装置動く
    void FloorMove() {
        float step = upSpeed * Time.deltaTime;
        floor.transform.position = Vector3.MoveTowards(floor.transform.position, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+targetPos, this.gameObject.transform.position.z), step);
        if ( isUp&&floor.transform.position.y>gameObject.transform.position.y+targetPos-0.1f|| !isUp&& floor.transform.position.y <gameObject.transform.position.y + targetPos+0.1f){
            isMove = false;
            time = stopTime;
            ChainMaterialMove();
        }
    }
}
