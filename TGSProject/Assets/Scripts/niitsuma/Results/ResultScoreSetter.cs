using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScoreSetter : MonoBehaviour
{
    [SerializeField] private List<MessagePresenter> _messagePresenterList = new List<MessagePresenter>();
    [SerializeField] private Image[] _scoreImage = new Image[4];

    private List<string> _message;
    private ResultMessageModel model = new ResultMessageModel();
    private RankSetter rankSetter = new RankSetter();
    private float time = 0;
    private int count = 0;
    private bool start = false;
    private bool end = false;
    private bool isRunning = false;

    private int rank = 0;

    void Start()
    {
        //Debug.Log(ResultManager.Instance.GetResultData.playTime);
        model.ResultDataSetter(_message, ResultManager.Instance.GetResultData);
        _message = model.messageList;
        rank = rankSetter.RankCalculation(ResultManager.Instance.GetResultData);
        for(int i = 0; i < _scoreImage.Length; i++)
        {
            _scoreImage[i].gameObject.SetActive(false);
        }
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
            if (!isRunning) StartCoroutine(ResultSet());
        }
    }

    IEnumerator ResultSet()
    {
        var time = new WaitForSeconds(1.13f);
        while (!end)
        {
            isRunning = true;
            _messagePresenterList[count].SetMessage(_message[count]);
            yield return time;
            count++;
            if (count > 4) { end = true; }
        }
        yield return new WaitForSeconds(0.15f);
        _scoreImage[rank].gameObject.SetActive(true);

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("StageSelect");
    }

    void Update()
    {
        if (null != _message)
            ResultTextSetter();
    }
}
