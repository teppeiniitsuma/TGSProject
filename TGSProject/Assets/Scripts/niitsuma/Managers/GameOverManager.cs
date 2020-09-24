using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || DualShockInput.DSInput.PushDown(DualShockInput.DSButton.Cross))
            SceneManager.LoadScene("Title");
    }
}
