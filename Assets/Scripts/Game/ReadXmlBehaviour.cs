using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.UI;

public class ReadXmlBehaviour
{
    #region variable
    private ArrayList _list = new ArrayList();

    public ArrayList List
    {
        get { return _list; }
        set { _list = value; }
    }

	private ArrayList _listLand = new ArrayList ();

	public ArrayList ListLand 
	{
		get { return _listLand;  }
		set { _listLand = value; }
	}

    #endregion
    #region method

    public ReadXmlBehaviour()
    {
<<<<<<< HEAD
        Initialize("Card");       
    }

	public ReadXmlBehaviour( string prefabName)
	{
		Initialize(prefabName);	
	}
=======

        Initialize("Card");



    }
    public ReadXmlBehaviour(string prefabName)
    {
        Initialize(prefabName);


    }
>>>>>>> origin/master


    void Initialize(string prefabName)
    {
        System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader("Assets\\Extrernal\\Xml\\gameCard.xml");

        bool card = false;
<<<<<<< HEAD
		bool zoneLand = false;
        
=======
>>>>>>> origin/master

        while (reader.Read())
        {
            #region card unit
            if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.Name == "unit")
            {
                //Debug.Log("new");
                GameObject prefab = (GameObject)Resources.Load(prefabName, typeof(GameObject));
                CardUnitBehaviour script = prefab.GetComponent<CardUnitBehaviour>();
                card = true;
                while (card && reader.Read())
                {


                    if (reader.NodeType == System.Xml.XmlNodeType.EndElement)
                    {
                        if (reader.Name == "card")
                        {
                            card = false;
                            List.Add(GameObject.Instantiate(prefab));
                            //Debug.Log("save");
                            //Debug.Log(List.Count);
                        }
                    }

                    if (reader.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {

                            case "name": reader.Read();
                                script.m_name.GetComponent<Text>().text = reader.Value;
                                break;
                            case "l1": reader.Read();
                                script.m_Description1.GetComponent<Text>().text = reader.Value;
                                break;
                            case "l2": reader.Read();
                                script.m_Description2.GetComponent<Text>().text = reader.Value;
                                break;
                            case "l3": reader.Read();
                                script.m_Description3.GetComponent<Text>().text = reader.Value;
                                break;
                            case "type": reader.Read();

                                switch (reader.Value)
                                {
                                    case "BigRange":
<<<<<<< HEAD
                                        prefab.GetComponent<Image>().sprite = script.m_bigRange;
                                        break;
                                    case "Range":
                                        prefab.GetComponent<Image>().sprite = script.m_range;
                                        break;
                                    case "Close":
=======
                                        Debug.Log("big");

                                        prefab.GetComponent<Image>().sprite = script.m_bigRange;
                                        break;
                                    case "Range":
                                        Debug.Log("range");

                                        prefab.GetComponent<Image>().sprite = script.m_range;
                                        break;
                                    case "Close":
                                        Debug.Log("cac");

>>>>>>> origin/master
                                        prefab.GetComponent<Image>().sprite = script.m_cac;
                                        break;
                                }
                                script.m_type = reader.Value;
                                break;
                            case "init": reader.Read();
                                script.m_Speed.GetComponent<Text>().text = reader.Value;
                                break;
                            case "life": reader.Read();
                                script.m_HP.GetComponent<Text>().text = reader.Value;
                                break;
                            case "price": reader.Read();
                                script.m_price = int.Parse(reader.Value);
                                int cost = int.Parse(reader.Value);
                                int Rubis = 1;
                                while (cost > 0)
                                {
                                    Image image = script.m_Rubis1.GetComponent<Image>();
                                    switch (Rubis)
                                    {
                                        case 1: image = script.m_Rubis1.GetComponent<Image>();
                                            break;
                                        case 2: image = script.m_Rubis2.GetComponent<Image>();
                                            break;
                                        case 3: image = script.m_Rubis3.GetComponent<Image>();
                                            break;
                                        case 4: image = script.m_Rubis4.GetComponent<Image>();
                                            break;
                                        case 5: image = script.m_Rubis5.GetComponent<Image>();
                                            break;
                                    }
                                    if (cost >= 10)
                                    {
                                        image.color = Color.red;
                                        cost = cost - 10;
                                        Rubis++;
                                    }
                                    else if (cost >= 5)
                                    {
                                        image.color = Color.blue;
                                        cost = cost - 5;
                                        Rubis++;
                                    }
                                    else if (cost < 5)
                                    {
                                        image.color = Color.green;
                                        cost = cost - 1;
                                        Rubis++;
                                    }

                                }
                                break;
                            case "top": reader.Read();
                                script.m_ATK_Up.GetComponent<Text>().text = reader.Value;
                                break;
                            case "bottom": reader.Read();
                                script.m_ATK_Down.GetComponent<Text>().text = reader.Value;
                                break;
                            case "left": reader.Read();
                                script.m_ATK_Left.GetComponent<Text>().text = reader.Value;
                                break;
                            case "right": reader.Read();
                                script.m_ATK_Right.GetComponent<Text>().text = reader.Value;
                                break;

                        }
                    }
                }
            }
            #endregion

			#region card land

			if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.Name == "land")
			{
				GameObject prefabLand = (GameObject)Resources.Load("CardGUILand", typeof(GameObject));
				CardGroundBehaviour scriptLand = prefabLand.GetComponent<CardGroundBehaviour>();
				card = true;
				while (card && reader.Read())
				{
					if (reader.NodeType == System.Xml.XmlNodeType.EndElement)
					{
						if (reader.Name == "card")
						{
							card = false;
							ListLand.Add(GameObject.Instantiate(prefabLand));
							//Debug.Log("save");
							//Debug.Log(List.Count);
						}
					}

					if (reader.NodeType == System.Xml.XmlNodeType.Element)
					{
						switch (reader.Name)
						{
						case "type" : reader.Read ();
							scriptLand.m_type = reader.Value;
							break;
						case "name" : reader.Read ();
							scriptLand.m_name.GetComponent<Text>().text = reader.Value;
							break;
						case "description" : reader.Read ();
							scriptLand.m_Description1.GetComponent<Text>().text = reader.Value;
							break;
						case "zones" : reader.Read ();

							zoneLand = true;
							while (zoneLand && reader.Read())
							{
								if (reader.NodeType == System.Xml.XmlNodeType.EndElement)
								{
									if (reader.Name == "zones")
									{
										zoneLand = false;
									}
								}
								else if(reader.NodeType == System.Xml.XmlNodeType.Element)
								{
									switch(reader.Name)
									{
									case "y" : 
										reader.Read ();
										scriptLand.yValue.Add (reader.Value);
										break;
									case "x" :
										reader.Read ();
										scriptLand.xValue.Add(reader.Value);
										break;
									}
								}
							}
							break;
						}
					}
				}
			}
			#endregion
        
		}
    #endregion
	}
}