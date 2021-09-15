using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	enum actions{ Stone = 1, Paper, Scissor }

	private int playerChoose = -1;
	private int botChoose = -1;
	
	private bool playersTurn = true;
	
	public GameObject ResultText;
	
	public Sprite paperIMG, rockIMG, scissorIMG;
	
	
	public GameObject botChooseIMG;
	public GameObject playerChooseIMG;
	
	
	public static int playerWins = 0;
	public static int botWins = 0;
	
	private bool isPlayerWin, isBotWin = false;
	
	
	public AudioSource smashHit;

	

    // Update is called once per frame
    void Update()
    {
		
        if(playersTurn && playerChoose == -1)                          //---If it is players turn but he not choose anything--//
			return;
		else
		{
			BotChoose();
			CheckWinner();
			playerChoose = -1;
			playersTurn = true;
		}
		
		if(isPlayerWin)                                              //---If player wins increase the wins text  of player--// 
		{
			playerWins++;
		}
		if(isBotWin)                                                  //---If Bot wins increase the wins text  of Bot--//   
		{
			botWins++;
		}
	
		
    }
	
     public void PlayerChoose(int choose)                            //---Player responses through choose buttons--// 
	{
		playerChooseIMG.GetComponent<Image>().color = new Color32(255,255,255,255);  //--change the image background to white--//
		 
		smashHit.Play();                                                            //--Play button click sound--//
		
		playerChooseIMG.GetComponent<Animation>().Play();                           //---Play animations of images--//
		botChooseIMG.GetComponent<Animation>().Play();
		
		playerChoose = choose;
		playersTurn = false;                                                      
		
		if(playerChoose == 1)                                                     //-- 1 for Rock--//
		{
			playerChooseIMG.GetComponent<Image>().sprite = rockIMG;
		}
		else if(playerChoose == 2)                                                //--2 for Paper--//
		{
			playerChooseIMG.GetComponent<Image>().sprite = paperIMG;
		}
		else                                                                      //--3 for scissor--//
		{
			playerChooseIMG.GetComponent<Image>().sprite = scissorIMG;           
		}
	}
	public void BotChoose()
	{
		botChooseIMG.GetComponent<Image>().color = new Color32(255,255,255,255); //--change the image background to white--//
		
		 botChoose = Random.Range(1, 4);                                         //-- Bot choose Randomly from 1 to 3--//
		
		if(botChoose == 1)
		{
			botChooseIMG.GetComponent<Image>().sprite = rockIMG;
		}
		else if(botChoose == 2)
		{
			botChooseIMG.GetComponent<Image>().sprite = paperIMG;
		}
		else
		{
			botChooseIMG.GetComponent<Image>().sprite = scissorIMG;
		}
		
	}
	
	public void CheckWinner()                                                           //---Game Logic--//
	{
		

		if(playerChoose == botChoose)                                         //---Same Response Draw--//                
		{
			//Draw
			ResultText.GetComponent<Text>().text = "Draw";
		}
		else if(playerChoose == (int)actions.Paper && botChoose == (int)actions.Stone)     //---Paper Vs Stone--//
		{
			//Player wins
			ResultText.GetComponent<Text>().text = "Player Win";
			isPlayerWin = true;
			isBotWin = false;
		}
		else if(playerChoose == (int)actions.Stone && botChoose == (int)actions.Paper)      //---Stone Vs Paper--//
		{
			//Bot wins
			ResultText.GetComponent<Text>().text = "Bot Win";
			isBotWin = true;
			isPlayerWin = false;
		}
		else if(playerChoose == (int)actions.Scissor && botChoose == (int)actions.Stone)     //---Scissor Vs Stone--//
		{
			//Bot wins
			ResultText.GetComponent<Text>().text = "Bot Win";
		    isBotWin = true;
			isPlayerWin = false;
		}
		else if(playerChoose == (int)actions.Stone && botChoose == (int)actions.Scissor)     //---Stone  Vs Scissor--//  
		{
			//Player wins
			ResultText.GetComponent<Text>().text = "Player Win";
			isPlayerWin = true;
			isBotWin = false;
		}
		
		else if(playerChoose == (int)actions.Paper && botChoose == (int)actions.Scissor)     //---Paper  Vs Scissor--//   
		{
			ResultText.GetComponent<Text>().text = "Bot Win";
			isPlayerWin = false;
			isBotWin = true;
		}
		
		else if(playerChoose == (int)actions.Scissor && botChoose == (int)actions.Paper)      //---Scissor Vs Paper--//  
		{
			ResultText.GetComponent<Text>().text = "Player Win";
			isPlayerWin = true;
			isBotWin = false;
		}
		
		  
	}
		
	
}
