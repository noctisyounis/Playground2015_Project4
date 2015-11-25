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
	
	#endregion
	
	#region Main Methodes
	
	public void Start()
	{
		EndGameUIVisible(false);

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
		string Message;
		switch (IsVictory) {
		case null:
			Message = "Tie";
			break;
		case false:
			Message = "Defait";
			break;
		default:
			Message = "Victory";
			break;
		}
		m_resultText.GetComponent<Text>().text = Message;

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
