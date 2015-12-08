using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class buttonTutorialBehaviour : MonoBehaviour {

	public GameObject panelMain;
	public string type;

	void FixedUpdate()
	{
		int id = panelMain.GetComponent<PanelHolderBehaviour>().currentPanel.GetComponent<PanelTutorialBehaviour> ().id;
		if (type == "Right") 
		{
			if (id == panelMain.GetComponent<PanelHolderBehaviour>().listPanel.Count) 
			{
				gameObject.GetComponent<Button>().interactable = false;
			}
			else 
			{
				gameObject.GetComponent<Button>().interactable = true;
			}
		}
		if (type == "Left") 
		{
			if (id == 1) 
			{
				gameObject.GetComponent<Button>().interactable = false;
			}
			else 
			{
				gameObject.GetComponent<Button>().interactable = true;
			}
		}
	}

	public void Onclick()
	{
		panelMain.GetComponent<PanelHolderBehaviour> ().switchPanel (type);
		GetComponent<AudioSource>().Play();
	}

}
