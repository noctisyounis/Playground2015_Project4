using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckBehaviour : MonoBehaviour {

	#region public variable
<<<<<<< HEAD

	public static List<GameObject> m_deck = new List<GameObject>();
    public Sprite m_bigRange;
    public Sprite m_range;
    public Sprite m_cac;

=======
    public Sprite m_bigRange;
    public Sprite m_range;
    public Sprite m_cac;
	public List<GameObject> m_deck = new List<GameObject>();
>>>>>>> origin/master
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
		GameObject prefab = (GameObject)Resources.Load("CardInventory", typeof(GameObject));
		m_deck.Clear();
		ReadDeckBehaviour deckList = new ReadDeckBehaviour();

        ReadXmlBehaviour cardList = new ReadXmlBehaviour(m_range, m_bigRange, m_cac,"CardInventory");

		for (int i = 0; i < deckList.PropDeck.Count; i++) 
		{
			int id = int.Parse(deckList.PropDeck[i].ToString());
			GameObject Card = GameObject.Instantiate((GameObject)cardList.List[id-1]);
			Card.transform.SetParent(gameObject.transform);
			/////////
			Card.AddComponent<OnClickBehaviour>();
			Card.GetComponent<OnClickBehaviour>().m_container = e_containedBy.DeckList;

			/////////
			Card.name = "Card" + i.ToString();
			m_deck.Add(Card);
		}
	}
	#endregion
}
