using UnityEngine;
using System.Collections;

public class ArrowAnim : MonoBehaviour {
		

	void MoveRight()
	{
		Vector3 NewPosition = gameObject.transform.parent.transform.position ;
		NewPosition.x -= 1.0f;
		gameObject.transform.parent.transform.position = NewPosition;
	}

	void MoveLeft()
	{
		Vector3 NewPosition = gameObject.transform.parent.transform.position ;
		NewPosition.x += 1.0f;
		gameObject.transform.parent.transform.position = NewPosition;
	}

	void MoveUp()
	{
		Vector3 NewPosition = gameObject.transform.parent.transform.position ;
		NewPosition.z -= 1.0f;
		gameObject.transform.parent.transform.position = NewPosition;
	}

	void MoveDown()
	{
		Vector3 NewPosition = gameObject.transform.parent.transform.position ;
		NewPosition.z += 1.0f;
		gameObject.transform.parent.transform.position = NewPosition;
	}
	
	void Hide()
	{
		transform.localScale = new Vector3(0,0,0);
	}
	void Show()
	{
		transform.localScale = new Vector3(0.2f,0.2f,0.2f);
	}
}
