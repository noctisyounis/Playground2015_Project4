using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PressStartBehaviour : MonoBehaviour
{
    #region Public Variable

    public float tempsAnimation = 0.5f; // pour regler le clignotement depuis l'editor

    #endregion

    #region Main Methodes

    
    void Start()
    {
       // iTween.ColorTo(this.gameObject, iTween.Hash("a", 0, "time", tempsAnimation, "looptype", iTween.LoopType.pingPong));

		/*GameObject.FindObjectOfType<AnimationMenuBehaviour>().Move();
		
		GameObject.FindObjectOfType<MoveTitleBehaviour>().Move();
		
		Destroy(GameObject.FindObjectOfType<PressStartBehaviour>().gameObject);*/
    }

	/*void Update()
	{
		if (Input.GetMouseButton (0)) {
			OnMouseUp();
		}
	}*/

    void OnMouseUp()
    {
        GameObject.FindObjectOfType<AnimationMenuBehaviour>().Move();
        
		GameObject.FindObjectOfType<MoveTitleBehaviour>().Move();
        
        Destroy(GameObject.FindObjectOfType<PressStartBehaviour>().gameObject);
    }



	public void ClickMe()
	{
		OnMouseUp ();
	}

    #endregion

    #region Utils
   
    #endregion

    #region Private Variable

    #endregion
}
