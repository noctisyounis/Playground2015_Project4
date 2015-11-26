using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Linq;



public class HandBehaviour : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler 
{
	#region Public Variable
    public Sprite m_bigRange;
    public Sprite m_range;
    public Sprite m_cac;
	public List<GameObject> m_deck = new List<GameObject>();
	public GameObject PlayerDeck;

	#endregion

	#region Main Methodes

	public void Start()
	{
		m_board = GameObject.FindObjectOfType<BoardBehaviour>();
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
			}
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
        GameObject prefab = (GameObject)Resources.Load("Card", typeof(GameObject));
        m_deck.Clear();
        ReadDeckBehaviour deckList = new ReadDeckBehaviour();
        ReadXmlBehaviour cardList = new ReadXmlBehaviour(m_range,m_bigRange,m_cac);    
        for (int i = 0; i < deckList.PropDeck.Count; i++)
        {
            int id = int.Parse(deckList.PropDeck[i].ToString());
            GameObject Card = GameObject.Instantiate((GameObject)cardList.List[id - 1]);
            Card.transform.SetParent(PlayerDeck.transform);
			Card.AddComponent<DraggableBehaviour>();
            Card.name = "Card" + i.ToString();
            m_deck.Add(Card);
        }
		//Debug.Log("taille du deck player :" + m_deck.Count);
        Shuffle(m_deck);
    }

	public void Draw()
	{
		//Debug.Log("taille du deck player :" + m_deck.Count);
		if (m_deck.Count > 0) 
		{
			//Debug.Log("Test");
			GameObject Card = m_deck [0];
			m_deck.Remove (Card);
			Card.transform.SetParent (gameObject.transform);
			Card.GetComponent<RectTransform>().localScale = new Vector3(1.0f,1.0f,1.0f);
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
		List<GameObject> squares = new List<GameObject>();
		foreach (GameObject s in m_board.m_cubes) 
		{
			squares.Add(s);
		}
		squares.RemoveAll(x => x.GetComponent<SquareBehaviour>().m_isOccuped);
		int index = (int)Mathf.Floor( Random.Range(0,squares.Count));

		//Release Drag
		int cardIndex = (int) Mathf.Floor( Random.Range(0,gameObject.transform.childCount));

		GameObject card = gameObject.transform.GetChild(cardIndex).gameObject;

		scriptBoard.PutTokken(squares[index],card);
	}

	#endregion
	
	#region Private Variable

	private BoardBehaviour m_board;

	#endregion
}
