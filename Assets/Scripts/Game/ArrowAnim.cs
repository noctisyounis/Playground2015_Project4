using UnityEngine;
using System.Collections;

public class ArrowAnim : MonoBehaviour {
		
	public AudioClip m_hit;
	public AudioClip m_shot;
	public AudioSource m_audio;

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

	void ArrowHit()
	{
		m_audio.PlayOneShot (m_hit);
	}

	void ArrowShot()
	{
		m_audio.PlayOneShot (m_shot);

	}

}
