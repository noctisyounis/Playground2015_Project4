using UnityEngine;
using System.Collections;

public class CardBehaviour : DraggableBehaviour {

	#region Public Variable

	public string m_name;

	public string m_type;

	public string m_description;

	public string m_pictures;
	
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

	#endregion
}
