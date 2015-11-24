using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SquareBehaviour : MonoBehaviour
{

	#region Public Variable

	public bool m_isPointed= false;
	public bool m_isOccuped = false;
	public GameObject m_tokken;
	public int m_gridX;
	public int m_gridY;

	#endregion

	#region Main Methodes
	public void OnMouseEnter() 
	{

		m_isPointed = true;


	}
	
	public void OnMouseExit() 
	{

		m_isPointed = false;

	}



	#endregion

	#region PUtils
	#endregion

	#region Private Variable
	#endregion
}
