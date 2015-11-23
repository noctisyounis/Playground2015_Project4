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

		m_board = (BoardBehaviour)GameObject.Find("Board").GetComponent<BoardBehaviour>();

		InvokeRepeating("CountDown",1,1);

	}

	public void FixedUpdate()
	{
		gameObject.transform.GetComponentInChildren<Text>().text = m_time.ToString();
	}

	public void TimerOut()
	{
		Debug.Log("Timer Out");
		GameObject.Find("Hand").GetComponent<HandBehaviour>().ForcePlay(m_board);

	}


	public void EndTurn()
	{
		m_time = m_timePerTurn;
		BoardBehaviour script = (BoardBehaviour) m_board.GetComponent<BoardBehaviour>();
		if (script.m_player_Turn) {
			gameObject.GetComponent<Image>().color = Color.blue;
		}
		else 
		{
			gameObject.GetComponent<Image>().color = Color.red;
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


	#endregion
}
