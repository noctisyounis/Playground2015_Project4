using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Linq;



public class HandBehaviour : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler 
{
	#region Public Variable

	public List<GameObject> m_deck = new List<GameObject>();

	#endregion

	#region Main Methodes

	public void Start()
	{
		LoadDeck();
		for (int i = 0; i < 5; i++) 
		{
			Draw();

		}
	}

	public void OnPointerEnter(PointerEventData eventData) 
	{
		if (eventData.pointerDrag != null) 
		{
			DraggableBehaviour d = eventData.pointerDrag.GetComponent<DraggableBehaviour>();
			if(d != null) 
			{
				d.m_placeholderParent = this.transform;
			}
		}


	}
	
	public void OnPointerExit(PointerEventData eventData) 
	{
		if (eventData.pointerDrag != null) 
		{
			DraggableBehaviour d = eventData.pointerDrag.GetComponent<DraggableBehaviour>();
			if(d != null && d.m_placeholderParent==this.transform) 
			{
				d.m_placeholderParent = d.m_parentToReturnTo;
			};
		}
		

	}
	
	public void OnDrop(PointerEventData eventData) 
	{
		//Debug.Log ("Drop Hand");

		DraggableBehaviour d = eventData.pointerDrag.GetComponent<DraggableBehaviour>();
		if(d != null) 
		{
			d.m_parentToReturnTo = this.transform;
		}
		
	}
	#endregion
	
	#region Utils

	private void LoadDeck()
	{
		GameObject prefab = (GameObject)Resources.Load ("Card", typeof(GameObject));
		GameObject deck = GameObject.Find("PlayerDeck");
		m_deck.Clear();
		for (int i = 1 ; i < 19; i++) {
			GameObject Card = (GameObject)Instantiate(prefab);
			Card.transform.SetParent(deck.transform);
			Card.name = "Card"+i.ToString();
			m_deck.Add(Card);
		}
		Shuffle(m_deck);
	}

	public void Draw()
	{
		if (m_deck.Count>0) 
		{
			GameObject Card = m_deck [0];
			m_deck.Remove (Card);
			Card.transform.SetParent (gameObject.transform);
			Card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
		}
	} 

	private void Shuffle(List<GameObject> list)  
	{  
		int n = list.Count;

		while (n > 1) 
		{
			float rnd = Random.Range(0, n);
			if (rnd == n) 
			{
				rnd--;
			}
			int k = (int)Mathf.Floor(rnd);
			n--;
			GameObject value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}

	public void ForcePlay(BoardBehaviour scriptBoard)
	{
		List<GameObject> squares = GameObject.Find("Board").GetComponent<BoardBehaviour>().m_cubes.ToList();
		squares.RemoveAll(x => x.GetComponent<SquareBehaviour>().m_isOccuped);
		int index = (int)Mathf.Floor( Random.Range(0,squares.Count));

		//TODO Release Drag
		int cardIndex = (int) Mathf.Floor( Random.Range(0,gameObject.transform.childCount));

		GameObject card = gameObject.transform.GetChild(cardIndex).gameObject;

		scriptBoard.PutTokken(squares[index],card);


	}

	#endregion
	
	#region Private Variable

	#endregion
}
