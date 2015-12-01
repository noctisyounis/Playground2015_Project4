using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class SaveBehaviour : MonoBehaviour 
{
	deck m_deck = new deck();
	public void OnMouseUp()
	{
		// if deck is full (23) : 18 units/5 lands
		if (DeckBehaviour.m_deck.Count == 23) {
			m_deck.SaveXml();
		}
		else
		{
			Debug.Log("--- Ur deck is no complete !!!");
		}
	}
}
