using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SquareBehaviour : MonoBehaviour
{

	#region Public Variable

	public bool m_isPointed= false;
	public bool m_isOccuped = false;
	public GameObject m_tokken;
	private CardHolderBehaviour m_cardHolder;
	public int m_gridX;
	public int m_gridY;

	public Material TiledForest;
	public Material TiledMountain;
	public Material TiledPlaine;
	public Material TiledRuin;
	public Material TiledSwamp;

	public Material TiledForestOver;
	public Material TiledMountainOver;
	public Material TiledPlaineOver;
	public Material TiledRuinOver;
	public Material TiledSwampOver;



	#endregion

	#region Main Methodes
	public void Start()
	{
		m_cardHolder = (CardHolderBehaviour)GameObject.FindObjectOfType<CardHolderBehaviour> ();
	}

	public void OnMouseEnter() 
	{
		if (m_isOccuped) 
		{
			m_cardHolder.setNewCarUnitFromTokken (m_tokken.GetComponent<TokkenBehaviour> ());
		}
		m_isPointed = true;

		OverOn ();

	}
	
	public void OnMouseExit() 
	{
		if (m_isOccuped) 
		{
			m_cardHolder.GetComponent<CardHolderBehaviour> ().removeCard ();
		}

		m_isPointed = false;

		OverOff ();
	}

	public void OverOn()
	{
		if (GetComponent<Renderer> ().material.ToString().Contains("TiledForest") ) 
		{
			this.GetComponent<Renderer>().material = TiledForestOver;
		}
		
		if (GetComponent<Renderer> ().material.ToString().Contains("TiledMoun") ) 
		{
			this.GetComponent<Renderer>().material = TiledMountainOver;
		}
		
		if (GetComponent<Renderer> ().material.ToString().Contains("TiledPlain") ) 
		{
			this.GetComponent<Renderer>().material = TiledPlaineOver;
		}
		
		if (GetComponent<Renderer> ().material.ToString().Contains("TiledRuin") ) 
		{
			this.GetComponent<Renderer>().material = TiledRuinOver;
		}
		
		if (GetComponent<Renderer> ().material.ToString().Contains("TiledSwamp") ) 
		{
			this.GetComponent<Renderer>().material = TiledSwampOver;
		}
	}


	public void OverOff()
	{
		if (GetComponent<Renderer> ().material.ToString().Contains("TiledForest") ) 
		{
			this.GetComponent<Renderer>().material = TiledForest;
		}
		
		if (GetComponent<Renderer> ().material.ToString().Contains("TiledMoun") ) 
		{
			this.GetComponent<Renderer>().material = TiledMountain;
		}
		
		if (GetComponent<Renderer> ().material.ToString().Contains("TiledPlain") ) 
		{
			this.GetComponent<Renderer>().material = TiledPlaine;
		}
		
		if (GetComponent<Renderer> ().material.ToString().Contains("TiledRuin") ) 
		{
			this.GetComponent<Renderer>().material = TiledRuin;
		}
		
		if (GetComponent<Renderer> ().material.ToString().Contains("TiledSwamp") ) 
		{
			this.GetComponent<Renderer>().material = TiledSwamp;
		}
	}

	public void ChangeMaterial(string newType)
	{
		switch (newType) {
			case "Mountain":
				this.GetComponent<Renderer>().material = TiledMountain;
			break;
			case "Forest":
				this.GetComponent<Renderer>().material = TiledForest;
				break;
			case "Ruin":
				this.GetComponent<Renderer>().material = TiledRuin;
				break;
			case "Plain":
				this.GetComponent<Renderer>().material = TiledPlaine;
				break;
			case "Swamp":
			this.GetComponent<Renderer>().material = TiledSwamp;
			break;
		}
	}



	#endregion

	#region PUtils
	#endregion

	#region Private Variable
	#endregion
}
