using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class CardHandButtonBehaviour : MonoBehaviour {

	public GameObject currentHand;
	public GameObject unitHand;
	public GameObject landHand;
	public GameObject movHand;


	public void OnClick()
	{
		if (name == "UnitButton")
		{
			if(unitHand.transform.childCount > 0)
			{
				int numberChild = currentHand.transform.childCount;
				for (int i = 0; i < numberChild; i++) {
					currentHand.transform.GetChild(0).transform.SetParent(landHand.transform);
				}
				
				numberChild = unitHand.transform.childCount;
				
				for (int i = 0; i < numberChild; i++) {
					unitHand.transform.GetChild(0).transform.SetParent(currentHand.transform);
				}
			}

		} 
		else 
		{
			if(landHand.transform.childCount > 0)
			{
				int numberChild = currentHand.transform.childCount;
				for (int i = 0; i < numberChild; i++) {
					currentHand.transform.GetChild(0).transform.SetParent(unitHand.transform);
				}

				numberChild = landHand.transform.childCount;

				for (int i = 0; i < numberChild; i++) {
					landHand.transform.GetChild(0).transform.SetParent(currentHand.transform);
				}
			}
		}
	}
}
