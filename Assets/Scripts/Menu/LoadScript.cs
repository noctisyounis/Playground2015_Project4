using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class LoadScript : MonoBehaviour
{
    #region Public Variable
    public AudioClip m_son;
    public string m_levelSuivant = "Quitter";
    #endregion

    #region Main method


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        audio.PlayOneShot(m_son);
        if (m_levelSuivant == "Quitter")
        {
            Application.Quit();
        }
        else
        {
            Application.LoadLevel(m_levelSuivant);
        }
    }

    #endregion
    #region Utils

	public void PointerEnter()
	{
		//GetComponent<Image>().transform.localScale = new Vector3(0.2f, 0.15f); 
		iTween.ScaleTo(gameObject,iTween.Hash("y",1,"x",3.5));
		
	}
	
	public void PointerExit()
	{
		iTween.ScaleTo(gameObject,iTween.Hash("y",0.8,"x",3));
	//	GetComponent<GUITexture>().transform.localScale = new Vector3(0.15f, 0.1f); 
		
	}

    #endregion

    #region Private Variable

    private AudioSource audio;

    #endregion
}