using UnityEngine;
using System.Collections;

public class moveCreditBehaviour : MonoBehaviour {
    
	void Start () {
        
        iTween.MoveTo(gameObject, iTween.Hash("y", 5000, "time",300f));
        Invoke("LoadMenu",60f);
	}
    void LoadMenu()
    {
        Application.LoadLevel("Menu");
    }
}
