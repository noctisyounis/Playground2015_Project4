using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class OpponentBehaviour : MonoBehaviour {

	#region Public Variable

	public List<GameObject> m_opponentDeckUnit = new List<GameObject>();
	public List<GameObject> m_opponentDeckLand = new List<GameObject>();

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
		bool ok = false;
		GameObject[,] Squares = scriptBoard.m_cubes;
		GameObject FocusSquare;
        
		//Debug.Log("Opponent start Playing");
		if (scriptBoard.m_turnType [scriptBoard.m_turnNewNumber] == 0) {

			do {

				int x = (int)Random.Range (0f, 5f);
				//Debug.Log(x);
				int y = (int)Random.Range (0f, 4f);
				//Debug.Log(y);



				GameObject place = Squares [x, y];
				SquareBehaviour Script = place.GetComponent<SquareBehaviour> ();
				if (!Script.m_isOccuped) {
					FocusSquare = place;
					GameObject PlayedCard = m_opponentDeckUnit [0];
					m_opponentDeckUnit.Remove (PlayedCard);
					scriptBoard.PutTokken (FocusSquare, PlayedCard);
					ok = true;
					return;
				}
			} while (!ok);

			//Debug.Log("Impossible to Play: No Empty Square");

		} else 
		{
			int x = (int)Random.Range (0f, 5f);
			//Debug.Log(x);
			int y = (int)Random.Range (0f, 4f);
			//Debug.Log(y);
			GameObject place = Squares [x, y];
			scriptBoard.PutLand(place,m_opponentDeckLand[0]);
			return;
		}
	}

	#endregion


	#region Utils

	private void LoadDeck()
	{
		GameObject prefab = (GameObject)Resources.Load ("Card", typeof(GameObject));
		m_opponentDeckUnit.Clear();
		m_opponentDeckLand.Clear();

		ReadDeckBehaviour deckList = new ReadDeckBehaviour("opponentCard.xml");
		ReadXmlBehaviour cardList = new ReadXmlBehaviour();    
		
		for (int i = 0; i < deckList.PropDeck.Count; i++)
		{
			int id = int.Parse(deckList.PropDeck[i].ToString());
			if(id < 1000)
			{
				GameObject Card = GameObject.Instantiate((GameObject)cardList.List[id - 1]);

				Card.AddComponent<DraggableBehaviour>();
				Card.name = "Card" + i.ToString();
				Card.GetComponent<DraggableBehaviour>().m_currentTypeCard = "Unit";
				m_opponentDeckUnit.Add(Card);
			}
			else
			{
				GameObject Card = GameObject.Instantiate((GameObject)cardList.ListLand[id - 1001]);
				Card.name = "Card" + i.ToString();	
				Card.AddComponent<DraggableBehaviour>();
				Card.GetComponent<DraggableBehaviour>().m_currentTypeCard = "Land";
				m_opponentDeckLand.Add(Card);
			}
		}

		Shuffle(m_opponentDeckLand);
		Shuffle(m_opponentDeckUnit);
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
