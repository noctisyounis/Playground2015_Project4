using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpponentBehaviour : MonoBehaviour {

	#region Public Variable

	public List<GameObject> m_opponentDeck = new List<GameObject>();

	public int CheckTime = 15;

	#endregion


	#region Main Methodes

	public void Start()
	{
		m_board = GameObject.FindObjectOfType<BoardBehaviour>().gameObject;

		LoadDeck();

		InvokeRepeating("CheckOpponentTurn",3,CheckTime);

	}

	private void CheckOpponentTurn()
	{
		BoardBehaviour scriptBoard = (BoardBehaviour)m_board.GetComponent<BoardBehaviour>();
		if (!scriptBoard.m_player_Turn) 
		{
			Play(scriptBoard);
		}
	}

	private void Play(BoardBehaviour scriptBoard)
	{

		Debug.Log("Opponent start Playing");

		GameObject[,] Squares = scriptBoard.m_cubes;
		GameObject FocusSquare;

		foreach (GameObject item in Squares) 
		{
			SquareBehaviour Script = item.GetComponent<SquareBehaviour>();
			if (!Script.m_isOccuped) 
			{
				FocusSquare = item;
				GameObject PlayedCard = m_opponentDeck[0];
				m_opponentDeck.Remove(PlayedCard);
				scriptBoard.PutTokken(FocusSquare, PlayedCard);

				return;
			}
		}

		Debug.Log("Impossible to Play: No Empty Square");

	}

	#endregion


	#region Utils

	private void LoadDeck()
	{
		GameObject prefab = (GameObject)Resources.Load ("Card", typeof(GameObject));
		m_opponentDeck.Clear();
		for (int i = 1 ; i < 19; i++) 
		{
			GameObject Card = (GameObject)Instantiate(prefab);
			Card.transform.SetParent(gameObject.transform.GetChild(1));
			Card.name = "Card"+i.ToString();
			m_opponentDeck.Add(Card);
		}
		Shuffle(m_opponentDeck);
	}

	
	private void Shuffle(List<GameObject> list)  
	{  
		int n = list.Count;
		
		while (n > 1) 
		{
			float rnd = Random.Range(0, n);
			if (rnd == n) 
			{
				rnd--;
			}
			int k = (int)Mathf.Floor(rnd);
			n--;
			GameObject value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}
	#endregion


	#region Private Variable
	GameObject m_board;
	#endregion
}
