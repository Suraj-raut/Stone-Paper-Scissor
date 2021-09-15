using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public Text playerWinText;
	public Text botWinText;
	
	public GameObject WinnersPanel;
	public Text WinnersText;
	
	public GameObject PausePanel;
	
	private bool isPaused = false;
	
	
	void Update()
	{
	
		playerWinText.GetComponent<Text>().text = "Wins :" + GameManager.playerWins;      //---Show wins of player--//
		botWinText.GetComponent<Text>().text = "Wins :" + GameManager.botWins;            //---Show wins of Bot--//
		
	  if(GameManager.playerWins >= 10 || GameManager.botWins >= 10)  //----If player/Bot has win points over 10 show result panel//
		{
	
			WinnersPanel.SetActive(true);
			if(GameManager.playerWins >= 10)
			{
				WinnersText.GetComponent<Text>().text = "Congratulations you defeat the bot !";  //--If Player Wins--//
			}
			else                                                        
			{
				WinnersText.GetComponent<Text>().text = "Sorry you loose..";                    //---If Bot Wins--//
			}
			
		}
	}
  	public void PlayAgain()                                                                    //---Restart the game again--//
	{
		GameManager.playerWins = 0;
		GameManager.botWins = 0;
		WinnersPanel.SetActive(false);
		
		if(isPaused)                                                                         //---If restart from paused menu--//
		{	
			PausePanel.SetActive(false);
			isPaused = false;
		}
		
	}
	
	public void BackToMenu()                                                                 //---Back to Menu scene--//
	{
		WinnersPanel.SetActive(false);
		GameManager.playerWins = 0;
		GameManager.botWins = 0;
		SceneManager.LoadScene("Menu");
	}
	
	public void ResumeGame()                                                              //---Start the game from last session--//
	{
		PausePanel.SetActive(false);
	}
	
	public void PauseGame()                                                             //---Show the pause panel--//
	{
		isPaused = true;
		PausePanel.SetActive(true);
	}
	
}
