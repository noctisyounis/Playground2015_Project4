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
		
		int heightScreen = Screen.height;
		int position10 = (heightScreen / 10 )*8;
        
        iTween.MoveTo(gameObject, iTween.Hash("y",position10,"time",2f));
		iTween.ScaleTo(gameObject,iTween.Hash("y",5,"x",6.3));
        
    }



    #endregion

    #region Private Variable
    int i = 150;
    //Vector3 m_initialPosition;
    //Rigidbody2D m_rb2d;

    #endregion
}
