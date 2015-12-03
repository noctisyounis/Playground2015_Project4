using UnityEngine;
using System.Collections;

public class SwordAnim : MonoBehaviour 
{

	void Hide()
	{
		transform.localScale = new Vector3(0,0,0);
	}
	void Show()
	{
		transform.localScale = new Vector3(0.2f,0.2f,0.2f);
	}
}
