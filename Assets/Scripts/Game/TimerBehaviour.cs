using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerBehaviour : MonoBehaviour 
{

	#region Public Variable

	public static int m_timePerTurn = 30;

	public int m_time;

	#endregion
	
	#region Main Methodes
	
	public void Start()
	{
		m_time = m_timePerTurn;
		m_hand = GameObject.FindObjectOfType<HandBehaviour>();


		m_board = (BoardBehaviour)GameObject.FindObjectOfType<BoardBehaviour>();

		InvokeRepeating("CountDown",1,1);
	}

	public void FixedUpdate()
	{
        //gameObject.transform.GetComponentInChildren<Text>().text = m_time.ToString();
	}

	public void TimerOut()
	{
		Debug.Log("Timer Out");
		m_hand.ForcePlay(m_board);
	}


	public void EndTurn()
	{
		m_time = m_timePerTurn;
		BoardBehaviour script = (BoardBehaviour) m_board.GetComponent<BoardBehaviour>();
		if (script.m_player_Turn) 
		{
            //gameObject.GetComponent<Image>().color = Color.blue;
            iTween.ShakeRotation(gameObject, new Vector3(120, 0, 0), 1f);
            //iTween.RotateTo(gameObject, new Vector3(120, 0, 0), 0.5f);
            //iTween.RotateTo(gameObject, new Vector3(300, 0, 0), 0.5f);
		}
		else 
		{
            //gameObject.GetComponent<Image>().color = Color.red;
            iTween.ShakeRotation(gameObject, new Vector3(120, 0, 0), 1f);
            //iTween.RotateTo(gameObject, new Vector3(120, 0, 0), 0.5f);
            //iTween.RotateTo(gameObject, new Vector3(300, 0, 0), 0.5f);
		}
	}

	
	#endregion
	
	#region Utils

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


	#endregion
}
