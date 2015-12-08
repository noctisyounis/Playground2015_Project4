using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[InitializeOnLoad]
public class ResetPlayerPref : MonoBehaviour 
{
	static ResetPlayerPref ()
	{
		PlayerPrefs.SetString("IsNotFirstStart","False");
	}
		

}

