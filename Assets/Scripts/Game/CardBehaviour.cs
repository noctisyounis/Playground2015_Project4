using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardBehaviour : DraggableBehaviour {

	#region Public Variable

	public GameObject m_name;

    public GameObject m_Description1;

    public GameObject m_Description2;

    public GameObject m_Description3;
	
	#endregion
	
	#region Main Methodes

  
	
	
	#endregion
	
	#region Utils
	public virtual void PlayCard()
	{
		
		GameObject.Destroy(gameObject);
	}
	#endregion
	
	#region Private Variable
    private string Name;

    public string PropName
    {
        get { return Name; }
        set { Name = value; }
    }

    private string Type;

    public string PropType
    {
        get { return Type; }
        set { Type = value; }
    }
    

    private string DescriptionL1;

    public string PropL1
    {
        get { return DescriptionL1; }
        set { DescriptionL1 = value; }
    }

    private string DescriptionL2;

    public string PropL2
    {
        get { return DescriptionL2; }
        set { DescriptionL2 = value; }
    }

    private string DescriptionL3;
    
    public string PropL3
    {
        get { return DescriptionL3; }
        set { DescriptionL3 = value; }
    }
    private string Pictures;
	#endregion
}
