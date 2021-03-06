﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class BoardBehaviour : MonoBehaviour 
{
	#region Public Variable

	public const float m_delay = 1.05f;

	public int m_turnNewNumber = 0;

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

	/*
	 * Type tour
	 * 
	 * 0 = unit
	 * 1 = land
	 * 4 = endGame
	 */

	public int[] m_turnType = new int[]
	{ 0,1,0,0,1,0,0,0,0,1,4};

    private int[] m_boardDesign;

	public GameObject[,] m_cubes = new GameObject[6,5];

	public bool m_player_Turn = true;

	public GameObject m_panelTurn;
	public GameObject m_panelTurnType;

	private GameObject lastCubeDark;

	public bool m_gameIsFinished;

	public int m_animCount = 0;

	public BulleBehaviour m_bulleBehaviour;

	#endregion
	
	#region Main Methodes
	// Use this for initialization
	void Start () 
	{
		setTextScreen ();
		m_hand = GameObject.FindObjectOfType<HandBehaviour>().transform.gameObject;

		m_endGame = (EndGameUIManager) GameObject.FindObjectOfType<EndGameUIManager>();

		m_timer = GameObject.FindObjectOfType<TimerBehaviour>();
		Generate ();
	}

	void FixedUpdate()
	{
		m_endGame.SetPointCounter(m_finalPointsP1, m_finalPointsP2);
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
		Tokken.transform.SetParent(gameObject.transform);
		Tokken.GetComponent<RectTransform>().Rotate(new Vector3(90,180,0));
		Tokken.GetComponent<TokkenBehaviour>().SetPosition(scriptSquare.m_gridX,scriptSquare.m_gridY);
		Tokken.GetComponent<TokkenBehaviour>().m_playedAtTurn = m_turnNewNumber;

		string type = scriptSquare.GetStringType();
		Tokken.GetComponent<TokkenBehaviour>().SetBonus(type);

		scriptSquare.m_tokken = Tokken;	

		scriptCard.PlayCard();

		if (m_player_Turn == false) 
		{
			if(lastCubeDark != null)
			{
				lastCubeDark.GetComponent<SquareBehaviour>().OverOff();
			}

			scriptSquare.BlackOn();

			lastCubeDark = cube;
		}

		routineEndTurn ();
	}

	public void CheckEndGame()
	{

		if (m_turnNewNumber ==  m_turnType.Length-1 && m_player_Turn == false) {
			//Stop Timer
			m_timer.CancelInvoke ();
			
			//Stop IA Playing
			GameObject Opponent = GameObject.FindObjectOfType<OpponentBehaviour> ().transform.gameObject;
			OpponentBehaviour script = (OpponentBehaviour)Opponent.GetComponent<OpponentBehaviour> ();
			script.CancelInvoke ();
			
			m_player_Turn = false;

			m_gameIsFinished = true;
			
			
			EndGameUIManager EndGame = (EndGameUIManager)GameObject.FindObjectOfType<EndGameUIManager> ();
			EndGame.ShowPointsCounter ();
			
			//Debug.Log ("End Game : Start Battle");
			
			List<GameObject> TokkenAlive = Fight (false);
			

			StartCoroutine(DelayEndGameMessage());
		} else 
		{
			if (m_player_Turn == false) {
				m_turnNewNumber++;
			}
			setTextScreen();
		}
	}

	public void setTextScreen()
	{
		m_panelTurn.GetComponent<Text>().text = "Tour n°" + (m_turnNewNumber + 1);

		if(m_turnType[m_turnNewNumber] == 0)
		{
			m_panelTurnType.GetComponent<Text>().text = "Unités";

			if(m_player_Turn == false)
			{
				m_bulleBehaviour.TurnUnits();
			}
		}
		else if(m_turnType[m_turnNewNumber] == 1)
		{
			m_panelTurnType.GetComponent<Text>().text = "Terrains";

			if(m_player_Turn == false)
			{
				m_bulleBehaviour.TurnLands();
			}
		}
	}

	public void PutLand(GameObject cube, GameObject card)
	{
		if (card != null) 
		{
			CardGroundBehaviour scriptland = card.GetComponentInParent<CardGroundBehaviour> ();
			cube.GetComponent<SquareBehaviour> ().ChangeMaterial (scriptland.m_type);
			cube.GetComponent<SquareBehaviour> ().ChangeTextureClose(scriptland);
			Destroy (card);
		} 
		else 
		{
			cube.GetComponent<SquareBehaviour> ().ChangeMaterial ("Forest");
		}

		routineEndTurn ();
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

        int rand = (int)Random.Range(0f, 5f);
        switch (rand)
        {

            case 1:
                m_boardDesign = new int[]
	                      {
	                    	3,2,0,1,4,2,
		                    0,0,4,1,0,1,
		                    0,3,1,3,1,2,
		                    2,4,2,1,4,3,
	                      	0,3,1,2,0,2
	                     };
                break;
            case 2:
                m_boardDesign = new int[]
	                      {
	                    	0,0,0,0,0,0,
		                    0,2,3,4,2,0,
		                    0,3,1,1,3,0,
		                    0,2,4,3,2,0,
	                      	0,0,0,0,0,0
	                     };
                break;
            case 3:
                m_boardDesign = new int[]
	                      {
	                    	2,3,2,1,4,3,
		                    1,3,0,2,3,0,
		                    0,3,2,2,1,1,
		                    4,4,4,1,2,3,
	                      	0,1,0,2,0,4
	                     };
                break;
            case 4:
                m_boardDesign = new int[]
	                      {
	                    	1,1,2,3,4,1,
		                    0,2,4,4,2,1,
		                    3,1,2,3,1,3,
		                    2,4,0,1,4,3,
	                      	1,1,3,2,0,1
	                     };
                break;
            case 5:
                m_boardDesign = new int[]
	                      {
	                    	0,1,2,0,4,0,
		                    0,0,4,4,2,1,
		                    2,1,0,1,1,2,
		                    0,4,0,1,2,3,
	                      	0,1,0,2,0,1
	                     };
                break;
            default:
                m_boardDesign = new int[]
	                      {
	                    	2,1,0,0,4,0,
		                    0,0,4,4,0,1,
		                    0,1,2,3,1,2,
		                    2,4,0,1,4,3,
	                      	0,1,0,2,0,4
	                     };
                break;
        }
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
			script.m_gridX = x;
			script.m_gridY = y;
			m_cubes[x,y] = item;
			
			item.transform.SetParent(gameObject.transform);

		}	
	}

	public void ChangeTurn()
	{
		if (m_player_Turn) 
		{
			m_player_Turn = false;
		}
		else 
		{
			m_player_Turn = true;
			
			if (m_player2 == TypePlayer.Player) 
			{
				//Action Player 2
			}

			if(m_turnType[m_turnNewNumber-1] == 0)
			{
			// Draw at the Start of your turn;
			HandBehaviour scriptHand = (HandBehaviour) m_hand.GetComponent<HandBehaviour>();
			scriptHand.Draw();
			}
		}
		m_timer.EndTurn();
	}

	public void routineEndTurn()
	{
		CheckEndGame ();
		ChangeTurn();
	}

	public List<GameObject> FightOrder(GameObject[,] Cubes)
	{
		List<GameObject> Squares = new List<GameObject>();
		foreach (var s in Cubes) 
		{
			Squares.Add(s);
		}
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

		Tokkens = Tokkens.OrderByDescending(x => x.GetComponent<TokkenBehaviour>().speed).ThenBy(x => x.GetComponent<TokkenBehaviour>().m_playedAtTurn).ToList();

		return Tokkens;
	}


	public List<GameObject> Fight(bool IsSimulation)
	{
		GameObject[,] Board;
		if (IsSimulation) 
		{
			Board = (GameObject[,]) m_cubes.Clone();
		}
		else 
		{
			Board = m_cubes;
		}
		
		List<GameObject> TokkensOrder = FightOrder(Board);
		
		foreach (var item in TokkensOrder) 
		{
			TokkenBehaviour tb = item.GetComponent<TokkenBehaviour>();
			if (tb.m_playedBy == TokkenBehaviour.Player.Player1) 
			{
				m_finalPointsP1 += tb.victoryPoint;
			}
			else 
			{
				m_finalPointsP2 += tb.victoryPoint;
			}
		}
		
		//TODO eb integrate tokken
		foreach ( GameObject item in TokkensOrder) 
		{
			TokkenBehaviour TokkenScript = item.GetComponent<TokkenBehaviour>();
			
			if (TokkenScript.hp > 0) 
			{
				//enum
				// CC
				if (TokkenScript.type == "Close" ) 
				{

					// UP
					if (TokkenScript.m_gridY != 0) 
					{
						Animation sword = AnimationManager.SwordAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						SquareBehaviour SquareScript = Board[TokkenScript.m_gridX,TokkenScript.m_gridY-1].GetComponent<SquareBehaviour>();
						if(SquareScript.m_isOccuped)
						{
							m_animCount++;
							bool hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Up, true);
							if (hit) 
							{
								StartCoroutine( DelayAnimation(sword, "SwordUp"));
							}
						}
					}
					// Down
					if (TokkenScript.m_gridY != 4) 
					{
						Animation sword = AnimationManager.SwordAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						SquareBehaviour SquareScript = Board[TokkenScript.m_gridX,TokkenScript.m_gridY+1].GetComponent<SquareBehaviour>();
						if(SquareScript.m_isOccuped)
						{
							m_animCount++;
							bool hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Down, true);
							if (hit) 
							{
								StartCoroutine( DelayAnimation(sword, "SwordDown"));
							}
						}
					}
					// Right
					if (TokkenScript.m_gridX != 5) 
					{
						Animation sword = AnimationManager.SwordAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						SquareBehaviour SquareScript = Board[TokkenScript.m_gridX+1,TokkenScript.m_gridY].GetComponent<SquareBehaviour>();
						if(SquareScript.m_isOccuped)
						{
							m_animCount++;
							bool hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Right, true);
							if (hit) 
							{
								StartCoroutine( DelayAnimation(sword, "SwordRight"));
							}
						}
					}
					// Left
					if (TokkenScript.m_gridX != 0) 
					{
						Animation sword = AnimationManager.SwordAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						SquareBehaviour SquareScript = Board[TokkenScript.m_gridX-1,TokkenScript.m_gridY].GetComponent<SquareBehaviour>();
						if(SquareScript.m_isOccuped)
						{
							m_animCount++;
							bool hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Left, true);
							if (hit) 
							{
								StartCoroutine( DelayAnimation(sword, "SwordLeft"));
							}
						}
					}
				}
				// Archer
				else if (TokkenScript.type == "Range") 
				{

					// UP
					if (TokkenScript.m_gridY != 0) 
					{
						Animation arrow = AnimationManager.ArrowAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						int CountSquare = 0;
						int y = TokkenScript.m_gridY -1;
						bool hit = false;
						do 
						{
							m_animCount++;
							CountSquare++;
							SquareBehaviour SquareScript = Board[TokkenScript.m_gridX, y].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{
								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Up);
								
							}
							y--;
						} while (y >= 0 && !hit);
						m_animCount -= CountSquare;
						if (hit) 
						{

							string anim = "ArrowUp" + CountSquare.ToString();
							StartCoroutine(DelayAnimation(arrow,anim ));
							m_animCount = m_animCount + CountSquare -1;

						}

					}
					// Down
					if (TokkenScript.m_gridY != 4) 
					{
						Animation arrow = AnimationManager.ArrowAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						int CountSquare = 0;
						int y = TokkenScript.m_gridY +1;
						bool hit = false;
						do 
						{
							m_animCount++;
							CountSquare++;
							SquareBehaviour SquareScript = Board[TokkenScript.m_gridX, y].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{
								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Down);
							}
							y++;
						} while (y <= 4 && !hit);
						m_animCount -= CountSquare;

						if (hit) 
						{

							string anim = "ArrowDown" + CountSquare.ToString();
							StartCoroutine(DelayAnimation(arrow,anim ));
							m_animCount = m_animCount + CountSquare -1;
						}

					}
					// Right
					if (TokkenScript.m_gridX != 5) 
					{
						Animation arrow = AnimationManager.ArrowAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						int CountSquare = 0;
						int x = TokkenScript.m_gridX +1;
						bool hit = false;
						do 
						{
							m_animCount++;
							CountSquare++;
							SquareBehaviour SquareScript = Board[x, TokkenScript.m_gridY].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{
								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Right);
							}
							x++;
						} while (x <= 5 && !hit);
						m_animCount -= CountSquare;

						if (hit) 
						{
							string anim = "ArrowRight" + CountSquare.ToString();
							StartCoroutine(DelayAnimation(arrow,anim ));
							m_animCount = m_animCount + CountSquare -1;
						}

					}
					// Left
					if (TokkenScript.m_gridX != 0) 
					{
						Animation arrow = AnimationManager.ArrowAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						int CountSquare = 0;
						int x = TokkenScript.m_gridX -1;
						bool hit = false;
						do 
						{
							m_animCount++;
							CountSquare++;
							SquareBehaviour SquareScript = Board[x, TokkenScript.m_gridY].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{
								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Left);
							}
							x--;
						} while (x >= 0 && !hit);
						m_animCount -= CountSquare;

						if (hit) 
						{
							string anim = "ArrowLeft" + CountSquare.ToString();
							StartCoroutine(DelayAnimation(arrow,anim ));
							m_animCount = m_animCount + CountSquare -1;

						}

					}
				}
				// Heavy
				else if (TokkenScript.type == "BigRange") 
				{

					// UP
					if (TokkenScript.m_gridY != 0) 
					{
						Animation rock = AnimationManager.RockAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						int CountSquareTravel = 0;
						int CountSquareHit = 0;
						bool HaveHit = false;
						int y = TokkenScript.m_gridY -1;
						bool hit = false;
						do 
						{
							m_animCount++;
							CountSquareTravel++;
							SquareBehaviour SquareScript = Board[TokkenScript.m_gridX, y].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{
								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Up);
							}
							y--;
						} 
						while (y >= 0 && !hit);
						HaveHit = hit;
						while (y >= 0 && hit) 
						{

							SquareBehaviour SquareScript = Board[TokkenScript.m_gridX, y].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{
								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Up);
								if (hit) 
								{
									m_animCount++;
									CountSquareHit++;
								}
							}
							else 
							{
								hit = false;
							}
							y--;
						}
						m_animCount = m_animCount - CountSquareHit - CountSquareTravel;

						if (HaveHit) 
						{
							//travel animation
							string anim = "RockUp" + CountSquareTravel.ToString();
							StartCoroutine(DelayAnimation(rock, anim));
							m_animCount = m_animCount + CountSquareTravel - 1;
							//Hit animation
							for (int i = 0; i < CountSquareHit; i++) 
							{
								StartCoroutine(DelayAnimation(rock, "RockUpEnd"));
							}
						}
						
					}
					// Down
					if (TokkenScript.m_gridY != 4) 
					{
						Animation rock = AnimationManager.RockAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						int CountSquareTravel = 0;
						int CountSquareHit = 0;
						bool HaveHit = false;
						int y = TokkenScript.m_gridY +1;
						bool hit = false;
						do 
						{
							m_animCount++;
							CountSquareTravel++;
							SquareBehaviour SquareScript = Board[TokkenScript.m_gridX, y].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{
								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Down);
							}
							y++;
						} 
						while (y <= 4 && !hit);
						HaveHit = hit;
						while (y <= 4 && hit) 
						{

							SquareBehaviour SquareScript = Board[TokkenScript.m_gridX, y].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{
								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Down);
								if (hit) 
								{
									m_animCount++;
									CountSquareHit++;
								}
							}
							else 
							{
								hit = false;
							}
							y++;
						}
						
						m_animCount = m_animCount - CountSquareHit - CountSquareTravel;
						if (HaveHit) 
						{
							//travel animation
							string anim = "RockDown" + CountSquareTravel.ToString();
							StartCoroutine(DelayAnimation(rock, anim));
							m_animCount = m_animCount + CountSquareTravel - 1;
							//Hit animation
							for (int i = 0; i < CountSquareHit; i++) 
							{
								StartCoroutine(DelayAnimation(rock, "RockDownEnd"));
							}
						}
					}
					// Right
					if (TokkenScript.m_gridX != 5) 
					{
						Animation rock = AnimationManager.RockAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						int CountSquareTravel = 0;
						int CountSquareHit = 0;
						bool HaveHit = false;
						int x = TokkenScript.m_gridX +1;
						bool hit = false;
						do 
						{
							m_animCount++;
							CountSquareTravel++;
							SquareBehaviour SquareScript = Board[x, TokkenScript.m_gridY].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{
								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Right);
							}
							x++;
						} 
						while (x <= 5 && !hit);
						HaveHit = hit;
						while (x <= 5 && hit) 
						{

							SquareBehaviour SquareScript = Board[x, TokkenScript.m_gridY].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{
								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Right);
								if (hit) 
								{
									m_animCount++;
									CountSquareHit++;
								}
							}
							else 
							{
								hit = false	;
							}
							x++;
						}
						
						m_animCount = m_animCount - CountSquareHit - CountSquareTravel;
						if (HaveHit) 
						{
							//travel animation
							string anim = "RockRight" + CountSquareTravel.ToString();
							StartCoroutine(DelayAnimation(rock, anim));
							m_animCount = m_animCount + CountSquareTravel - 1;
							//Hit animation
							for (int i = 0; i < CountSquareHit; i++) 
							{
								StartCoroutine(DelayAnimation(rock, "RockRightEnd"));
							}
						}
						
					}
					// Left
					if (TokkenScript.m_gridX != 0) 
					{
						Animation rock = AnimationManager.RockAttack (TokkenScript.m_gridX, TokkenScript.m_gridY).GetComponent<Animation>();

						int CountSquareTravel = 0;
						int CountSquareHit = 0;
						bool HaveHit = false;
						int x = TokkenScript.m_gridX -1;
						bool hit = false;
						do 
						{
							m_animCount++;
							CountSquareTravel++;
							SquareBehaviour SquareScript = Board[x, TokkenScript.m_gridY].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{
								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Left);
							}
							x--;
						} 
						while (x >= 0 && !hit);
						HaveHit = hit;
						while (x >= 0 && hit) 
						{
							SquareBehaviour SquareScript = Board[x, TokkenScript.m_gridY].GetComponent<SquareBehaviour>();
							if(SquareScript.m_isOccuped)
							{

								hit = SquareScript.m_tokken.GetComponent<TokkenBehaviour>().DealDamageTo(TokkenScript.m_playedBy,TokkenScript.ATK_Left);
								if (hit) 
								{
									m_animCount++;
									CountSquareHit++;
								}
							}
							else 
							{
								hit = false	;
							}
							x--;
						}
						
						m_animCount = m_animCount - CountSquareHit - CountSquareTravel;
						if (HaveHit) 
						{
							//travel animation
							string anim = "RockLeft" + CountSquareTravel.ToString();
							StartCoroutine(DelayAnimation(rock, anim));
							m_animCount = m_animCount + CountSquareTravel - 1;
							//Hit animation
							for (int i = 0; i < CountSquareHit; i++) 
							{
								StartCoroutine(DelayAnimation(rock, "RockLeftEnd"));
							}
						}
					}
				}
			}
			//EndGame.SetPointCounter(m_finalPointsP1, m_finalPointsP2);
			
		}
		//return Tokken
		return TokkensOrder;
	}

	public void RemoveP1(int Point)
	{
		m_finalPointsP1 -= Point;
	}
	public void RemoveP2(int Point)
	{
		m_finalPointsP2 -= Point;
	}

	IEnumerator DelayAnimation(Animation Anim, string Name)
	{
		m_animCount++;
		yield return new WaitForSeconds(m_animCount * m_delay);
		Anim.PlayQueued(Name, QueueMode.CompleteOthers);
	}
	
	IEnumerator DelayEndGameMessage()
	{

		yield return new WaitForSeconds((m_animCount * m_delay) + 2f);
		bool? result = null;
		if (m_finalPointsP1 > m_finalPointsP2) 
		{
			result = true;
			//win
			m_bulleBehaviour.EndGame(true);
		}
		if (m_finalPointsP1 < m_finalPointsP2) 
		{
			result = false;
			//loose
			m_bulleBehaviour.EndGame(false);
		}
		m_endGame.VictoryGameMessage(result);
	}

	public void HoverCubeOn(int x, int y)
	{
		int xMax = m_cubes.GetLength (0);
		int yMax = m_cubes.GetLength (1);
		
		if (x >= 0 && y >= 0 && x < xMax && y < yMax) 
		{
			if (m_cubes [x, y] != null) {
				m_cubes [x, y].GetComponent<SquareBehaviour> ().OverOn ();
			}
		}
	}

	public void HoverCubeOff(int x, int y)
	{
		int xMax = m_cubes.GetLength (0);
		int yMax = m_cubes.GetLength (1);

		if (x >= 0 && y >= 0 && x < xMax && y < yMax) 
		{
			if (m_cubes [x, y] != null) {
				m_cubes [x, y].GetComponent<SquareBehaviour> ().OverOff ();
			}
		}
	}

	public void ChangeTextureCubes(int x, int y, Material texture)
	{
		int xMax = m_cubes.GetLength (0);
		int yMax = m_cubes.GetLength (1);
		
		if (x >= 0 && y >= 0 && x < xMax && y < yMax) 
		{
			m_cubes [x, y].GetComponent<SquareBehaviour> ().ChangeMaterialFast (texture);
		}
	}


	#endregion
	
	#region Private Variable

	public int m_finalPointsP1 = 0;
	public int m_finalPointsP2 = 0;

	private TimerBehaviour m_timer;
	private GameObject m_hand;

	private EndGameUIManager m_endGame;


	#endregion
}
