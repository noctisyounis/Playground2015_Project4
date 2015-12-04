using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PanelHolderBehaviour : MonoBehaviour {


	private float xHolderOn;
	private float xHolderOffPositive;
	private float xHolderOffNegative;

	public GameObject currentPanel;
	public List<GameObject> listPanel;
	private GameObject oldPanel;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < transform.childCount; i++) {
			listPanel.Add (transform.GetChild(i).gameObject);
		}

		currentPanel = listPanel [0];

		/*yHolderOn = (Screen.height /100);
		xHolderOn = (Screen.width / 90);

		Vector2 v1 = currentPanel.transform.position;
		v1.x = xHolderOn;
		v1.y = yHolderOn;

		currentPanel.transform.localPosition = v1;*/

		xHolderOffPositive = (Screen.height *3);
		xHolderOn = Screen.height - (Screen.height / 10); 
		xHolderOffNegative = - Screen.height ;
	}

	public void switchPanel(string position)
	{
		int id = currentPanel.GetComponent<PanelTutorialBehaviour> ().id;
		id--;

		if (position == "Right") {
			if(id < (listPanel.Count-1))
			{
				oldPanel = currentPanel;
				currentPanel = listPanel[id+1];

				iTween.MoveTo(oldPanel, iTween.Hash("x",xHolderOffNegative,"time",2f));
				iTween.MoveTo(currentPanel, iTween.Hash("x",xHolderOn,"time",2f));
			}
		} else {
			if(id > 0)
			{
				oldPanel = currentPanel;
				currentPanel = listPanel[id-1];

				iTween.MoveTo(oldPanel, iTween.Hash("x",xHolderOffPositive,"time",2f));
				iTween.MoveTo(currentPanel, iTween.Hash("x",xHolderOn,"time",2f));
			}
		}

	}
}
