using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class deck
{
	public List<GameObject> m_cards;

	public deck ()
	{
		m_cards = DeckBehaviour.m_deck;
	}
	
	public void SaveXml()
	{
		string filepath = Application.dataPath + "\\\\Extrernal\\Xml\\playerCard.xml";
		XmlDocument xmlDoc = new XmlDocument();
		if(File.Exists (filepath))
		{
			xmlDoc.Load(filepath);

			XmlElement elm_Deck = xmlDoc.DocumentElement;
			elm_Deck.RemoveAll();

			for (int i = 0; i < m_cards.Count; i++) {

				XmlElement element_card = xmlDoc.CreateElement("card");
				XmlElement card_id = xmlDoc.CreateElement("id");
				XmlElement card_type = xmlDoc.CreateElement("type");

				if (m_cards[i].GetComponent<CardUnitBehaviour>()) {
					card_id.InnerText = (m_cards[i].GetComponent<CardUnitBehaviour>().m_id).ToString();
					card_type.InnerText = m_cards[i].GetComponent<CardUnitBehaviour>().m_type;
				}
				else if (m_cards[i].GetComponent<CardGroundBehaviour>())
				{
					card_id.InnerText = (m_cards[i].GetComponent<CardGroundBehaviour>().m_id).ToString();
					card_type.InnerText = m_cards[i].GetComponent<CardGroundBehaviour>().m_type;
				}
				element_card.AppendChild(card_id);
				element_card.AppendChild(card_type);
				elm_Deck.AppendChild(element_card);
			}
			xmlDoc.Save(filepath);
		}
	}
}
