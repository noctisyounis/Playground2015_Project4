﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardHolderBehaviour :MonoBehaviour {

	private GameObject currentCard;
	private GameObject CardUI;
	public GameObject CardViewer;

	public void setNewCardUnit(CardUnitBehaviour cardToAdd)
	{
		if (currentCard != null)
			this.removeCard ();

		CardViewer.GetComponent<CardViewerBehaviour> ().setAllyTexture ();

		CardUI = (GameObject)Resources.Load("CardGUIUnit", typeof(GameObject));
		CardUnitBehaviour script = CardUI.GetComponent<CardUnitBehaviour>();
		
		script.copy (cardToAdd);

		getGoodTypePrefabUnit (script.m_type, script);

		currentCard = GameObject.Instantiate((GameObject)CardUI);
	


		currentCard.transform.SetParent (transform);
		currentCard.transform.localScale = Vector3.one;
	}

	public void setNewCarUnitFromTokken(TokkenBehaviour c1)
	{
		if (currentCard != null)
			this.removeCard ();

		CardUI = (GameObject)Resources.Load("CardGUIUnit", typeof(GameObject));
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

		getGoodTypePrefabUnit (script.m_type, script);

		currentCard = GameObject.Instantiate((GameObject)CardUI);

		if (c1.m_playedBy == TokkenBehaviour.Player.Player1) {
			CardViewer.GetComponent<CardViewerBehaviour> ().setAllyTexture ();
		} else {
			CardViewer.GetComponent<CardViewerBehaviour> ().setEnnemyTexture();
		}

		currentCard.transform.SetParent (transform);
		currentCard.transform.localScale = Vector3.one;

	}

	public void setNewCardLandFromCard(CardGroundBehaviour CGB)
	{
		if (currentCard != null)
			this.removeCard ();

		CardViewer.GetComponent<CardViewerBehaviour> ().setAllyTexture ();
		
		CardUI = (GameObject)Resources.Load("CardGUILand", typeof(GameObject));
		CardGroundBehaviour script = CardUI.GetComponent<CardGroundBehaviour>();

		script.Copy (CGB);

		getGoodTypePrefabLand (script.m_type, script);


		currentCard = GameObject.Instantiate((GameObject)CardUI);
		
		currentCard.transform.SetParent (transform);
		currentCard.transform.localScale = Vector3.one;
	}
	
	public void getGoodTypePrefabLand(string type, CardGroundBehaviour scriptLand)
	{
		if (scriptLand != null) 
		{
			switch (type) {
			case "Forest":
				CardUI.GetComponent<Image> ().sprite = scriptLand.m_forest;
				break;
			case "Mountain":
				CardUI.GetComponent<Image> ().sprite = scriptLand.m_mountain;
				break;
			case "Plain":
				CardUI.GetComponent<Image> ().sprite = scriptLand.m_plain;
				break;
			case "Ruin":
				CardUI.GetComponent<Image> ().sprite = scriptLand.m_ruin;
				break;
			case "Swamp":
				CardUI.GetComponent<Image> ().sprite = scriptLand.m_swamp;
				break;
			}
		}
	}


	public void getGoodTypePrefabUnit(string type, CardUnitBehaviour script)
	{
		if (script != null) 
		{
			switch (type) {
			case "BigRange":
				CardUI.GetComponent<Image> ().sprite = script.m_bigRange;
				break;
			case "Range":
				CardUI.GetComponent<Image> ().sprite = script.m_range;
				break;
			case "Close":
				CardUI.GetComponent<Image> ().sprite = script.m_cac;
				break;
			}
		}
	}

	public void removeCard()
	{
		Destroy (currentCard);
		CardViewer.GetComponent<CardViewerBehaviour> ().setBaseTexture();
	}
}
