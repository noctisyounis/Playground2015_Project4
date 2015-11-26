using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryBehaviour : MonoBehaviour 
{
	#region Public variable
    public Sprite m_bigRange;
    public Sprite m_range;
    public Sprite m_cac;
	public List<GameObject> m_listCards = new List<GameObject>();


	#endregion

	#region Main method
	void Start () {
	
	LoadDeck();
	for(int i = 0; i < m_listCards.Count; i++)
		{
			GameObject Card = m_listCards[i];
			Card.transform.SetParent(gameObject.transform);
		}
		 
	}

	#endregion

	#region Utils
	private void LoadDeck()
	{
		// WARNING actually player has all cards access /!\

		//create prefab carteInventary
//		GameObject prefab = (GameObject)Resources.Load("CardInventory", typeof(GameObject));
		m_listCards.Clear();
		// to know all cards unlock
		// ReadDeckBehaviour deckList = new ReadDeckBehaviour();
        ReadXmlBehaviour cardList = new ReadXmlBehaviour(m_range, m_bigRange, m_cac);

		// OK? /!\
		for (int i = 0; i < cardList.List.Count ; i++) {
			GameObject Card = GameObject.Instantiate((GameObject)cardList.List[i]);
			// Cette étape sert a transformé le prefab en GameObject
			Card.transform.SetParent(gameObject.transform);
//			Card.AddComponent<OnClickBehaviour>();
//			Card.m_container = e_containedBy.Inventory;
			Card.name = "Card" + i.ToString();
			m_listCards.Add(Card);
		}
	}
	#endregion
}
