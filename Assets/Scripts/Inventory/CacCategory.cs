using UnityEngine;
using System.Collections;

public class CacCategory : InventoryBehaviour 
{
	public GameObject m_Inventory;

	void Start()
	{
		m_Inventory = GameObject.FindObjectOfType<InventoryBehaviour>().gameObject;
	}

	public void OnMouseUp()
	{
		for (int i = 0; i < InventoryBehaviour.m_storage.transform.childCount; i++) {
			InventoryBehaviour.m_storage.transform.GetChild(0).transform.SetParent(m_Inventory.transform);
		}
		for(int i = 0; i < m_listCards.Count; i++)
		{
			GameObject Card = m_listCards[i];
			if (Card.GetComponent<CardBehaviour>().m_id != 1) {
				Card.transform.SetParent(InventoryBehaviour.m_storage.transform);
			}
		}
	}
}
