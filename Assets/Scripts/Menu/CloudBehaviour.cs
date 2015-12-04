using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloudBehaviour : MonoBehaviour {


	public float x = 0.0f;
	public float scrollSpeed = 0.005f;
	public Renderer rend;
	public Image img;
	public Material mat;


	void FixedUpdate()
	{
		//float offset = (Time.time * scrollSpeed);
		x += 0.001f;
		mat.mainTextureOffset = new Vector2 (x, 0);                            
	}
}
