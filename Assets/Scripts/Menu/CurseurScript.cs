using UnityEngine;
using System.Collections;

public class CurseurScript : MonoBehaviour
{



    #region Public Variable
    
    public Texture2D m_curseur;

    #endregion

    #region Main methode

    void Start()
    {
        Cursor.visible = false;
    }

    #endregion

    #region Utils
    
    void OnGUI()
    {
        Vector3 positionSouris = Input.mousePosition;
        Rect positionCurseur = new Rect(positionSouris.x, Screen.height - positionSouris.y, m_curseur.width, m_curseur.height);
        GUI.Label(positionCurseur, m_curseur);
    }

    #endregion

    #region Private Variable

    #endregion
}
