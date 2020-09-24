using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DualShockInput;

public class DialogMessageControl : MonoBehaviour
{
	[SerializeField] Stage01_Start1 start1;
	[SerializeField] Stage01_HerbGet herbGet;
	[SerializeField] Stage01_Medusa medusa;
	[SerializeField] Stage01_Stele stele;

	[SerializeField] TutorialMessageData data;

    #region ダイアログデータ（後で修正）
    [SerializeField] Text[] green_L_Text = new Text[2];
	[SerializeField] Text[] red_L_Text = new Text[2];
	[SerializeField] Text[] green_M_Text = new Text[2];
	[SerializeField] Text[] red_M_Text = new Text[2];

	[SerializeField] Image[] dialog_L_Green = new Image[2];
	[SerializeField] Image[] dialog_L_Red = new Image[2];
	[SerializeField] Image[] dialog_M_Green = new Image[2];
	[SerializeField] Image[] dialog_M_Red = new Image[2];

	GameObject temp = null;
	#endregion

	public int SetScenarioID { set { id = value; } }
	int id = 0;
	void Start()
	{
		//ShowMessage();
	}

	int count = 0;
	List<TutorialData> tempData = new List<TutorialData>();
	private void Update()
    {
        if (DSInput.PushDown(DSButton.Circle) && GameManager.Instance.GetEventState == GameManager.EventState.ScenarioEvent ||
			Input.GetKeyDown(KeyCode.Z) && GameManager.Instance.GetEventState == GameManager.EventState.ScenarioEvent)
        {
            switch (id)
			{
				case 1: tempData = start1.Message;  break;
				case 2: tempData = herbGet.Message; break;
				case 3: tempData = medusa.Message; break;
				case 4: tempData = stele.Message; break;
			}

			if(count == tempData.Count) { GameManager.Instance.EventEnd(); count = 0; temp.SetActive(false); temp = null; return; }
            if (tempData[count].balloonColor == BalloonColor.GREEN)
            {
				if(null != temp) { temp.SetActive(false); }
				switch (tempData[count].balloonSize)
                {
                    case "S": 
                    case "M":	if(tempData[count].balloonPos == "Left") {
									StartCoroutine(DialogPop(dialog_M_Green[0]));
									green_M_Text[0].text = tempData[count].message;
								}
								else if(tempData[count].balloonPos == "Right") {
									StartCoroutine(DialogPop(dialog_M_Green[1]));
									green_M_Text[1].text = tempData[count].message;
								}	break;
					case "L":	if(tempData[count].balloonPos == "Left") {
									StartCoroutine(DialogPop(dialog_L_Green[0]));
									green_L_Text[0].text = tempData[count].message;
								}
								else if(tempData[count].balloonPos == "Right") {
									StartCoroutine(DialogPop(dialog_L_Green[1]));
									green_L_Text[1].text = tempData[count].message;
								}	break;
				}
            }
            else if (tempData[count].balloonColor == BalloonColor.RED)
            {
				if (null != temp) { temp.SetActive(false); }
				switch (tempData[count].balloonSize)
                {
                    case "S": 
                    case "M":	if(tempData[count].balloonPos == "Left") {
									StartCoroutine(DialogPop(dialog_M_Red[0]));
									red_M_Text[0].text = tempData[count].message;
								}
								else if(tempData[count].balloonPos == "Right") {
									StartCoroutine(DialogPop(dialog_M_Red[1]));
									red_M_Text[1].text = tempData[count].message;
								}	break;
					case "L":	if(tempData[count].balloonPos == "Left") {
									StartCoroutine(DialogPop(dialog_L_Red[0]));
									red_L_Text[0].text = tempData[count].message;
								}
								else if(tempData[count].balloonPos == "Right") {
									StartCoroutine(DialogPop(dialog_L_Red[1]));
									red_L_Text[1].text = tempData[count].message;
								}	break;
                }
            }
            count = Mathf.Clamp(count + 1, 0, tempData.Count);
        }
    }


	IEnumerator DialogPop(Image d)
    {
		d.gameObject.SetActive(true);
		temp = d.gameObject;
		Vector2 sizeMax = new Vector2(1, 1);
		d.rectTransform.localScale = Vector2.zero;
		while(d.rectTransform.localScale.x < sizeMax.x)
        {
			d.rectTransform.localScale = Vector2.MoveTowards(d.rectTransform.localScale, sizeMax, Time.deltaTime * 2);
			yield return null;
		}
		//yield return new WaitForSeconds(1.0f);
		//d.gameObject.SetActive(false);

	}
 //   void ShowMessage()
	//{
	//	string str = "";

	//	model.Message.ForEach(entity => str += DescribeSampleMessage(entity) + "\n");
	//	text.text = str;
	//}

	//string DescribeSampleMessage(MessageDataModel_S entity)
	//{
	//	return string.Format(
	//		"{0} : {1}, {2}, {3}",
	//		entity.id,
	//		entity.name,
	//		entity.dispPos,
	//		entity.message
	//	);
	//}

}
