﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Example : MonoBehaviour
{
	[SerializeField] MstItems mstItems;
	[SerializeField] Sample model;
	[SerializeField] Text text;

	void Start()
	{
		//ShowItems();
		ShowMessage();
	}


	void ShowMessage()
    {
		string str = "";

		model.Message.ForEach(entity => str += DescribeSampleMessage(entity) + "\n");
		text.text = str;
	}
	void ShowItems()
	{
		string str = "";

		mstItems.Entities
			.ForEach(entity => str += DescribeMstItemEntity(entity) + "\n");

		text.text = str;
	}

	string DescribeSampleMessage(MessageDataModel_S entity)
	{
		return string.Format(
			"{0} : {1}, {2}, {3}",
			entity.id,
			entity.name,
			entity.dispPos,
			entity.message
		);
	}

	string DescribeMstItemEntity(MstItemEntity entity)
	{
		return string.Format(
			"{0} : {1}, {2}, {3}, {4}, {5}",
			entity.id,
			entity.name,
			entity.price,
			entity.isNotForSale,
			entity.rate,
			entity.category
		);
	}
}

