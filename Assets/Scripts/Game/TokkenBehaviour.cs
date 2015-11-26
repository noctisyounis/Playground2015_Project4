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


    public string m_pictures;

    public int m_playedAtTurn;

    public int m_gridX;
    public int m_gridY;

    #endregion

    #region Main Methodes




    #endregion

    #region Utils
    public static GameObject CreateTokken(CardUnitBehaviour Card, Vector3 position, Quaternion rotation, bool playerTurn)
    {
        GameObject prefab;
        if (playerTurn)
        {
            prefab = (GameObject)Resources.Load("PlayerTokken", typeof(GameObject));
        }
        else
        {
            prefab = (GameObject)Resources.Load("PlayerTokken", typeof(GameObject));
        }
        TokkenBehaviour script = prefab.GetComponent<TokkenBehaviour>();
        
        script.m_hp.GetComponent<Text>().text = Card.m_HP.GetComponent<Text>().text;
        script.m_ATK_Up.GetComponent<Text>().text = Card.m_ATK_Up.GetComponent<Text>().text;
        script.m_ATK_Right.GetComponent<Text>().text = Card.m_ATK_Right.GetComponent<Text>().text;
        script.m_ATK_Down.GetComponent<Text>().text = Card.m_ATK_Down.GetComponent<Text>().text;
        script.m_ATK_Left.GetComponent<Text>().text = Card.m_ATK_Left.GetComponent<Text>().text;
        script.m_speed.GetComponent<Text>().text = Card.m_Speed.GetComponent<Text>().text;

        GameObject Tokken = (GameObject)Instantiate(prefab, position, rotation);

        TokkenBehaviour TokkenB = (TokkenBehaviour)Tokken.GetComponent<TokkenBehaviour>();

        TokkenB.hp = int.Parse(Card.m_HP.GetComponent<Text>().text);
        TokkenB.ATK_Up = int.Parse(Card.m_ATK_Up.GetComponent<Text>().text);
        TokkenB.ATK_Right = int.Parse(Card.m_ATK_Right.GetComponent<Text>().text);
        TokkenB.ATK_Down = int.Parse(Card.m_ATK_Down.GetComponent<Text>().text);
        TokkenB.ATK_Left = int.Parse(Card.m_ATK_Left.GetComponent<Text>().text);

        TokkenB.speed = int.Parse(Card.m_Speed.GetComponent<Text>().text);

        TokkenB.victoryPoint = Card.PropVictory_Point;

        TokkenB.name = Card.m_name.GetComponent<Text>().text;

        TokkenB.type = Card.m_type;

        TokkenB.descriptionL1 = Card.m_Description1.GetComponent<Text>().text;
        TokkenB.descriptionL2 = Card.m_Description2.GetComponent<Text>().text;
        TokkenB.descriptionL3 = Card.m_Description3.GetComponent<Text>().text;



        return Tokken;
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
    #endregion
}
