using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    
    #region Public Variable

    public Color m_couleurEntrer = Color.white;
    public Color m_couleurSortie = Color.black;
    public int m_tailleEntrer = 45;
    public int m_tailleSortie = 45;


    #endregion

    #region Main methode


    #endregion

    #region Utils

    void OnMouseEnter()
    {
        GetComponent<GUIText>().material.color= m_couleurEntrer;
        GetComponent<GUIText>().fontSize = m_tailleEntrer;

    }

    void OnMouseExit()
    {
        GetComponent<GUIText>().material.color = m_couleurSortie;
        GetComponent<GUIText>().fontSize = m_tailleSortie;

    }

    #endregion

    #region Private Variable

    #endregion
}
