﻿using UnityEngine;
using System.Collections;

public static class AnimationManager
{

	#region Public Variable

	#endregion
	
	#region Main Methodes

	public static GameObject SwordAttack(int x, int y )
	{
		float FloatX = (float)(5-x);
		float FloatY = (float)(y); 

		//Correction Position 3D
		if (x > 3) 
		{
			FloatX += 0.05f * (x-3);
		}
		else if (x < 2) 
		{
			FloatX += 0.05f * (2-x);
		}


		Vector3 Position = new Vector3(FloatX,0f, FloatY);
		Quaternion Rotation = new Quaternion(315f,0f,0f,0f);
		GameObject prefab = (GameObject) Resources.Load("SwordAnim");
		GameObject holder = (GameObject) GameObject.Instantiate(prefab);
		holder.transform.position = Position;

		return holder.transform.GetChild(0).gameObject;

	}
	public static GameObject ArrowAttack(int x, int y )
	{
		float FloatX = (float)(5-x);
		float FloatY = (float)(y); 
				
		Vector3 Position = new Vector3(FloatX,0f, FloatY);
		GameObject prefab = (GameObject) Resources.Load("ArrowAnim");
		GameObject holder = (GameObject) GameObject.Instantiate(prefab);
		holder.transform.position = Position;
		
		return holder.transform.GetChild(0).gameObject;
		
	}
	public static GameObject RockAttack(int x, int y )
	{
		float FloatX = (float)(5-x);
		float FloatY = (float)(y); 
		
		Vector3 Position = new Vector3(FloatX,0f, FloatY);
		GameObject prefab = (GameObject) Resources.Load("RockAnim");
		GameObject holder = (GameObject) GameObject.Instantiate(prefab);
		holder.transform.position = Position;
		
		return holder.transform.GetChild(0).gameObject;
		
	}

	#endregion
	
	#region Utils

  


	#endregion
	
	#region Private Variable



	#endregion

}
