using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PressStartBehaviour : MonoBehaviour
{
    #region Public Variable

    public float tempsAnimation = 0.5f; // pour regler le clignotement depuis l'editor
	public float speed = 2.0f;

	Text flashingText;
	IEnumerator coroutine;
    #endregion

    #region Main Methodes

    
    void Start()
    {
		flashingText = GetComponent<Text> ();
		coroutine = BlinkText (0.5f);
		StartCoroutine (coroutine);
        //iTween.ColorTo(this.gameObject, iTween.Hash("a", 0, "time", tempsAnimation, "looptype", iTween.LoopType.pingPong));

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



	public IEnumerator BlinkText(float time)
	{
		while (true) {
			flashingText.text = " ";
			yield return new WaitForSeconds(time-0.2f);
			flashingText.text = "Click here to continue";
			yield return new WaitForSeconds(time+0.3f);
		}
	}


    void OnMouseUp()
    {
        GameObject.FindObjectOfType<AnimationMenuBehaviour>().Move();
        
		GameObject.FindObjectOfType<MoveTitleBehaviour>().Move();
        
        Destroy(GameObject.FindObjectOfType<PressStartBehaviour>().gameObject);
    }



	public void ClickMe()
	{
		StopCoroutine (coroutine);
		OnMouseUp ();
	}

    #endregion

    #region Utils
   
    #endregion

    #region Private Variable

    #endregion
}
