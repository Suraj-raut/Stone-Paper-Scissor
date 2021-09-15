using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayOffline : MonoBehaviour
{
	public AudioSource buttonClick;
	
    public void GoToOfflineMode()                 //---Go the online mode i.e play with BOT--///
	{
		buttonClick.Play();
		SceneManager.LoadScene("Game");
	}
	
	public void QuitTheGame()
	{
		buttonClick.Play();
		Application.Quit();
	}
}
