using UnityEngine;
using System.Collections;
using UnityEditor;

[InitializeOnLoad]
public class ResetPlayerPref : MonoBehaviour 
{
	static ResetPlayerPref ()
	{
		PlayerPrefs.SetString("IsNotFirstStart","False");
	}
		

}

