using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;

public class SaveBehaviour : MonoBehaviour 
{
	deck m_deck = new deck();

	public GameObject m_textError;
	public Text m_stringError;
	
	public Color BaseColor;
	public Color ErrorColor;

	public void Start()
	{
		ErrorColor = new Color(0.6f,0.1f,0.1f);
		BaseColor = new Color(0.8f,0.4f,0.1f);	
		m_textError = GameObject.Find("TextError");
		m_stringError = m_textError.GetComponent<Text>();
	}

	public void OnMouseUp()
	{
		// if deck is full (23) : 18 units/5 lands
		if (DeckBehaviour.m_deck.Count == 23) {
			m_stringError.color = BaseColor;
			m_stringError.text = "votre nouveau deck à bien été sauvegardé";
			m_deck.SaveXml();
		}
		else
		{
			m_stringError.color = ErrorColor;
			m_stringError.text = "il vous manque des cartes dans votre deck";
			Debug.Log("--- Ur deck is no complete !!!");
		}
	}
}
