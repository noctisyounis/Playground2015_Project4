using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TokkenBehaviour : MonoBehaviour
{

    #region Public Variable

    public GameObject m_hp;

    public GameObject m_ATK_Up;
    public GameObject m_ATK_Right;
    public GameObject m_ATK_Down;
    public GameObject m_ATK_Left;

    public GameObject m_speed;

    public GameObject m_Rubis1;
    public GameObject m_Rubis2;
    public GameObject m_Rubis3;
    public GameObject m_Rubis4;
    public GameObject m_Rubis5;

    public Sprite m_Cac;
    public Sprite m_Range;
    public Sprite m_BigRange;

    public string m_pictures;

    public int m_playedAtTurn;

    public int m_gridX;
	public int m_gridY;

	public enum Player {Player1,Player2};
	public Player m_playedBy ;

	#endregion

    #region Main Methodes

	public void Start()
	{
		m_board = GameObject.FindObjectOfType<BoardBehaviour>();
	}

    #endregion

    #region Utils

	

    public static GameObject CreateTokken(CardUnitBehaviour Card, Vector3 position, Quaternion rotation, bool playerTurn)
    {
        GameObject prefab;
		Player PlayedBy;
        
        if (playerTurn)
        {
            prefab = (GameObject)Resources.Load("PlayerTokken", typeof(GameObject));
            
			PlayedBy = Player.Player1;
        }
        else
        {
            prefab = (GameObject)Resources.Load("OpponentTokken", typeof(GameObject));
            
			PlayedBy = Player.Player2;
        }

        TokkenBehaviour script = prefab.GetComponent<TokkenBehaviour>();
        switch (Card.m_type)
        {
            case "BigRange":
                Debug.Log("big");
                prefab.GetComponent<Image>().sprite = script.m_BigRange;
                break;
            case "Range":
                Debug.Log("range");
                prefab.GetComponent<Image>().sprite = script.m_Range;
                break;
            case "Close":
                Debug.Log("cac");
                prefab.GetComponent<Image>().sprite = script.m_Cac;
                
                break;
        }

        int cost = Card.m_price; 
        int Rubis = 1;
        while (cost > 0)
        {
            Image image = script.m_Rubis1.GetComponent<Image>();
            switch (Rubis)
            {
                case 1: image = script.m_Rubis1.GetComponent<Image>();
                    break;
                case 2: image = script.m_Rubis2.GetComponent<Image>();
                    break;
                case 3: image = script.m_Rubis3.GetComponent<Image>();
                    break;
                case 4: image = script.m_Rubis4.GetComponent<Image>();
                    break;
                case 5: image = script.m_Rubis5.GetComponent<Image>();
                    break;
            }
            if (cost >= 10)
            {
                image.color = Color.red;
                cost = cost - 10;
                Rubis++;
            }
            else if (cost >= 5)
            {
                image.color = Color.blue;
                cost = cost - 5;
                Rubis++;
            }
            else if (cost < 5)
            {
                image.color = Color.green;
                cost = cost - 1;
                Rubis++;
            }

        }
		script.m_hp.GetComponent<Text> ().text = Card.m_HP.GetComponent<Text> ().text;
		script.m_ATK_Up.GetComponent<Text> ().text = Card.m_ATK_Up.GetComponent<Text> ().text;
		script.m_ATK_Right.GetComponent<Text> ().text = Card.m_ATK_Right.GetComponent<Text> ().text;
		script.m_ATK_Down.GetComponent<Text> ().text = Card.m_ATK_Down.GetComponent<Text> ().text;
		script.m_ATK_Left.GetComponent<Text> ().text = Card.m_ATK_Left.GetComponent<Text> ().text;
		script.m_speed.GetComponent<Text> ().text = Card.m_Speed.GetComponent<Text> ().text;

		GameObject Tokken = (GameObject)Instantiate (prefab, position, rotation);

		TokkenBehaviour TokkenB = (TokkenBehaviour)Tokken.GetComponent<TokkenBehaviour> ();

		TokkenB.m_playedBy = PlayedBy;

		TokkenB.hp = int.Parse (Card.m_HP.GetComponent<Text> ().text);
		TokkenB.ATK_Up = int.Parse (Card.m_ATK_Up.GetComponent<Text> ().text);
		TokkenB.ATK_Right = int.Parse (Card.m_ATK_Right.GetComponent<Text> ().text);
		TokkenB.ATK_Down = int.Parse (Card.m_ATK_Down.GetComponent<Text> ().text);
		TokkenB.ATK_Left = int.Parse (Card.m_ATK_Left.GetComponent<Text> ().text);


		TokkenB.speed = int.Parse (Card.m_Speed.GetComponent<Text> ().text);

		TokkenB.victoryPoint =  Card.m_price;

		TokkenB.name = Card.m_name.GetComponent<Text> ().text;

		TokkenB.type = Card.m_type;

		TokkenB.descriptionL1 = Card.m_Description1.GetComponent<Text> ().text;
		TokkenB.descriptionL2 = Card.m_Description2.GetComponent<Text> ().text;
		TokkenB.descriptionL3 = Card.m_Description3.GetComponent<Text> ().text;
		
		return Tokken;
	}

	public bool DealDamageTo(Player AttackedBy ,int Damage)
	{
		bool hit = (hp > 0);

		if (hit) 
		{
			if (AttackedBy != m_playedBy) 
			{
				hp -= Damage;
				m_hp.GetComponent<Text>().text = hp.ToString();
				m_hp.GetComponent<Text>().color = Color.blue;
				if (hp <= 0) 
				{
					gameObject.GetComponent<Canvas> ().enabled = false;
					GameObject square = GameObject.FindObjectOfType<BoardBehaviour> ().m_cubes [m_gridX, m_gridY];
					square.GetComponent<SquareBehaviour> ().m_isOccuped = false;
					if (m_playedBy == Player.Player1) 
					{
						m_board.RemoveP1(victoryPoint);

					}
					else 
					{
						m_board.RemoveP2(victoryPoint);
					}
				}
			}

		}

		return hit;
	}

	public void SetPosition(int x,int y)
	{
		m_gridX = x;
		m_gridY = y;
	}

    #endregion

    #region Private Variable
    private int _hp;
    public int hp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    private int _ATK_Up;
    public int ATK_Up
    {
        get { return _ATK_Up; }
        set { _ATK_Up = value; }
    }
    private int _ATK_Right;
    public int ATK_Right
    {
        get { return _ATK_Right; }
        set { _ATK_Right = value; }
    }
    private int _ATK_Down;
    public int ATK_Down
    {
        get { return _ATK_Down; }
        set { _ATK_Down = value; }
    }
    private int _ATK_Left;
    public int ATK_Left
    {
        get { return _ATK_Left; }
        set { _ATK_Left = value; }
    }
    private int _speed;
    public int speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    private int _victoryPoint;
    public int victoryPoint
    {
        get { return _victoryPoint; }
        set { _victoryPoint = value; }
    }
    private string _name;
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    private string _type;

    public string type
    {
        get { return _type; }
        set { _type = value; }
    }

    private string _descriptionL1;
    public string descriptionL1
    {
        get { return _descriptionL1; }
        set { _descriptionL1 = value; }
    }
    private string _descriptionL2;
    public string descriptionL2
    {
        get { return _descriptionL2; }
        set { _descriptionL2 = value; }
    }
    private string _descriptionL3;
    public string descriptionL3
    {
        get { return _descriptionL3; }
        set { _descriptionL3 = value; }
    }

	private BoardBehaviour m_board;
    #endregion
}
