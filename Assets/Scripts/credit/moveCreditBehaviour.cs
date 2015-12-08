using UnityEngine;
using System.Collections;

public class moveCreditBehaviour : MonoBehaviour {
    
	void Start () {
        
        iTween.MoveTo(gameObject, iTween.Hash("y", 7000, "time",250f));
        Invoke("LoadMenu",60f);
	}
    void LoadMenu()
    {
        Application.LoadLevel("Menu");
    }
}
