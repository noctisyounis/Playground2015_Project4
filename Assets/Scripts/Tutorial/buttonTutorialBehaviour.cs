using UnityEngine;
using System.Collections;

public class buttonTutorialBehaviour : MonoBehaviour {

	public GameObject panelMain;
	public string type;

	public void Onclick()
	{
		panelMain.GetComponent<PanelHolderBehaviour> ().switchPanel (type);
	}
}
