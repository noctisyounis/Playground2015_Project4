using UnityEngine;
using System.Collections;

public class AllCategory : MonoBehaviour {
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
	}
}
