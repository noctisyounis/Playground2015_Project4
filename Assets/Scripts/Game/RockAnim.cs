using UnityEngine;
using System.Collections;

public class RockAnim : MonoBehaviour {

	public AudioClip m_hit;
	public AudioClip m_shot;
	public AudioSource m_audio;

	public void MoveRight(float f)
	{
		Vector3 NewPosition = gameObject.transform.parent.transform.position ;
		NewPosition.x -= f;
		gameObject.transform.parent.transform.position = NewPosition;
	}


	public void MoveLeft(float f)
	{
		Vector3 NewPosition = gameObject.transform.parent.transform.position ;
		NewPosition.x += f;
		gameObject.transform.parent.transform.position = NewPosition;
	}


	public void MoveUp(float f)
	{
		Vector3 NewPosition = gameObject.transform.parent.transform.position ;
		NewPosition.z -= f;
		gameObject.transform.parent.transform.position = NewPosition;
	}


	public void MoveDown(float f)
	{
		Vector3 NewPosition = gameObject.transform.parent.transform.position ;
		NewPosition.z += f;
		gameObject.transform.parent.transform.position = NewPosition;
	}
	
	public void Hide()
	{
		transform.localScale = new Vector3(0,0,0);
	}
	 public void Show()
	{
		transform.localScale = new Vector3(0.2f,0.2f,0.2f);
	}

	void RockHit()
	{
		m_audio.PlayOneShot (m_hit);
	}
	
	void RockShot()
	{
		m_audio.PlayOneShot (m_shot);
		
	}
}
