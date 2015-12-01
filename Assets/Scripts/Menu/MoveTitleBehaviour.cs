using UnityEngine;
using System.Collections;
using System.Threading;

public class MoveTitleBehaviour : MonoBehaviour {

    #region Public Variable



    #endregion

    #region Main methode

    void Start()
    {
        m_initialPosition = transform.position;
        m_rb2d = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (gameObject.transform.position.y >= m_initialPosition.y + 0.2f)
        {
            m_rb2d.MovePosition(new Vector3(m_initialPosition.x, m_initialPosition.y + 0.2f, m_initialPosition.z));
            m_rb2d.velocity = Vector2.zero;
        }
        else
        {

        }
    }

    #endregion

    #region Utils

    public void Move()
    {
        m_rb2d.velocity = Vector2.up * 0.2f;
        for (int i = 150; i >= 64; i--)
        {
            
            GetComponent<GUIText>().fontSize = i;
        }

    }



    #endregion

    #region Private Variable
   
    Vector3 m_initialPosition;
    Rigidbody2D m_rb2d;

    #endregion
}
