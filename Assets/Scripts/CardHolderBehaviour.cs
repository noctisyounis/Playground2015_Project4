﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardHolderBehaviour :MonoBehaviour {

	private GameObject currentCard;
	private GameObject CardUI;

	public void setNewCardUnit(CardUnitBehaviour cardToAdd)
	{
		if (currentCard != null)
			this.removeCard ();

		CardUI = (GameObject)Resources.Load("CardGUIUnit", typeof(GameObject));
		CardUnitBehaviour script = CardUI.GetComponent<CardUnitBehaviour>();
		
		script.copy (cardToAdd);

		getGoodTypePrefab (script.m_type, script);

		currentCard = GameObject.Instantiate((GameObject)CardUI);
	
		currentCard.transform.SetParent (transform);
		currentCard.transform.localScale = Vector3.one;

	}

	public void setNewCarUnitFromTokken(TokkenBehaviour c1)
	{
		if (currentCard != null)
			this.removeCard ();

		GameObject CardUI = (GameObject)Resources.Load("CardGUIUnit", typeof(GameObject));
		CardUnitBehaviour script = CardUI.GetComponent<CardUnitBehaviour>();

		script.m_ATK_Down.GetComponent<Text>().text = c1.m_ATK_Down.GetComponent<Text>().text;
		script.m_ATK_Up.GetComponent<Text>().text = c1.m_ATK_Up.GetComponent<Text>().text;
		script.m_ATK_Right.GetComponent<Text>().text = c1.m_ATK_Right.GetComponent<Text>().text;
		script.m_ATK_Left.GetComponent<Text>().text = c1.m_ATK_Left.GetComponent<Text>().text;

		script.m_Speed.GetComponent<Text> ().text = c1.m_speed.GetComponent<Text> ().text;
		script.m_HP.GetComponent<Text> ().text = c1.m_hp.GetComponent<Text> ().text;

		script.m_name.GetComponent<Text> ().text = c1.name;
		script.m_Description1.GetComponent<Text> ().text = c1.descriptionL1;
		script.m_Description2.GetComponent<Text> ().text = c1.descriptionL2;
		script.m_Description3.GetComponent<Text> ().text = c1.descriptionL3;

		script.m_type = c1.type;

		getGoodTypePrefab (script.m_type, script);

		currentCard = GameObject.Instantiate((GameObject)CardUI);

		
		currentCard.transform.SetParent (transform);
		currentCard.transform.localScale = Vector3.one;

	}

	public void getGoodTypePrefab(string type, CardUnitBehaviour script)
	{
		switch (type)
		{
		case "BigRange":
			CardUI.GetComponent<Image>().sprite = script.m_bigRange;
			break;
		case "Range":
			CardUI.GetComponent<Image>().sprite = script.m_range;
			break;
		case "Close":
			CardUI.GetComponent<Image>().sprite = script.m_cac;
			break;
		}
	}

	public void removeCard()
	{
		Destroy (currentCard);
	}
}
