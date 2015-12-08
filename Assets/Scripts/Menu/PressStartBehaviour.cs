using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PressStartBehaviour : MonoBehaviour
{
    #region Public Variable

    public float tempsAnimation = 0.5f; // pour regler le clignotement depuis l'editor
	public float speed = 2.0f;
	public AudioClip m_son;

	Text flashingText;
	IEnumerator coroutine;
    #endregion

    #region Main Methodes

    
    void Start()
	{
		audio = GetComponent<AudioSource> ();
		flashingText = GetComponent<Text> ();
		if (PlayerPrefs.GetString("IsNotFirstStart") != "True") 
		{
			coroutine = BlinkText (0.5f);
			StartCoroutine (coroutine);
		}
		else 
		{
			OnMouseUp();
		}
    }

	public IEnumerator BlinkText(float time)
	{
		while (true) {
			flashingText.text = " ";
			yield return new WaitForSeconds(time-0.2f);
			flashingText.text = "Clique pour continuer";
			yield return new WaitForSeconds(time+0.3f);
		}
	}


    void OnMouseUp()
    {
		gameObject.GetComponent<Text> ().enabled = false;

        GameObject.FindObjectOfType<AnimationMenuBehaviour>().Move();
        
		GameObject.FindObjectOfType<MoveTitleBehaviour>().Move();
        
		PlayerPrefs.SetString("IsNotFirstStart","True");

		StartCoroutine (DelayDestroy (2.5f));
    }



	public void ClickMe()
	{	
		StopCoroutine (coroutine);	
		audio.Play();
		OnMouseUp ();
	}

	IEnumerator DelayDestroy(float time)
	{
		yield return new WaitForSeconds (time);
		Destroy(GameObject.FindObjectOfType<PressStartBehaviour>().gameObject);
	}

    #endregion

    #region Utils
   
    #endregion

	#region Private Variable
	
	private AudioSource audio;
	
	#endregion
}
