using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.UI;

public class ReadXmlBehaviour 
{
    #region variable
    private ArrayList _list = new ArrayList();
    public Sprite Range;
    public Sprite Cac;
    public Sprite BigRange;
    public ArrayList List
    {
        get { return _list; }
        set { _list = value; }
    }
    #endregion
    #region method
    public ReadXmlBehaviour(Sprite range,Sprite bigRange,Sprite Cac)
    {
        this.Range = range;
        this.BigRange = bigRange;
        this.Cac = Cac;
        Start();
    }
    void Start()
    {


        System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader("Assets\\Extrernal\\Xml\\gameCard.xml");

        bool card = false;
        
        while (reader.Read())
        {
            #region card unit
            if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.Name == "unit")
            {
                //Debug.Log("new");
                GameObject prefab = (GameObject)Resources.Load("Card", typeof(GameObject));
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
                                        prefab.GetComponent<Image>().sprite = BigRange;
                                        break;
                                    case "Range": prefab.GetComponent<Image>().sprite = Range;
                                        break;
                                    case "Close": prefab.GetComponent<Image>().sprite = Cac;
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
        }
    }
    #endregion
}