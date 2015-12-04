using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;


public class EndGameUIManager : MonoBehaviour {

	#region Public Variable

	public string m_menu = "menu";
	public GameObject m_resultText;
	public GameObject m_player1Point;
	public GameObject m_player2Point;
	public GameObject m_counter;
	public GameObject m_CardHolderGui;
	public Sprite m_victory;
	public Sprite m_tie;
	public Sprite m_defait;
	
	#endregion
	
	#region Main Methodes
	
	public void Start()
	{
		EndGameUIVisible(false);
		m_CardHolderGui.SetActive(true);
	}
	
	
	#endregion
	
	#region Utils

	public void ShowPointsCounter()
	{
		Text[] TesxtUI = m_counter.GetComponentsInChildren<Text>();

		foreach (Text item in TesxtUI) 
		{
				item.enabled = true;
		}

		m_CardHolderGui.SetActive(false);

	}

	public void EndGameUIVisible(bool IsVisible)
	{
		Text[] TextUI = gameObject.GetComponentsInChildren<Text>();
		
		foreach (Text item in TextUI) 
		{
			item.enabled = IsVisible;
		}

		Image[] ImageUI = gameObject.GetComponentsInChildren<Image>();

		foreach (Image item in ImageUI) 
		{
			item.enabled = IsVisible;
		}

		Button[] ButtonUI = gameObject.GetComponentsInChildren<Button>();

		foreach (Button item in ButtonUI) 
		{
			item.enabled = IsVisible;
		}
	}

	public void SetPointCounter(int Player1, int Player2)
	{
		m_player1Point.GetComponent<Text>().text = Player1.ToString();
		m_player2Point.GetComponent<Text>().text = Player2.ToString();
	}

	public void VictoryGameMessage(bool? IsVictory)
	{

		switch (IsVictory) 
		{
			case null:
				m_resultText.GetComponent<Image>().sprite = m_tie;
				break;
			case true:
				m_resultText.GetComponent<Image>().sprite = m_victory;
				break;
			case false:
				m_resultText.GetComponent<Image>().sprite = m_defait ;
				break;
		}

		EndGameUIVisible(true);

	}

	public void ReturnToMenu()
	{
		Debug.Log("ReturnToMenu");
		Application.LoadLevel(m_menu);
	}

	#endregion
	
	#region Private Variable
	

	#endregion
}
