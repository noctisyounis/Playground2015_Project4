using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulleBehaviour : MonoBehaviour {

	#region Public Variable
	public Text m_text ;
	private BulleScript bulleScript;

	public Sprite m_bulleWhite;
	public Sprite m_bulleRed;
	#endregion

	#region private Variable
	private Image bulle;
	#endregion

	#region Main Method
	void Start () {
		bulle = GetComponent<Image>();
		bulleScript = new BulleScript();
		m_text.text = bulleScript.WelcomeMessage();
		m_text.enabled = true;
		bulle.sprite = m_bulleWhite;
		bulle.enabled = true;
		Invoke("HiddenObject",4f);

		StartCoroutine(Story());

	}
	#endregion

	#region Second Method

	IEnumerator Story()
	{
		while (true) 
		{
			float time = Random.Range(45f, 90f);
			//float time = 5f;
			yield return new WaitForSeconds(time);
			
			m_text.color = Color.black;
			m_text.enabled = true;
			bulle.sprite = m_bulleWhite;
			bulle.enabled = true;
			
			m_text.text = bulleScript.Story();
			Invoke("HiddenObject",2f);
		}

	}

	void HiddenObject()
	{
		m_text.enabled = false;
		bulle.enabled = false;
	}

	public void changeTextBulleEndTurn()
	{
		m_text.color = Color.white;
		m_text.enabled = true;
		bulle.sprite = m_bulleRed;
		bulle.enabled = true;

		m_text.text = bulleScript.TimerIsOver();
		Invoke("HiddenObject",2f);
	}

	public void TurnLands()
	{
		m_text.color = Color.black;
		m_text.enabled = true;
		bulle.sprite = m_bulleWhite;
		bulle.enabled = true;
		
		m_text.text = bulleScript.TurnLands();
		Invoke("HiddenObject",2f);
	}

	public void TurnUnits()
	{
		m_text.color = Color.black;
		m_text.enabled = true;
		bulle.sprite = m_bulleWhite;
		bulle.enabled = true;
		
		m_text.text = bulleScript.TurnUnits();
		Invoke("HiddenObject",2f);
	}

	public void ErrorUnit(string type)
	{
		m_text.color = Color.white;
		m_text.enabled = true;
		bulle.sprite = m_bulleRed;
		bulle.enabled = true;

		m_text.text = bulleScript.ErrorUnit(type);
		Invoke("HiddenObject",2f);
	}
	public void EndGame(bool isWin)
	{
		m_text.color = Color.black;
		m_text.enabled = true;
		bulle.sprite = m_bulleWhite;
		bulle.enabled = true;
		
		m_text.text = bulleScript.EndGame(isWin);
		Invoke("HiddenObject",2f);
	}

	#endregion
}
