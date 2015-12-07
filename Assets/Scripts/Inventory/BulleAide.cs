using UnityEngine;
using System.Collections;

public class BulleAide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("DestroyObject",7f);
	}
	void DestroyObject()
	{
		Destroy(gameObject);
	}
}
