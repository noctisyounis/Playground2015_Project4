using UnityEngine;
using System.Collections;

public class LandsCategory : InventoryBehaviour {

	public GameObject m_Inventory;
	
	void Start()
	{
		m_Inventory = GameObject.FindObjectOfType<InventoryBehaviour>().gameObject;
	}
	
	public void OnMouseUp()
	{
		int j = InventoryBehaviour.m_storage.transform.childCount;
		for (int i = 0; i < j; i++) 
		{
			InventoryBehaviour.m_storage.transform.GetChild(0).transform.SetParent(m_Inventory.transform);
		}
		for(int i = 0; i < m_listCards.Count; i++)
		{
			GameObject Card = m_listCards[i];
			if (Card.GetComponent<CardBehaviour>().m_id < 1000 ) {
				Card.transform.SetParent(InventoryBehaviour.m_storage.transform);
			}
		}
	}
}
