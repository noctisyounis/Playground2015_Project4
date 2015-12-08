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
	public GameObject m_player1PointFinal;
	public GameObject m_player2PointFinal;
	public GameObject m_counter;
	public GameObject m_CardHolderGui;
	public Sprite m_victory;
	public Sprite m_tie;
	public Sprite m_defait;

	public AudioSource m_audio;
	public AudioClip m_click;
	public AudioClip m_victorySFX;
	public AudioClip m_tieSFX;
	public AudioClip m_defaitSFX;

	#endregion
	
	#region Main Methodes
	
	public void Start()
	{
		EndGameUIVisible(false);
		m_CardHolderGui.SetActive(true);
		m_player1Point.GetComponent<Text>().enabled = false;
		m_player2Point.GetComponent<Text>().enabled = false;
		m_player1PointFinal.GetComponent<Text>().enabled = false;
		m_player2PointFinal.GetComponent<Text>().enabled = false;
	}
	
	
	#endregion
	
	#region Utils

	public void ShowPointsCounter()
	{
		Text[] TesxtUI = m_counter.GetComponentsInChildren<Text>();
		m_counter.GetComponent<Image>().enabled = true;
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
		m_player1PointFinal.GetComponent<Text>().text = Player1.ToString();
		m_player2PointFinal.GetComponent<Text>().text = Player2.ToString();
	}

	public void VictoryGameMessage(bool? IsVictory)
	{

		switch (IsVictory) 
		{
			case null:
				m_resultText.GetComponent<Image>().sprite = m_tie;
				m_audio.PlayOneShot(m_tieSFX);
				break;
			case true:
				m_resultText.GetComponent<Image>().sprite = m_victory;
				m_audio.PlayOneShot(m_victorySFX);
				break;
			case false:
				m_resultText.GetComponent<Image>().sprite = m_defait ;
				m_audio.PlayOneShot(m_defaitSFX);
				break;
		}

		EndGameUIVisible(true);

	}

	public void ReturnToMenu()
	{
		m_audio.PlayOneShot(m_click);
		Debug.Log("ReturnToMenu");
		Application.LoadLevel(m_menu);
	}

	#endregion
	
	#region Private Variable
	

	#endregion
}
