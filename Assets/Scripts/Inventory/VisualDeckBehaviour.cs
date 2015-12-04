using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VisualDeckBehaviour : MonoBehaviour {

	public GameObject m_cac;
	public GameObject m_range;
	public GameObject m_bigRange;
	public GameObject m_wood;
	public GameObject m_plain;
	public GameObject m_mountain;
	public GameObject m_swamp;
	public GameObject m_ruin;
	
	void Start () 
	{
		InvokeRepeating("loadVisual",0.5f,0.5f);
	}

	public void loadVisual()
	{
		int m_nbCac = 0;
		int m_nbRange = 0;
		int m_nbBigRange = 0;
		int m_nbWood = 0;
		int m_nbPlain = 0;
		int m_nbMountain = 0;
		int m_nbSwamp = 0;
		int m_nbRuin = 0;

		for (int i = 0; i < DeckBehaviour.m_deck.Count; i++) {
			bool isUnit = DeckBehaviour.m_deck[i] != null && DeckBehaviour.m_deck[i].GetComponent<CardUnitBehaviour>()!= null;

			if (isUnit) 
			{
				string deckType = DeckBehaviour.m_deck[i].GetComponent<CardUnitBehaviour>().m_type;
//				switch (DeckBehaviour.m_deck[i].GetComponent<CardUnitBehaviour>().m_type) 
				switch (deckType) 
				{
				case "Close":
					m_nbCac +=1;
					break;
				case "Range":
					m_nbRange +=1;
					break;
				case "BigRange":
					m_nbBigRange +=1;
					break;
//				case null:
//					continue;
//					break;
					
				default:
					break;
				}
				
			}
			
			if (!isUnit) 
			{
				if (DeckBehaviour.m_deck[i] != null) 
				{
					string deckType = DeckBehaviour.m_deck[i].GetComponent<CardGroundBehaviour>().m_type;
	//				switch(DeckBehaviour.m_deck[i].GetComponent<CardGroundBehaviour>().m_type)
					switch (deckType) 
					{
					case "Forest":
						m_nbWood +=1;
						break;
					case "Swamp":
						m_nbSwamp +=1;
						break;
					case "Mountain":
						m_nbMountain +=1;
						break;
					case "Ruin":
						m_nbRuin +=1;
						break;
						
					case "Plain":
						m_nbPlain +=1;	
						break;
//					case null:
//						continue;
//						break;
					default:
						break;
					}
				}
			}		
		}
		m_cac.GetComponent<Text>().text = "" + m_nbCac;
		m_range.GetComponent<Text>().text = "" + m_nbRange;
		m_bigRange.GetComponent<Text>().text = "" + m_nbBigRange;
		m_mountain.GetComponent<Text>().text = "" + m_nbMountain;
		m_swamp.GetComponent<Text>().text = "" + m_nbSwamp;
		m_ruin.GetComponent<Text>().text = "" + m_nbRuin;
		m_plain.GetComponent<Text>().text = "" + m_nbPlain;
		m_wood.GetComponent<Text>().text = "" + m_nbWood;
	}
}
