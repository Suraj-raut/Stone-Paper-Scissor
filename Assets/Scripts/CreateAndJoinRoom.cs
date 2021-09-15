using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
   public InputField createInput;
   public InputField joinInput;
	
	public void CreateRoom()                                     //-----Create room and join that same room----//
	{
		if(createInput.text != null)
		{
			PhotonNetwork.CreateRoom(createInput.text);	
		}
		else
		{
			Debug.Log("Please enter the room name");
			return;
		}
			
	}
	
	public void JoinRoom()                                   //---Join a specific room--//
	{
		if(joinInput.text != null)
		{
			PhotonNetwork.JoinRoom(joinInput.text);
			
		}
		else
		{
			Debug.Log("Please enter the room name");
			return;	
		}		
	
	}
	
	public override void OnJoinedRoom()                   //---After Creating/joining room start the game--//
	{
		PhotonNetwork.LoadLevel("Online");
	}
	
	
}
