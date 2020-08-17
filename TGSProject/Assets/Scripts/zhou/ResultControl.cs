using UnityEngine;
using DualShockInput;


public class ResultControl : MonoBehaviour
{

    [SerializeField] private GameObject rigth, stageBG,system;
    [SerializeField] private GameObject[] stageImege1;
    [SerializeField] private GameObject[] stageImege2;
    [SerializeField] private GameObject[] stageName;
    // isPlayerOperational
    [SerializeField] private bool isPlayerOperational, SceneMove;
    //  rigthPos
    [SerializeField] private bool isTitle=true;
    // 
    [SerializeField] private int i;

    // Start is called before the first frame update
    void Start()
    {
        stageImege2[(i+1)%2].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0);
        //Rigth  start Pos
        rigth.GetComponent<Transform>().position = new Vector3(
            stageImege1[0].GetComponent<Transform>().position.x + 1.2f,
             stageImege1[0].GetComponent<Transform>().position.y + 2.0f,
             rigth.GetComponent<Transform>().position.z
            );

        system.GetComponent<Transform>().position = new Vector3(
          stageImege1[0].GetComponent<Transform>().position.x  ,
           stageImege1[0].GetComponent<Transform>().position.y ,
           system.GetComponent<Transform>().position.z
          );
        isPlayerOperational = true;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerOperational();
        ImegeMove();
        stageBGMove();

    }/// <summary>
    /// 入力式
    /// </summary>
    private void PlayerOperational()
    {
        float KeyVertical = Input.GetAxis("Horizontal");
       // Debug.Log(KeyVertical);

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)|| KeyVertical!=0) && isPlayerOperational)
        {
            i++;
            i = i % 2;
        //    Debug.Log("stage" + i + 1);
            isPlayerOperational = false;
        }
        //✖
        if (DSInput.PushDown(DSButton.Cross) || Input.GetKeyDown(KeyCode.X))
        {
            isPlayerOperational = false;
            isTitle = true;
            SceneMove = true;
        }
        //〇
        if (DSInput.PushDown(DSButton.Circle) || Input.GetKeyDown(KeyCode.Space) && isPlayerOperational)
        {
            isPlayerOperational = false;
            isTitle = false;
            SceneMove = true; 
        }
    }
    /// <summary>
    /// 選択する時の処理
    /// </summary>
    private void ImegeMove()
    {
        if (!isPlayerOperational)
        {
            stageImege2[i].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, stageImege2[i].GetComponent<SpriteRenderer>().color.a + Time.deltaTime);
            int a = (i + 1) % 2;
            stageImege2[a].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, stageImege2[a].GetComponent<SpriteRenderer>().color.a - Time.deltaTime);
             rigth.GetComponent<Transform>().position = new Vector3(
            stageImege1[i].GetComponent<Transform>().position.x + 1.2f,
             stageImege1[i].GetComponent<Transform>().position.y + 2.0f,
             rigth.GetComponent<Transform>().position.z
            );

            system.GetComponent<Transform>().position = new Vector3(
         stageImege1[i].GetComponent<Transform>().position.x,
          stageImege1[i].GetComponent<Transform>().position.y,
          system.GetComponent<Transform>().position.z
         );
            if (stageImege2[i].GetComponent<SpriteRenderer>().color.a >= 1.0f)
            {
                isPlayerOperational = true;
            }
            //
            //
        }
    }
    /// <summary>
    ///暗転
    /// </summary>
    private void stageBGMove()
    {
        if (SceneMove) {
            //Debug.Log("ステージまだセットしてません。");
            stageBG.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, stageBG.GetComponent<SpriteRenderer>().color.a + Time.deltaTime);
            if (stageBG.GetComponent<SpriteRenderer>().color.a >= 1.0f)
            {
                if (isTitle)
                {
                    StageConsole.MyLoadScene(StageConsole.MyScene.Title);
                }
                else if (i == 0)
                {
                    StageConsole.MyLoadScene(StageConsole.MyScene.Stage1);
                }
                else if (i == 1)
                {
                    StageConsole.MyLoadScene(StageConsole.MyScene.Stage2);
                }

            }
        }
        
    }
}
