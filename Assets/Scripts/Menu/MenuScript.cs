using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    
    #region Public Variable

    

    #endregion

    #region Main methode


    #endregion

    #region Utils

    void OnMouseEnter()
    {
		Debug.Log ("Test");
        GetComponent<GUITexture>().transform.localScale = new Vector3(0.2f, 0.15f); 

    }

    void OnMouseExit()
    {

        GetComponent<GUITexture>().transform.localScale = new Vector3(0.15f, 0.1f); 

    }

    #endregion

    #region Private Variable

    #endregion
}
