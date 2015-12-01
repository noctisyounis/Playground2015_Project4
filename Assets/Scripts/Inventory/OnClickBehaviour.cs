using UnityEngine;
using System.Collections;

public enum e_containedBy
{
	Inventory,
	DeckList
}
public class OnClickBehaviour : MonoBehaviour 
{
	#region Public Variable
	public AudioClip m_son;
	public e_containedBy m_container;
	public int m_id;
	public static int m_nbUnit = 18;
	public static int m_nbLands = 5;

	#endregion
	
	#region Main method
	
	
	void Start()
	{
//		audio = GetComponent<AudioSource>();
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
						// Change prefab /!\
						DeckBehaviour.m_deck.Add(copy);
						m_nbUnit ++;
					}
					else
					{
						Debug.Log("Your units is full");
					}
				}
				else if(!isUnit)
				{
					if(m_nbLands < 5)
					{
						Debug.Log("-- Inventory into Deck (CardLand)");
						GameObject copy = Instantiate(gameObject);
						copy.GetComponent<OnClickBehaviour>().m_container = e_containedBy.DeckList;
						// Change prefab /!\
						DeckBehaviour.m_deck.Add(copy);
						m_nbLands ++;
						
					}
					else
					{
						Debug.Log("Your cards lands is full");
					}
				}
				else
				{
					Debug.Log(" !!! Type doesn't exist! BUG !!!");
				}

				break;

			case e_containedBy.DeckList:
				// suppr GameObjet
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
		}
	}
	
	#endregion
	#region Utils
	
	#endregion
	
	#region Private Variable
	
//	private AudioSource audio;
	
	#endregion
}
