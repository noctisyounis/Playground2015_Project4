using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;


public class EndGameUIManager : MonoBehaviour {

	#region Public Variable

	public string m_menu = "menu";
	
	#endregion
	
	#region Main Methodes
	
	public void Start()
	{
		EndGameUIVisible(false);

		m_player1Point = GameObject.Find("Player1Points").GetComponent<Text>();
		m_player2Point = GameObject.Find("Player2Points").GetComponent<Text>();



	}
	
	
	#endregion
	
	#region Utils

	public void ShowPointsCounter()
	{
		Text[] TesxtUI = gameObject.transform.FindChild("Counter").GetComponentsInChildren<Text>();

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
		m_player1Point.text = Player1.ToString();
		m_player2Point.text = Player2.ToString();
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
		gameObject.transform.FindChild("ResultText").GetComponent<Text>().text = Message;

		EndGameUIVisible(true);

	}

	public void ReturnToMenu()
	{
		Application.LoadLevel(m_menu);
	}

	#endregion
	
	#region Private Variable

	private Text m_player1Point;
	private Text m_player2Point;

	#endregion
}
