using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 後削除

public class ResultManager : MonoBehaviour
{
    [SerializeField] private List<MessagePresenter> _messagePresenterList = new List<MessagePresenter>();
    [SerializeField] private Image _scoreImage;
    MessagePresenter _messagePresenter;

    private List<string> _message;
    private MessageModel model = new MessageModel();
    float time = 0;
    int count = 0;
    bool start = false;
    bool end = false;
    bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        _message = model.messageList;
        //for(int i = 0; i < _resultText.Length; i++)
        //{
        //    _resultText[i].gameObject.SetActive(false);
        //}
        _scoreImage.gameObject.SetActive(false);
    }

    void ResultTextSetter()
    {
        if (!start)
        {
            if (time > 3)
            {
                start = true;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
        
        else
        {
            if(!isRunning) StartCoroutine(ResultSet());
        }
    }

    IEnumerator ResultSet()
    {
        while (!end)
        {
            isRunning = true;
            _messagePresenterList[count].SetMessage(_message[count]);
            yield return new WaitForSeconds(1.13f);
            count++;
            if (count > 4) { end = true; }
        }
        yield return new WaitForSeconds(0.15f);
        _scoreImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Title");
    }
    
    void Update()
    {
        ResultTextSetter();
    }
}
