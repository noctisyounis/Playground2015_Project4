using UnityEngine;
using System.Collections;

public class SwordAnim : MonoBehaviour 
{

	private BoardBehaviour m_board;

	public AnimationState m_right;

	void Start()
	{
		m_board = GameObject.FindObjectOfType<BoardBehaviour>();
	}

	void IsFinishedRight () 
	{
		Debug.Log("Finish");
		GetComponent<Animator>().SetBool("Right",false);
	}
	void IsFinishedLeft () 
	{
		Debug.Log("Finish");
		GetComponent<Animator>().SetBool("Left",false);
	}
	void IsFinishedUp () 
	{
		Debug.Log("Finish");
		GetComponent<Animator>().SetBool("Up",false);
	}
	void IsFinishedDown () 
	{
		Debug.Log("Finish");
		GetComponent<Animator>().SetBool("Down",false);
	}
}
