using UnityEngine;
using System.Collections;

public class OnCkickBehaviour : MonoBehaviour {

	public enum e_containedBy
	{
		Inventory,
		DeckList
	}

	#region Public Variable
	public AudioClip m_son;
	public string m_levelSuivant = "Quitter";
	public e_containedBy m_container;
	//	= e_containedBy.Inventory
	// Il faut que j'initialise m_container : dans l'inventaire : e_containedBy.Inventory
	//												le deck 	: e_containedBy.DeckList

	#endregion
	
	#region Main method
	
	
	void Start()
	{
		audio = GetComponent<AudioSource>();
	}
	
	void OnMouseUp()
	{
		audio.PlayOneShot(m_son);

		switch (m_container)
		{
			case e_containedBy.Inventory:
			// prefab DeckList ? 
			// m_container = e_containedBy.DeckList;
				break;

			case e_containedBy.DeckList:
			// suppr Game Objet?
				break;
		}
	}
	
	#endregion
	#region Utils
	
	#endregion
	
	#region Private Variable
	
	private AudioSource audio;
	
	#endregion
}
