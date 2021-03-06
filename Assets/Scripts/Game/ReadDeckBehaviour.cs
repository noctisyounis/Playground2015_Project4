﻿using UnityEngine;
using System.Collections;
using System.Xml;

public class ReadDeckBehaviour  
{
	#region Public Variable
    private ArrayList m_deckList = new ArrayList();

    public ArrayList PropDeck
    {
        get { return m_deckList; }
        set { m_deckList = value; }
    }
    


	#endregion

	#region Main Methodes

    public ReadDeckBehaviour()
    {
		Start("playerCard.xml");
    }
	public ReadDeckBehaviour(string deckName)
	{
		Start(deckName);
	}

	void Start (string deckName) {
		System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(Application.dataPath+"\\StreamingAssets\\Xml\\"+deckName);

        while (reader.Read())
        {
            if (reader.NodeType == System.Xml.XmlNodeType.Element)
            {
                if (reader.Name == "id")
                {
                    reader.Read();
                   //Debug.Log(reader.Value);
                   m_deckList.Add(reader.Value);

                }
            }          
        }
	}



	#endregion

	#region Utils
	#endregion

	#region Private Variable
	#endregion
}
