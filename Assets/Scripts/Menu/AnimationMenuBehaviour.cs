using UnityEngine;
using System.Collections;

public class AnimationMenuBehaviour : MonoBehaviour
{


    #region Public Variable


    public float m_time = 4.0f;
    #endregion

    #region Main methode

    void Start()
    {
        m_initialPosition = transform.position;
        m_rb2d = GetComponent<Rigidbody2D>();
       
    }
    //void Update()
    //{
    //    if (gameObject.transform.position.y >= m_initialPosition.y + 1)
    //    {
    //        m_rb2d.MovePosition(new Vector3(m_initialPosition.x, m_initialPosition.y + 1, m_initialPosition.z));
    //        m_rb2d.velocity = Vector2.zero;
    //    }
    //    else
    //    {

    //    }
    //}
   
    #endregion

    #region Utils

    public void Move()
    {
		int heightScreen = Screen.height;
		double position10 = (heightScreen / 10 )* 6.5;
      //  iTween.MoveTo(gameObject, new Vector3(m_initialPosition.x, m_initialPosition.y + 1, m_initialPosition.z), m_time);
		iTween.MoveTo(gameObject, iTween.Hash("y",position10,"time",2f));
    }
   
    #endregion

    #region Private Variable
    
    private Vector3 m_initialPosition;
    Rigidbody2D m_rb2d;

    #endregion
}
