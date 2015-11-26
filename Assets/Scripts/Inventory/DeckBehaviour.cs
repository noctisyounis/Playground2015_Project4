﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckBehaviour : MonoBehaviour {

	#region public variable
    public Sprite m_bigRange;
    public Sprite m_range;
    public Sprite m_cac;
	public List<GameObject> m_deck = new List<GameObject>();
	#endregion

	#region Main method
	// Use this for initialization
	void Start () {
		LoadDeck();
		for(int i = 0; i < m_deck.Count; i++)
	{
		/*
		-placer les cartes dans la DeckList
		-"Stocker" les meme cartes? (ex: 12 Gerriers sombres)
		-gerer le onClick? (autre method)
		*/
			GameObject Card = m_deck[i];
			Card.transform.SetParent(gameObject.transform);
	}
	
	}
	#endregion

	#region Utils
	// = method HandBehaviour
	private void LoadDeck()
	{
		// Creer une ressource "Title" -> Zone text (= title) + nbre exemplaires
		//GameObject prefab = (GameObject)Resources.Load("CardInventory", typeof(GameObject));
		m_deck.Clear();
		ReadDeckBehaviour deckList = new ReadDeckBehaviour();
        ReadXmlBehaviour cardList = new ReadXmlBehaviour(m_range, m_bigRange, m_cac);

		for (int i = 0; i < deckList.PropDeck.Count; i++) {
			int id = int.Parse(deckList.PropDeck[i].ToString());
			GameObject Card = GameObject.Instantiate((GameObject)cardList.List[id-1]);
			// why (id - 1)
			Card.transform.SetParent(gameObject.transform);
			//Card1 ? Card2 ? ... ?
			Card.name = "Card" + i.ToString();
			m_deck.Add(Card);
		}
	}
	#endregion
}
