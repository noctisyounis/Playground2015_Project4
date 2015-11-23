using UnityEngine;
using System.Collections;

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
	 * Les colonnes sont invesée
	 */
	private int[] m_boardDesign = new int[]
	{
		0,1,2,3,4,0,
		0,1,2,3,4,1,
		0,1,2,3,4,2,
		0,1,2,3,4,3,
		0,1,2,3,4,4
	} ;
	public GameObject[] m_cubes = new GameObject[30];

	public bool m_player_Turn = true;

	#endregion
	
	#region Main Methodes
	// Use this for initialization
	void Start () 
	{

		m_timer = (TimerBehaviour) GameObject.Find("Timer").GetComponent<TimerBehaviour>();
		Generate ();
	}





	public GameObject CheckCubePointing (GameObject card)
	{
		//Debug.Log ("Checking start");

		foreach (GameObject item in m_cubes) {

				item.GetComponent("SquareBehaviour");
				SquareBehaviour scriptSquare = (SquareBehaviour)item.GetComponent("SquareBehaviour");
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
		SquareBehaviour scriptSquare = (SquareBehaviour)cube.GetComponent("SquareBehaviour");
		scriptSquare.m_isOccuped = true;
		
		CardUnitBehaviour scriptCard = (CardUnitBehaviour) card.GetComponent("CardUnitBehaviour");
		
		Vector3 PositionVector = cube.transform.position;
		PositionVector.y += 0.1f;
		
		GameObject Tokken = TokkenBehaviour.CreateTokken(scriptCard,PositionVector,gameObject.transform.rotation, m_player_Turn);
		
		scriptSquare.m_tokken = Tokken;	
		
		scriptCard.PlayCard();

		ChangeTurn();

		if (m_turnNumber > 24) 
		{
			GameObject Opponent = GameObject.Find("Opponent");
			OpponentBehaviour script = (OpponentBehaviour) Opponent.GetComponent<OpponentBehaviour>();
			script.CancelInvoke();

			m_player_Turn = false;

			Debug.Log("End Game : Start Battle");
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
		System.Array.Reverse(Tiles);
		
		for (int i = 0; i < Tiles.Length; i++) 
		{
			int x = i % m_rowsLength;
			int z = i / m_rowsLength;
			
			
			int number = Tiles[i];
			
			GameObject prefab = prefabs[number];
			
			//Rotate Tiles
			Vector3 position = new Vector3(x,0,z); 
			Quaternion rotation = gameObject.transform.rotation;
			rotation.y = 180;
			
			
			GameObject item = (GameObject)Instantiate(prefab,position, rotation);
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
			
			if (m_player2 == TypePlayer.Player) {
				//Action Player 2
			}
			
			// Draw at the Start of your turn;
			GameObject Hand = GameObject.Find("Hand");
			HandBehaviour scriptHand = (HandBehaviour) Hand.GetComponent("HandBehaviour");
			scriptHand.Draw();
		}
		m_timer.EndTurn();
	}

	#endregion
	
	#region Private Variable

	private TimerBehaviour m_timer;


	#endregion
}
