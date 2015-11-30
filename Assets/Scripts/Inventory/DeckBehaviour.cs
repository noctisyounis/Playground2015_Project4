using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckBehaviour : MonoBehaviour {

	#region public variable

	public static List<GameObject> m_deck = new List<GameObject>();
    public Sprite m_bigRange;
    public Sprite m_range;
    public Sprite m_cac;

	#endregion

	#region Main method
	// Use this for initialization
	void Start () {
		LoadDeck();
		for(int i = 0; i < m_deck.Count; i++)
		{
				GameObject Card = m_deck[i];
				Card.transform.SetParent(gameObject.transform);
		}
	
	}
	// Utility? OnClick? 
	void Update()
	{
		for (int i = 0; i < m_deck.Count; i++) 
		{
			GameObject Card = m_deck[i];
			Card.transform.SetParent(gameObject.transform);
		}
	}

	#endregion

	#region Utils
	// = method HandBehaviour, optimal? 
	private void LoadDeck()
	{
		// Create  resource "Title" -> Zone text (= title) + nbr copies
		m_deck.Clear();
		ReadDeckBehaviour deckList = new ReadDeckBehaviour();
		ReadXmlBehaviour cardList = new ReadXmlBehaviour("CardInventory", "CardGUILandInventory");

		for (int i = 0; i < deckList.PropDeck.Count; i++) 
		{
			int id = int.Parse(deckList.PropDeck[i].ToString());
			Debug.Log (id);
			if(id < 1000)
			{
				GameObject Card = GameObject.Instantiate((GameObject)cardList.List[id-1]);
				Card.transform.SetParent(gameObject.transform);
				Card.AddComponent<OnClickBehaviour>();
				Card.GetComponent<OnClickBehaviour>().m_container = e_containedBy.DeckList;
				Card.name = "Card" + i.ToString();
				m_deck.Add(Card);
			}
			else
			{
				GameObject Card = GameObject.Instantiate((GameObject)cardList.ListLand[id - 1001]);
				Card.transform.SetParent(gameObject.transform);
				Card.AddComponent<OnClickBehaviour>();
				Card.GetComponent<OnClickBehaviour>().m_container = e_containedBy.DeckList;
				Card.name = "Card" + i.ToString();
			}
		}
	}
	#endregion
}
