using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class BulleScript {

	//Bulle Aide

	 List<string> ListDialogue;

	public BulleScript()
	{
		ListDialogue = new List<string>();
		ListDialogue.Add("Bienvenue, jeune sanglier!"); //0
		ListDialogue.Add ("trop lent !"); //1 TimerIsOver
		ListDialogue.Add ("Tour de terrain !"); //2
		ListDialogue.Add ("ça ressemble à un buisson?"); //3 error Unit
		ListDialogue.Add ("Tour d'unité ! Epis mal coupé!"); //4 error terrain
		ListDialogue.Add ("Tour d'unité !"); //5 error cac
		ListDialogue.Add ("Bien joué!"); //6 win
		ListDialogue.Add ("il faut revoir ta stratégie"); //7 loose
		ListDialogue.Add ("21 porcelets, tu dis mieux ?");		
		ListDialogue.Add ("Miaou ! Le cri de mes victimes.");	
		ListDialogue.Add ("Tu veux voir le cycliste que j'ai défoncé ?");
		ListDialogue.Add ("Un peu de respect pour le roi, Moi.");
		ListDialogue.Add ("dsfkdfsglj%qhf%q£sf");
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

	public string TurnUnits()
	{
		return ListDialogue[5];
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
		int i = Random.Range(8,12);
		return ListDialogue[i];
	}
}
