using UnityEngine;
using System.Collections;

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

    public void OnMouseUp()
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

    #endregion

    #region Private Variable

    private AudioSource audio;

    #endregion
}