using UnityEngine;
using System.Collections;

public class PlaySongBehaviour : MonoBehaviour {
	
	

    #region Public Variable
    
    public AudioClip m_son;

    #endregion

    #region Main Methodes

    void start()
    {
       
    
        audio = GetComponent<AudioSource>();
    

    
        audio.PlayOneShot(m_son);
       
    
    }

    #endregion

    #region Utils

    

    #endregion

    #region Private Variable
    private AudioSource audio;
    #endregion
}
