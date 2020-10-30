using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DualShockInput;

public class DialogMessageControl : MonoBehaviour
{

	[SerializeField] private StageType stageType;

    #region シナリオデータ
	// ステージ１
    [SerializeField] Stage01_Start1  start1;
	[SerializeField] Stage01_HerbGet herbGet;
	[SerializeField] Stage01_Medusa  medusa;
	[SerializeField] Stage01_Stele   stele;

	// ステージ２
	[SerializeField] Stage02_Start start2;
	[SerializeField] Stage02_SwitchLift switchLift;
	[SerializeField] Stage02_NumberLock numberLock;
	[SerializeField] Stage02_BeforeBossF bossF;
	[SerializeField] Stage02_BeforeBossT1 bossT1;

	// ボス戦終了後
	[SerializeField] Stage02_BeforeBossT2 bossT2;

	// エンディング
	[SerializeField] Stage02_NormalEnd1 end1;
	[SerializeField] Stage02_NormalEnd2 end2;
	[SerializeField] Stage02_TrueEnd trueEnd;

	#endregion

	#region ダイアログデータ（後で修正）
	[SerializeField] Text[] green_L_Text = new Text[2];
	[SerializeField] Text[] red_L_Text   = new Text[2];
	[SerializeField] Text[] green_M_Text = new Text[2];
	[SerializeField] Text[] red_M_Text   = new Text[2];
	[SerializeField] Text[] green_S_Text = new Text[2];
	[SerializeField] Text[] red_S_Text   = new Text[2];

	[SerializeField] Image[] dialog_L_Green = new Image[2];
	[SerializeField] Image[] dialog_L_Red   = new Image[2];
	[SerializeField] Image[] dialog_M_Green = new Image[2];
	[SerializeField] Image[] dialog_M_Red   = new Image[2];
	[SerializeField] Image[] dialog_S_Green = new Image[2];
	[SerializeField] Image[] dialog_S_Red   = new Image[2];

	GameObject temp = null;
	#endregion

	public int SetScenarioID { set { id = value; } }
	int id = 0;

	List<TutorialData> tempData = new List<TutorialData>();
	int count = 0;

	private enum StageType
    {
		Stage1,
		Stage2, 
		Boss,
		End,
    } 

	void ScenarioRoad(StageType type)
    {
		if(type == StageType.Stage1)
        {
			switch (id)
			{
				case 1: tempData = start1.Message; break;
				case 2: tempData = herbGet.Message; break;
				case 3: tempData = medusa.Message; break;
				case 4: tempData = stele.Message; break;
			}
		}
		else if(type == StageType.Stage2)
        {
			switch (id)
			{
				case 1: tempData = start2.Message; break;
				case 2: tempData = switchLift.Message; break;
				case 3: tempData = numberLock.Message; break;
				case 4: tempData = bossF.Message; break;
				case 5: tempData = bossT1.Message; break;
			}
		}
		else if(type == StageType.Boss)
        {
			switch (id)
			{
				case 1: tempData = bossT2.Message; break;
			}
		}
		else if(type == StageType.End)
        {
			switch (id)
			{
				case 1: tempData = end1.Message; break;
				case 2: tempData = end2.Message; break;
				case 3: tempData = trueEnd.Message; break;
			}
		}
    }
	public void DialogView()
    {
		ScenarioRoad(stageType);
		if (tempData[count].balloonColor == BalloonColor.GREEN)
		{
			if (null != temp) { temp.SetActive(false); }
			switch (tempData[count].balloonSize)
			{
				case "S":
					if (tempData[count].balloonPos == "Left")
					{
						StartCoroutine(DialogPop(dialog_S_Green[0]));
						green_S_Text[0].text = tempData[count].message;
					}
					else if (tempData[count].balloonPos == "Right")
					{
						StartCoroutine(DialogPop(dialog_S_Green[1]));
						green_S_Text[1].text = tempData[count].message;
					}
					break;
				case "M":
					if (tempData[count].balloonPos == "Left")
					{
						StartCoroutine(DialogPop(dialog_M_Green[0]));
						green_M_Text[0].text = tempData[count].message;
					}
					else if (tempData[count].balloonPos == "Right")
					{
						StartCoroutine(DialogPop(dialog_M_Green[1]));
						green_M_Text[1].text = tempData[count].message;
					}
					break;
				case "L":
					if (tempData[count].balloonPos == "Left")
					{
						StartCoroutine(DialogPop(dialog_L_Green[0]));
						green_L_Text[0].text = tempData[count].message;
					}
					else if (tempData[count].balloonPos == "Right")
					{
						StartCoroutine(DialogPop(dialog_L_Green[1]));
						green_L_Text[1].text = tempData[count].message;
					}
					break;
			}
		}
		else if (tempData[count].balloonColor == BalloonColor.RED)
		{
			if (null != temp) { temp.SetActive(false); }
			switch (tempData[count].balloonSize)
			{
				case "S":
					if (tempData[count].balloonPos == "Left")
					{
						StartCoroutine(DialogPop(dialog_S_Red[0]));
						red_S_Text[0].text = tempData[count].message;
					}
					else if (tempData[count].balloonPos == "Right")
					{
						StartCoroutine(DialogPop(dialog_S_Red[1]));
						red_S_Text[1].text = tempData[count].message;
					}
					break;
				case "M":
					if (tempData[count].balloonPos == "Left")
					{
						StartCoroutine(DialogPop(dialog_M_Red[0]));
						red_M_Text[0].text = tempData[count].message;
					}
					else if (tempData[count].balloonPos == "Right")
					{
						StartCoroutine(DialogPop(dialog_M_Red[1]));
						red_M_Text[1].text = tempData[count].message;
					}
					break;
				case "L":
					if (tempData[count].balloonPos == "Left")
					{
						StartCoroutine(DialogPop(dialog_L_Red[0]));
						red_L_Text[0].text = tempData[count].message;
					}
					else if (tempData[count].balloonPos == "Right")
					{
						StartCoroutine(DialogPop(dialog_L_Red[1]));
						red_L_Text[1].text = tempData[count].message;
					}
					break;
			}
		}
		count = Mathf.Clamp(count + 1, 0, tempData.Count);
	}
	private void Update()
    {
        if (DSInput.PushDown(DSButton.Circle) && GameManager.Instance.GetEventState == GameManager.EventState.ScenarioEvent ||
			DSInput.Push(DSButton.L1) && GameManager.Instance.GetEventState == GameManager.EventState.ScenarioEvent)
        {
			if(count == tempData.Count) { GameManager.Instance.EventEnd(); count = 0; temp.SetActive(false); temp = null; return; }
            if (tempData[count].balloonColor == BalloonColor.GREEN)
            {
				if(null != temp) { temp.SetActive(false); }
				switch (tempData[count].balloonSize)
                {
                    case "S": if(tempData[count].balloonPos == "Left") {
									StartCoroutine(DialogPop(dialog_S_Green[0]));
									green_S_Text[0].text = tempData[count].message;
								}
								else if(tempData[count].balloonPos == "Right") {
									StartCoroutine(DialogPop(dialog_S_Green[1]));
									green_S_Text[1].text = tempData[count].message;
								}	break;
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
                    case "S": if(tempData[count].balloonPos == "Left") {
									StartCoroutine(DialogPop(dialog_S_Red[0]));
									red_S_Text[0].text = tempData[count].message;
								}
								else if(tempData[count].balloonPos == "Right") {
									StartCoroutine(DialogPop(dialog_S_Red[1]));
									red_S_Text[1].text = tempData[count].message;
								}	break;
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

	}

}
