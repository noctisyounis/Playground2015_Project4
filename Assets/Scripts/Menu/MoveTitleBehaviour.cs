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
        GetComponent<GUIText>().fontSize = i;
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
        //m_rb2d.velocity = Vector2.up * 0.2f;
        //for (int i = 150; i >= 64; i--)
        //{

        //    GetComponent<GUIText>().fontSize = i;
        //}
        iTween.MoveTo(gameObject, new Vector3(0.5f, 0.96f, 0), 3f);
        iTween.ScaleTo(gameObject, new Vector3(1, 1, 1), 2f);
        InvokeRepeating("resize", 0, 0.03f);

    }



    #endregion

    #region Private Variable
    int i = 150;
    //Vector3 m_initialPosition;
    //Rigidbody2D m_rb2d;

    #endregion
}
