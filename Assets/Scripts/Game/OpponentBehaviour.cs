using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OpponentBehaviour : MonoBehaviour {

	#region Public Variable

	public List<GameObject> m_opponentDeck = new List<GameObject>();



	#endregion


	#region Main Methodes

	public void Start()
	{
		m_Board = GameObject.Find("Board");

		LoadDeck();


		InvokeRepeating("CheckOpponentTurn",3,15);

	}

	private void CheckOpponentTurn()
	{
		BoardBehaviour scriptBoard = (BoardBehaviour)m_Board.GetComponent<BoardBehaviour>();
		if (!scriptBoard.m_player_Turn) 
		{
			Play(scriptBoard);
		}
	}

	private void Play(BoardBehaviour scriptBoard)
	{

		Debug.Log("Opponent start Playing");

		GameObject[] Squares = scriptBoard.m_cubes;
		GameObject FocusSquare;



		List<GameObject> FreeSquares = GameObject.Find("Board").GetComponent<BoardBehaviour>().m_cubes.ToList();
		FreeSquares.RemoveAll(x => x.GetComponent<SquareBehaviour>().m_isOccuped);
		int index = (int)Mathf.Floor( Random.Range(0,FreeSquares.Count));

		FocusSquare = FreeSquares[index];

		GameObject PlayedCard = m_opponentDeck[0];
		
		scriptBoard.PutTokken(FocusSquare,PlayedCard);

		Debug.Log("Impossible to Play: No Empty Square");

	}

	#endregion


	#region Utils

	private void LoadDeck()
	{
		GameObject prefab = (GameObject)Resources.Load ("Card", typeof(GameObject));
		m_opponentDeck.Clear();
		for (int i = 1 ; i < 19; i++) {
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
	GameObject m_Board;
	#endregion
}
