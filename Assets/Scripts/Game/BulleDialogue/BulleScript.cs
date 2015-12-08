using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class BulleScript {

	//Bulle Aide

	 List<string> ListDialogue;

	public BulleScript()
	{
		ListDialogue = new List<string>();
		ListDialogue.Add("Bienvenue"); //0
		ListDialogue.Add ("trop lent !"); //1 TimerIsOver
		ListDialogue.Add ("changement de terrain!"); //2
		ListDialogue.Add ("il ressemble à un buisson???"); //3 error range
		ListDialogue.Add ("Ce ramassi de bout de bois n'est pas une foret!"); //4 error bigRange
		ListDialogue.Add ("il est aussi bete qu'un roche, mais ce n'en est pas un..."); //5 error cac
		ListDialogue.Add ("bien joué!"); //6 win
		ListDialogue.Add ("il faut revoir ta stratégie"); //7 loose
	}

	public string WelcomeMessage()
	{
		return ListDialogue[0];
	}

	public string TimerIsOver()
	{
		return ListDialogue[1];
	}

	public string TurnLands()
	{
		return ListDialogue[2];
	}

	public string ErrorUnit(string type)
	{
		if (type == "Unit")
		{
			return ListDialogue[3];
		}
	
		else
		{
			return ListDialogue[4];
		}
	}
	public string EndGame(bool isWin)
	{

		if(isWin == true)
		{
			return ListDialogue[6];
		}
		else
			return ListDialogue[7];
	}
	public string Story()
	{
		return "";
	}
}
