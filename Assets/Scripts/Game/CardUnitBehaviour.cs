using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardUnitBehaviour : CardBehaviour
{

    #region Public Variable
    public GameObject m_HP;

    public GameObject m_ATK_Up;
    public GameObject m_ATK_Right;
    public GameObject m_ATK_Down;
    public GameObject m_ATK_Left;

    public GameObject m_Speed;

	public GameObject m_Illustration;

    public GameObject m_Rubis1;
    public GameObject m_Rubis2;
    public GameObject m_Rubis3;
    public GameObject m_Rubis4;
    public GameObject m_Rubis5;

    public Sprite m_bigRange;
    public Sprite m_range;
    public Sprite m_cac;

	public List<Sprite> m_illustrations;
	
    public int m_price;
    public string m_type;

    #endregion

    #region Main Methodes

    void start()
    {

    }

    #endregion

    #region Utils

	public void copy(CardUnitBehaviour c1)
	{
		this.ATK_Down = c1.ATK_Down;
		this.ATK_Left = c1.ATK_Left;
		this.ATK_Right = c1.ATK_Right;
		this.ATK_Up = c1.ATK_Up;
		this.HP = c1.HP;
		this.Speed = c1.Speed;

		this.m_Illustration.GetComponent<Image>().sprite = c1.m_Illustration.GetComponent<Image>().sprite;

		this.m_name.GetComponent<Text>().text = c1.m_name.GetComponent<Text>().text;
		this.m_HP.GetComponent<Text>().text = c1.m_HP.GetComponent<Text>().text;

		this.m_Description1.GetComponent<Text>().text = c1.m_Description1.GetComponent<Text>().text;
		this.m_Description2.GetComponent<Text>().text = c1.m_Description2.GetComponent<Text>().text;
		this.m_Description3.GetComponent<Text>().text = c1.m_Description3.GetComponent<Text>().text;

		this.m_ATK_Down.GetComponent<Text>().text = c1.m_ATK_Down.GetComponent<Text>().text;
		this.m_ATK_Up.GetComponent<Text>().text = c1.m_ATK_Up.GetComponent<Text>().text;
		this.m_ATK_Right.GetComponent<Text>().text = c1.m_ATK_Right.GetComponent<Text>().text;
		this.m_ATK_Left.GetComponent<Text>().text = c1.m_ATK_Left.GetComponent<Text>().text;
		
		this.m_Speed.GetComponent<Text>().text = c1.m_Speed.GetComponent<Text>().text;

		this.m_type = c1.m_type;
	}

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
