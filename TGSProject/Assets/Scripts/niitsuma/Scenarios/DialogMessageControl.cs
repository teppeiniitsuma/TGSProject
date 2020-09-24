using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogMessageControl : MonoBehaviour
{
	[SerializeField] TutorialMessageData data;
	//[SerializeField] Sample model;
	[SerializeField] Text[] greenText = new Text[2];
	[SerializeField] Text[] redText = new Text[2];
	[SerializeField] Image[] dialogGreen = new Image[2];
	[SerializeField] Image[] dialogRed = new Image[2];

	
	void Start()
	{
		//ShowMessage();
	}

	int count = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
			//StartCoroutine(DialogPop(dialogGreen[count]));
            if (data.Message[count].balloonColor == BalloonColor.GREEN)
            {
				StartCoroutine(DialogPop(dialogGreen[count]));
				greenText[count].text = data.Message[count].message;
				//switch (data.Message[count].balloonSize)
				//{
				//	case "S": break;
				//	case "M": break;
				//	case "L": break;
				//}
			}
            else if (data.Message[count].balloonColor == BalloonColor.RED)
            {
				StartCoroutine(DialogPop(dialogRed[count]));
				redText[count].text = data.Message[count].message;
				//switch (data.Message[count].balloonSize)
				//{
				//    case "S": break;
				//    case "M": break;
				//    case "L": break;
				//}
			}
            //greenText[count].text = data.Message[count].message;
            count = Mathf.Clamp(count + 1, 0, greenText.Length - 1 /*data.Message.Count - 1*/);
        }
    }


	IEnumerator DialogPop(Image d)
    {
		d.gameObject.SetActive(true);
		Vector2 sizeMax = new Vector2(1, 1);
		d.rectTransform.localScale = Vector2.zero;
		while(d.rectTransform.localScale.x < sizeMax.x)
        {
			d.rectTransform.localScale = Vector2.MoveTowards(d.rectTransform.localScale, sizeMax, Time.deltaTime * 2);
			yield return null;
		}
		yield return new WaitForSeconds(2.0f);
		d.gameObject.SetActive(false);

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
