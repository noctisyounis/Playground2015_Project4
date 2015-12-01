using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardGroundBehaviour : CardBehaviour {

	#region Public Variable

	public Sprite m_mountain;
	public Sprite m_swamp;
	public Sprite m_ruin;
	public Sprite m_plain;
	public Sprite m_forest;

	public string m_type;

	public ArrayList xValue = new ArrayList ();
	public ArrayList yValue = new ArrayList ();
	
	#endregion
	
	#region Main Methodes


	public void Copy(CardGroundBehaviour CGB)
	{
		this.m_Description1.GetComponent<Text>().text = CGB.m_Description1.GetComponent<Text>().text;
		this.m_Description2.GetComponent<Text>().text = CGB.m_Description2.GetComponent<Text>().text;
		this.m_Description3.GetComponent<Text>().text = CGB.m_Description3.GetComponent<Text>().text;
		this.m_name.GetComponent<Text>().text = CGB.m_name.GetComponent<Text>().text;

		this.m_type = CGB.m_type;
	}
	
	#endregion
	
	#region Utils


	
	#endregion
	
	#region Private Variable
	
	#endregion

}
