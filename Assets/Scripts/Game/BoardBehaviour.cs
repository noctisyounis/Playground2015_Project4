using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BoardBehaviour : MonoBehaviour 
{
	#region Public Variable

	public int m_turnNumber = 1;

	public enum TypePlayer {Player, Computer};
	public TypePlayer m_player1 = TypePlayer.Player;
	public TypePlayer m_player2 = TypePlayer.Computer;

	private int m_rowsLength = 6;
	/*
	 * Tiles 
	 * 
	 * 0 = Forest
	 * 1 = Swamp
	 * 2 = Mountain
	 * 3 = Plaine
	 * 4 = Ruin
	 * 
	 */
	private int[] m_boardDesign = new int[]
	{
		2,1,0,0,4,0,
		0,0,4,4,0,1,
		0,1,2,3,1,2,
		2,4,0,1,4,3,
		0,1,0,2,0,4
	} ;
	public GameObject[] m_cubes = new GameObject[30];

	public bool m_player_Turn = true;

	#endregion
	
	#region Main Methodes
	// Use this for initialization
	void Start () 
	{
		m_hand = GameObject.FindObjectOfType<HandBehaviour>().transform.gameObject;

		m_timer = GameObject.FindObjectOfType<TimerBehaviour>();
		Generate ();

	}

	public GameObject CheckCubePointing (GameObject card)
	{
		//Debug.Log ("Checking start");

		foreach (GameObject item in m_cubes) 
		{
				item.GetComponent<SquareBehaviour>();
				SquareBehaviour scriptSquare = (SquareBehaviour)item.GetComponent<SquareBehaviour>();
				bool SquareOK = scriptSquare.m_isPointed;
								
				if(SquareOK)
				{
					return item;
				}
		}
		return null;
	}

	public void PutTokken(GameObject cube, GameObject card)
	{
		SquareBehaviour scriptSquare = (SquareBehaviour)cube.GetComponent<SquareBehaviour>();
		scriptSquare.m_isOccuped = true;
		
		CardUnitBehaviour scriptCard = (CardUnitBehaviour) card.GetComponent<CardUnitBehaviour>();
		
		Vector3 PositionVector = cube.transform.position;
		PositionVector.y += 0.1f;
		
		GameObject Tokken = TokkenBehaviour.CreateTokken(scriptCard,PositionVector,gameObject.transform.rotation, m_player_Turn);
		
		scriptSquare.m_tokken = Tokken;	
		
		scriptCard.PlayCard();

		ChangeTurn();

		if (m_turnNumber > 24) 
		{
			//Stop Timer
			m_timer.CancelInvoke();

			//Stop IA Playing
			GameObject Opponent = GameObject.FindObjectOfType<OpponentBehaviour>().transform.gameObject;
			OpponentBehaviour script = (OpponentBehaviour) Opponent.GetComponent<OpponentBehaviour>();
			script.CancelInvoke();

			m_player_Turn = false;

			EndGameUIManager EndGame = (EndGameUIManager) GameObject.FindObjectOfType<EndGameUIManager>();

			EndGame.ShowPointsCounter();

			Debug.Log("End Game : Start Battle");

			EndGame.VictoryGameMessage(true);

		}

	}

	#endregion

	#region Utils
	void Generate()
	{
		GameObject[] prefabs = new GameObject[5];
		prefabs[0] = (GameObject)Resources.Load ("SquareForest", typeof(GameObject));
		prefabs[1] = (GameObject)Resources.Load ("SquareSwamp", typeof(GameObject));
		prefabs[2] = (GameObject)Resources.Load ("SquareMountain", typeof(GameObject));
		prefabs[3] = (GameObject)Resources.Load ("SquarePlaine", typeof(GameObject));
		prefabs[4] = (GameObject)Resources.Load ("SquareRuin", typeof(GameObject));
			
		int[] Tiles = m_boardDesign;
		//System.Array.Reverse(Tiles);
		
		for (int i = 0; i < Tiles.Length; i++) 
		{
			int x = i % m_rowsLength;
			int y = i / m_rowsLength;
						
			int number = Tiles[i];
			
			GameObject prefab = prefabs[number];
			
			//Rotate Tiles
			Vector3 position = new Vector3(5-x,0,y); 
			Quaternion rotation = gameObject.transform.rotation;
			//rotation.y = 180;
			GameObject item = (GameObject)Instantiate(prefab,position, rotation);
			SquareBehaviour script = (SquareBehaviour) item.GetComponent<SquareBehaviour>();
			script.m_gridX = 5-x;
			script.m_gridY = 4-y;
			m_cubes[i] = item;
			
			item.transform.SetParent(gameObject.transform);

		}	
	}

	public void ChangeTurn()
	{
		if (m_player_Turn) 
		{
			m_turnNumber++;
			m_player_Turn = false;
		}
		else 
		{
			m_turnNumber++;
			m_player_Turn = true;
			
			if (m_player2 == TypePlayer.Player) 
			{
				//Action Player 2
			}
			
			// Draw at the Start of your turn;
			HandBehaviour scriptHand = (HandBehaviour) m_hand.GetComponent<HandBehaviour>();
			scriptHand.Draw();
		}
		m_timer.EndTurn();
	}

	public List<GameObject> FightOrder()
	{
		List<GameObject> Squares = m_cubes.ToList();
		Squares.RemoveAll(x => !x.GetComponent<SquareBehaviour>().m_isOccuped);

		List<GameObject> Tokkens = new List<GameObject>();
		foreach (GameObject item in Squares) 
		{
			SquareBehaviour SquareScript = item.GetComponent<SquareBehaviour>();
			GameObject Tokken = SquareScript.m_tokken;
			TokkenBehaviour TokkenScript = Tokken.GetComponent<TokkenBehaviour>();
			TokkenScript.m_gridX = SquareScript.m_gridX;
			TokkenScript.m_gridY = SquareScript.m_gridY;
			Tokkens.Add (Tokken);
		}

		Tokkens.OrderBy(x => x.GetComponent<TokkenBehaviour>().m_speed)
				.ThenBy(x => x.GetComponent<TokkenBehaviour>().m_playedAtTurn);

		//TODO eb integrate tokken

		return Tokkens;
	}


	public List<GameObject> Fight(bool IsFinalFight)
	{
		List<GameObject> Tokkens = FightOrder();

		//TODO eb integrate tokken
		foreach ( GameObject item in Tokkens) 
		{
			TokkenBehaviour script = item.GetComponent<TokkenBehaviour>();

			if (script.m_hp < 0) 
			{
				//enum
				// CC
				if (script.m_type == "Close" ) 
				{

				}
				// Archer
				else if (script.m_type == "Range") 
				{
					
				}
				// Heavy
				else if (script.m_type == "BigRange") 
				{
					
				}


			}

		}


		//return Tokken still alive
		return Tokkens;
	}

	#endregion
	
	#region Private Variable

	private TimerBehaviour m_timer;
	private GameObject m_hand;

	#endregion
}
