using UnityEngine;
using System.Collections;

public class AllCategory : MonoBehaviour {

	#region Public Variable
	
	//private ArrayList<Carte> carts;

	/*
	 * carte.type 
	 * -> Fabien
	 */

	/*
	#region Utils
	
	private void LoadDeck()
	{
		GameObject prefab = (GameObject)Resources.Load ("Card", typeof(GameObject));
		// change deck by all cards
		GameObject deck = GameObject.Find("PlayerDeck");
		GameObject Card;
		m_deck.Clear();
		for (int i = 1; i < 19; i++) 
		{
			Card = (GameObject)Instantiate(prefab);
			Card.transform.SetParent(deck.transform);
			Card.name = "Card" + i.ToString();
			m_deck.Add(Card);
		}
		Shuffle(m_deck);
	}
	
	public void Draw()
	{
		if (m_deck.Count > 0) 
		{
			GameObject Card = m_deck [0];
			m_deck.Remove (Card);
			Card.transform.SetParent (gameObject.transform);
			Card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
		}
	} 
	#endregion
	*/

	#endregion

	// 1.  through the list and display them in the game object

	// 2. simple click = drop to DeckList

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
