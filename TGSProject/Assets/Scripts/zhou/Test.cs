using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Test : MonoBehaviour
{

    //-------------------------------------------------------------------------------

    void Start()
    {
        DontDestroyOnLoad(gameObject);
      
    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StageMove.ReloadCurrentSchene();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StageMove.LoadNextSchene();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StageMove.LoadGameOverSchene();
        }

    }
}