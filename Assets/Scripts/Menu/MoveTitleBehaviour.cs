using UnityEngine;
using System.Collections;
using System.Threading;

public class MoveTitleBehaviour : MonoBehaviour {

    #region Public Variable



    #endregion

    #region Main methode

    void Start()
    {

    }
    void Update()
    {
       
    }

    #endregion

    #region Utils

    private void resize()
    {
        if (i > 100)
        {
            i--;
        }
    }
    public void Move()
    {
        
        iTween.MoveTo(gameObject, new Vector3(0.5f, 0.85f, 0), 3f);
        iTween.ScaleTo(gameObject, new Vector3(0.45f, 0.28f, 1), 3f);
        

    }



    #endregion

    #region Private Variable
    int i = 150;
    //Vector3 m_initialPosition;
    //Rigidbody2D m_rb2d;

    #endregion
}
