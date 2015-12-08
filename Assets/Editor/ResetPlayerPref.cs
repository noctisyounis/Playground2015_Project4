using UnityEngine;
using System.Collections;
using UnityEditor;



[InitializeOnLoad]
public class ResetPlayerPref 
{
	static ResetPlayerPref ()
	{
		PlayerPrefs.DeleteAll();
	}

}

