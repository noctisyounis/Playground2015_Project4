using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerBehaviour : MonoBehaviour
{

    #region Public Variable

    public static int m_timePerTurn = 30;

    public int m_time;
    public Renderer m_top;
    public Renderer m_down;

    #endregion

    #region Main Methodes

    public void Start()
    {


        m_time = m_timePerTurn;
        m_hand = GameObject.FindObjectOfType<HandBehaviour>();

        m_board = (BoardBehaviour)GameObject.FindObjectOfType<BoardBehaviour>();

        InvokeRepeating("CountDown", 1, 1);
        InvokeRepeating("SetTimeSandFloat", 0, 1);
    }


    public void FixedUpdate()
    {
        m_top.material.SetFloat("_Cutoff", AlphaSandUp);
        m_down.material.SetFloat("_Cutoff", AlphaSandDown);
    }

    public void TimerOut()
    {
        Debug.Log("Timer Out");
        m_hand.ForcePlay(m_board);
    }


    public void EndTurn()
    {
        m_time = m_timePerTurn;
        BoardBehaviour script = (BoardBehaviour)m_board.GetComponent<BoardBehaviour>();
        if (script.m_player_Turn)
        {
            //gameObject.GetComponent<Image>().color = Color.blue;
            Reset(); 
            iTween.ShakeRotation(gameObject, new Vector3(120, 0, 0), 1f);
            //iTween.RotateTo(gameObject, new Vector3(120, 0, 0), 0.5f);
            //iTween.RotateTo(gameObject, new Vector3(300, 0, 0), 0.5f);
            
        }
        else
        {
            //gameObject.GetComponent<Image>().color = Color.red;
            Reset();
            iTween.ShakeRotation(gameObject, new Vector3(120, 0, 0), 1f);
            //iTween.RotateTo(gameObject, new Vector3(120, 0, 0), 0.5f);
            //iTween.RotateTo(gameObject, new Vector3(300, 0, 0), 0.5f);
            
        }
    }


    #endregion

    #region Utils
    private void SetTimeSandFloat()
    {

        float timeDown = AlphaSandDown;
        AlphaSandDown = timeDown - 0.03f;

        float timeUp = AlphaSandUp;
        AlphaSandUp = timeUp + 0.03f;

    }

    private void Reset()
    {
        AlphaSandUp = 0f;
        AlphaSandDown = 1f;
    }
    private void CountDown()
    {
        if (m_time > 0)
        {
            m_time--;
        }
        if (m_time == 0)
        {
            TimerOut();
        }
    }

    #endregion

    #region Private Variable

    private BoardBehaviour m_board;
    private HandBehaviour m_hand;
    private float AlphaSandUp = 0f;
    private float AlphaSandDown = 1f;

    #endregion
}
