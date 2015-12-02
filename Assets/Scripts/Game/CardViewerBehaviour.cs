using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardViewerBehaviour : MonoBehaviour {

	public Sprite BaseTexture;
	public Sprite EnnemyTexture;
	public Sprite AllyTexture;


	public void setBaseTexture()
	{
		GetComponent<Image> ().overrideSprite = BaseTexture;
	}

	public void setEnnemyTexture()
	{
		GetComponent<Image> ().overrideSprite = EnnemyTexture;
	}

	public void setAllyTexture()
	{
		GetComponent<Image> ().overrideSprite = AllyTexture;
	}
}
