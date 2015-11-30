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
	
		LoadListCards();
	for(int i = 0; i < m_listCards.Count; i++)
		{
			GameObject Card = m_listCards[i];
			Card.transform.SetParent(gameObject.transform);
		}
		 
	}

	#endregion

	#region Utils
	private void LoadListCards()
	{
		// WARNING actually player has all cards access /!\
		m_listCards.Clear();
		// to know all cards unlock
		// ReadDeckBehaviour deckList = new ReadDeckBehaviour();

		ReadXmlBehaviour cardList = new ReadXmlBehaviour( "CardInventory","CardGUILandInventory");

		for (int i = 0; i < cardList.List.Count ; i++) {

			GameObject Card = GameObject.Instantiate((GameObject)cardList.List[i]);
			// Cette étape sert a transformé le prefab en GameObject
			Card.transform.SetParent(gameObject.transform);
			/////////
			Card.AddComponent<OnClickBehaviour>();
			Card.GetComponent<OnClickBehaviour>().m_container = e_containedBy.Inventory;

			/////////
			Card.name = "Card" + i.ToString();
			m_listCards.Add(Card);

			// and 
			GameObject CardLand = GameObject.Instantiate((GameObject)cardList.ListLand[i]);
			CardLand.transform.SetParent(gameObject.transform);

			/**

						/!\ 
							- Modifier la taille! 
							- trier les cartes (unit/land/***) 

						/!\
	
			 */
		}
	}
	#endregion
}
