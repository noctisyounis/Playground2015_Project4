using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum e_containedBy
{
	Inventory,
	DeckList,
	DeckVisual
}
public class OnClickBehaviour : MonoBehaviour 
{
	#region Public Variable
	public AudioClip m_son;
	public e_containedBy m_container;
	public int m_id;
	public static int m_nbUnit = 18;
	public static int m_nbLands = 5;
	public GameObject m_textError;
	public Text m_stringError;

	#endregion
	
	#region Main method
	
	
	void Start()
	{
//		audio = GetComponent<AudioSource>();
		m_textError = GameObject.Find("TextError");
		m_stringError = m_textError.GetComponent<Text>();
	}
	
	public void OnMouseUp()
	{
//		audio.PlayOneShot(m_son);
		bool isUnit = false;
		if(gameObject.GetComponent<CardUnitBehaviour>()!= null)
		{
			isUnit = true;
		}

		switch (m_container)
		{

			/* Condition : 
			 * 		- Unit = 18
			 * 		- Land = 5
			 * 		(- Move = 9)
			 */
				
			case e_containedBy.Inventory:
				

				if (isUnit)
				{
					if(m_nbUnit < 18)
					{
						Debug.Log("-- Inventory into Deck (CardUnit)");
						GameObject copy = Instantiate(gameObject);
						copy.GetComponent<OnClickBehaviour>().m_container = e_containedBy.DeckList;
						copy.GetComponent<RectTransform>().localScale = Vector3.one;
						DeckBehaviour.m_deck.Add(copy);
						m_nbUnit ++;
					}
					else
					{
						m_stringError.text = "Plus de place pour ce type de carte!";
						Debug.Log("Your units is full");
						// Popup : Vous n'avez plus de place pour ce type de carte !
					}
				}
				else if(!isUnit)
				{
					if(m_nbLands < 5)
					{
						Debug.Log("-- Inventory into Deck (CardLand)");
						GameObject copy = Instantiate(gameObject);
						copy.GetComponent<OnClickBehaviour>().m_container = e_containedBy.DeckList;
						copy.GetComponent<RectTransform>().localScale = Vector3.one;
						DeckBehaviour.m_deck.Add(copy);
						m_nbLands ++;
						
					}
					else
					{
						m_stringError.text = "Plus de place pour ce type de carte!";
						Debug.Log("Your cards lands is full");
						
						// Popup : Vous n'avez plus de place pour ce type de carte !
					}
				}
				else
				{
					Debug.Log(" !!! Type doesn't exist! BUG !!!");
				}

				break;

			case e_containedBy.DeckList:
				if (isUnit) 
				{
					m_nbUnit -= 1 ;
					Debug.Log("nombre d'unité : " + m_nbUnit);
				}
				else if (!isUnit)
				{
					m_nbLands -= 1 ;
					Debug.Log("nombre de land : " + m_nbLands);
				}
				else
				{

				}
				DeckBehaviour.m_deck.Remove(gameObject);
				GameObject.Destroy(gameObject);
				
				Debug.Log("--- Card Deleted");
				
				break;

			case e_containedBy.DeckVisual:

				for (int i = 0; i < DeckBehaviour.m_deck.Count; i++) 
				{
					if (DeckBehaviour.m_deck[i] != null && DeckBehaviour.m_deck[i].GetComponent<CardBehaviour>().m_id == gameObject.GetComponent<OnClickBehaviour>().m_id) 
					{
						Debug.Log("I found card with ID : " + DeckBehaviour.m_deck[i].GetComponent<CardBehaviour>().m_id.ToString());
						GameObject.Destroy(DeckBehaviour.m_deck[i]);
						DeckBehaviour.m_deck.Remove(DeckBehaviour.m_deck[i]);
						if (gameObject.GetComponent<OnClickBehaviour>().m_id < 1000) 
						{
							m_nbUnit -= 1 ;
							Debug.Log("nombre d'unité : " + m_nbUnit);
						}
						else if (gameObject.GetComponent<OnClickBehaviour>().m_id > 1000)
						{
							m_nbLands -= 1 ;
							Debug.Log("nombre de land : " + m_nbLands);
						}
						else
						{
							
						}
						break;
					}
				}
				break;
		}
	}
	
	#endregion
	#region Utils
	
	#endregion
	
	#region Private Variable
	
//	private AudioSource audio;
	
	#endregion
}
