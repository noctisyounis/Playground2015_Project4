using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class deck
{
	[XmlArray("deck"),XmlArrayItem("card")]
	public card[] m_cards;
	
	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(deck));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	
	public static deck Load(string path)
	{
		var serializer = new XmlSerializer(typeof(deck));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as deck;
		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static deck LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(deck));
		return serializer.Deserialize(new StringReader(text)) as deck;
	}
}
