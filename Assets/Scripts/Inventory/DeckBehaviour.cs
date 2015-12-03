using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckBehaviour : MonoBehaviour {

	#region public variable

	public static List<GameObject> m_deck = new List<GameObject>();

	#endregion

	#region Main method
	void Start () {
		LoadDeck();
		for(int i = 0; i < m_deck.Count; i++)
		{
				GameObject Card = m_deck[i];
				if (Card != null) 
				{
					Card.transform.SetParent(gameObject.transform);
					Card.GetComponent<RectTransform>().localScale = Vector3.one;
				}
		}
	
	}

	// Use when we add card into deck

	void Update()
	{
		for (int i = 0; i < m_deck.Count; i++) 
		{
			GameObject Card = m_deck[i];
			if (Card != null) 
			{
				Card.transform.SetParent(gameObject.transform);
			}
		}
	}

	#endregion

	#region Utils
	public void LoadDeck()
	{
		m_deck.Clear();
		ReadDeckBehaviour deckList = new ReadDeckBehaviour();
		ReadXmlBehaviour cardList = new ReadXmlBehaviour("CardInventory", "CardGUILandInventory");

		for (int i = 0; i < deckList.PropDeck.Count; i++) 
		{
			int id = int.Parse(deckList.PropDeck[i].ToString());
			if(id < 1000)
			{
				GameObject Card = GameObject.Instantiate((GameObject)cardList.List[id-1]);
				Card.GetComponent<OnClickBehaviour>().m_container = e_containedBy.DeckList;
				Card.name = "Card" + i.ToString();
				m_deck.Add(Card);
			}
			else
			{
				GameObject Card = GameObject.Instantiate((GameObject)cardList.ListLand[id - 1001]);
				Card.GetComponent<OnClickBehaviour>().m_container = e_containedBy.DeckList;
				Card.name = "Card" + i.ToString();
				m_deck.Add(Card);

			}
		}
	}
	#endregion
}
