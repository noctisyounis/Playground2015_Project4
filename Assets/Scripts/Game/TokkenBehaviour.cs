using UnityEngine;
using System.Collections;

public class TokkenBehaviour : MonoBehaviour {

	#region Public Variable
	
	public int m_hp;
	
	public int m_ATK_Up;
	public int m_ATK_Right;
	public int m_ATK_Down;
	public int m_ATK_Left;
	
	public int m_speed;
	
	public int m_victoryPoint;
	
	public string m_name;
	
	public string m_type;
	
	public string m_description;
	
	public string m_pictures;
	
	#endregion
	
	#region Main Methodes
	
	
	
	
	#endregion
	
	#region Utils
	public static GameObject CreateTokken(CardUnitBehaviour Card, Vector3 position, Quaternion rotation, bool playerTurn)
	{
		GameObject prefab;
		if (playerTurn) 
		{
			prefab = (GameObject)Resources.Load ("PlayerTokken", typeof(GameObject));
		}
		else 
		{
			prefab = (GameObject)Resources.Load ("OpponentTokken", typeof(GameObject));
		}
		GameObject Tokken = (GameObject)Instantiate(prefab,position, rotation);

		TokkenBehaviour TokkenB = (TokkenBehaviour) Tokken.GetComponent("TokkenBehaviour");

		TokkenB.m_hp = Card.m_hp;
		TokkenB.m_ATK_Up = Card.m_ATK_Up;
		TokkenB.m_ATK_Right = Card.m_ATK_Right;
		TokkenB.m_ATK_Down = Card.m_ATK_Down;
		TokkenB.m_ATK_Left = Card.m_ATK_Left;
		
		TokkenB.m_speed = Card.m_speed;
		
		TokkenB.m_victoryPoint = Card.m_victoryPoint;
		
		TokkenB.m_name = Card.m_name;
		
		TokkenB.m_type = Card.m_type;
		
		TokkenB.m_description = Card.m_description;
		
		TokkenB.m_pictures = Card.m_pictures;

		return Tokken;
	}
	#endregion
	
	#region Private Variable
	
	#endregion
}
