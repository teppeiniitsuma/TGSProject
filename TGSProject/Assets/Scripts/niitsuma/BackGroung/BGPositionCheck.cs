using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGPositionCheck : MonoBehaviour
{
    [SerializeField ,Range(1, 3)] private int _number = 1;
    private BGController bg;
    private int width = 28;

    void Check()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.EventStart)
        {
            if (transform.position.x + width < bg.Camera.position.x)
            {
                
                bg.MoveSwitch = true;
                bg.SetNumber(_number);
            }
        }
        
    }

    private void Start()
    {
        bg = transform.parent.gameObject.GetComponent<BGController>();
    }
    private void Update()
    {
        Check();
    }
}
