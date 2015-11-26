using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
	#region Public Variabl
	public Transform m_parentToReturnTo = null;
	public Transform m_placeholderParent = null;
	public bool m_isHovered = false;

	#endregion
	
	#region Main Methodes

	public void Start()
	{
		gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
		GameObject board = GameObject.FindObjectOfType<BoardBehaviour>().gameObject;
		m_board = board;
		m_hand = GameObject.FindObjectOfType<HandBehaviour>().gameObject;

	}

	public void OnBeginDrag(PointerEventData eventData) 
	{
		//Debug.Log ("OnBeginDrag");

		if (Dummy != null) 
		{
			GameObject.Destroy(Dummy);
		}

		CreatePlaceHolder ();
		
		

	}
	
	public void OnDrag(PointerEventData eventData) 
	{
		//Debug.Log ("OnDrag");
		
		this.transform.position = eventData.position;
		
		if (m_placeholder.transform.parent != m_placeholderParent) 
		{
			m_placeholder.transform.SetParent (m_placeholderParent);
		}
		
		int newSiblingIndex = m_placeholderParent.childCount;
		
		for(int i=0; i < m_placeholderParent.childCount; i++) 
		{
			if(this.transform.position.x < m_placeholderParent.GetChild(i).position.x) 
			{		
				newSiblingIndex = i;
				
				if(m_placeholder.transform.GetSiblingIndex() < newSiblingIndex)
				{
					newSiblingIndex--;
				}
				break;
			}
		}
		m_placeholder.transform.SetSiblingIndex(newSiblingIndex);		
	}
	
	public void OnEndDrag(PointerEventData eventData) 
	{
		//Debug.Log ("OnEndDrag");

		BoardBehaviour scriptBoard = (BoardBehaviour)m_board.GetComponent<BoardBehaviour>();
		if (scriptBoard.m_player_Turn) 
		{
			GameObject cube = scriptBoard.CheckCubePointing (eventData.pointerDrag);
			if (cube != null) 
			{
				if (!cube.GetComponent<SquareBehaviour>().m_isOccuped) {
					scriptBoard.PutTokken(cube,gameObject);
				}
			}
		}
		m_oldPosition = m_placeholder.transform.position;
		transform.SetParent( m_parentToReturnTo );
		transform.SetSiblingIndex( m_placeholder.transform.GetSiblingIndex() );
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		transform.localScale = new Vector3(1f,1f,1f);

		Destroy(m_placeholder);
	}

	public void OnPointerEnter(PointerEventData eventData) 
	{
		if (!m_isHovered) 
		{
			if (!eventData.dragging) 
			{
				// reset other card
				foreach (var item in m_hand.transform.GetComponentsInChildren<DraggableBehaviour>()) 
				{
					if (item.m_isHovered) 
					{
						item.ResetPostition();
					}
				}

				m_isHovered = true;

				m_oldPosition = this.transform.position;
				Vector3 NewPosition = m_oldPosition;
				NewPosition.y += (Screen.height * 0.20f);
				transform.position = NewPosition;
				transform.localScale = new Vector3 (1.6f, 1.6f, 1.6f);
				DummyHoveredCard();

			}
		}
	}
	
	public void OnPointerExit(PointerEventData eventData) 
	{
		if (!eventData.dragging) 
		{
			Debug.Log(eventData.position.ToString());
			if (eventData.position.y >= 10 ) 
			{
				ResetPostition();
			}
		}
	}



	#endregion

	#region Utils

	public void ResetPostition()
	{
		transform.SetParent(m_hand.transform);
		transform.position = m_oldPosition;
		transform.localScale = new Vector3(1f,1f,1f);
		m_isHovered = false;

		if (Dummy != null) 
		{
			GameObject.Destroy (Dummy);
		}
	}

	void CreatePlaceHolder ()
	{
		m_placeholder = new GameObject ();
		m_placeholder.name = "PlaceHolder";
		m_placeholder.transform.SetParent (this.transform.parent);
		LayoutElement le = m_placeholder.AddComponent<LayoutElement> ();
		le.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;
		m_placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());
		m_parentToReturnTo = this.transform.parent;
		m_placeholderParent = m_parentToReturnTo;
		this.transform.SetParent (this.transform.parent.parent);
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	void DummyHoveredCard()
	{
		Dummy = GameObject.Instantiate(gameObject);
		Dummy.GetComponent<CanvasGroup>().blocksRaycasts = false;
		Dummy.GetComponent<RectTransform>().sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
		Dummy.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position;

		Dummy.transform.SetParent(m_hand.transform.parent);

		Invoke("ResizeDummy",0.03f);

		//TODO eb find better method

	}

	public void ResizeDummy()
	{
		if (Dummy != null) {
			Dummy.transform.localScale = new Vector3 (1.6f, 1.6f, 1.6f);
		}
	}

	#endregion
	
	#region Private Variable
	GameObject m_placeholder = null;
	Vector3 m_oldPosition ;
	GameObject m_hand;
	GameObject m_board;
	GameObject Dummy;
	#endregion



}
