using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardUnitBehaviour : CardBehaviour
{

    #region Public Variable
    public GameObject m_HP;

    public GameObject m_ATK_Up;
    public GameObject m_ATK_Right;
    public GameObject m_ATK_Down;
    public GameObject m_ATK_Left;

    public GameObject m_Speed;
    public int m_price;
    public string m_type;



    #endregion

    #region Main Methodes

    void start()
    {

    }

    #endregion

    #region Utils

    #endregion

    #region Private Variable
    private int ID;

    public int PropID
    {
        get { return ID; }
        set { ID = value; }
    }

    private int HP;

    public int PropHP
    {
        get { return HP; }
        set { HP = value; }
    }
    private int ATK_Up;
    public int PropATK_Up
    {
        get { return ATK_Up; }
        set { ATK_Up = value; }
    }
    private int ATK_Right;
    public int PropATK_Right
    {
        get { return ATK_Right; }
        set { ATK_Right = value; }
    }
    private int ATK_Down;
    public int PropATK_Down
    {
        get { return ATK_Down; }
        set { ATK_Down = value; }
    }
    private int ATK_Left;
    public int PropATK_Left
    {
        get { return ATK_Left; }
        set { ATK_Left = value; }
    }
    private int Speed;
    public int PropSpeed
    {
        get { return Speed; }
        set { Speed = value; }
    }
    private int Victory_Point;
    public int PropVictory_Point
    {
        get { return Victory_Point; }
        set { Victory_Point = value; }
    }
    #endregion
}
