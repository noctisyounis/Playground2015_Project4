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

	#endregion
	
	#region Main method
	
	
	void Start()
	{
//		audio = GetComponent<AudioSource>();
	}
	
	public void OnMouseUp()
	{
//		audio.PlayOneShot(m_son);
		Debug.Log("click here");

		switch (m_container)
		{
			case e_containedBy.Inventory:
				// prefab DeckList
				m_container = e_containedBy.DeckList;
//				GameObject copy = gameObject.Equals();
				//modif gameObject? 
				GameObject copy = Instantiate(gameObject);
				//copy.transform.localScale = new Vector3(2.179837f, 2.179837f, 2.179837f);
				DeckBehaviour.m_deck.Add(copy);

				break;

			case e_containedBy.DeckList:
				// commentaires
				Debug.Log("--- Click on : " + gameObject);

				// suppr GameObjet?
				DeckBehaviour.m_deck.Remove(gameObject);
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
