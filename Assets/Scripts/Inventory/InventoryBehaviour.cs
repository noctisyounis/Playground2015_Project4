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
			Card.GetComponent<RectTransform>().localScale = Vector3.one;
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
			Card.AddComponent<OnClickBehaviour>();
			Card.GetComponent<OnClickBehaviour>().m_container = e_containedBy.Inventory;
			Card.name = "Card" + i.ToString();
			m_listCards.Add(Card);
		}
		for (int i = 0; i < cardList.ListLand.Count; i++) {
			GameObject CardLand = GameObject.Instantiate((GameObject)cardList.ListLand[i]);
			CardLand.transform.SetParent(gameObject.transform);
			CardLand.AddComponent<OnClickBehaviour>();
			CardLand.GetComponent<OnClickBehaviour>().m_container = e_containedBy.Inventory;
			CardLand.name = "Card" + i.ToString();
			m_listCards.Add(CardLand);
		}
	}
	#endregion
}
