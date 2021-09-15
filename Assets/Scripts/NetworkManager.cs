using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
	private GameObject StartWindowPanel;	
	[SerializeField]
    private GameObject LoadingWindowPanel;
	private byte MaxPlayers = 2;
	
	public AudioSource buttonClick;
	
	
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();                          //----Connect to Photon server for playing online--//
    }

	public override void OnConnectedToMaster()
	{
		base.OnConnectedToMaster();
	
	}
	
/*	public void StartPlayInRandomRoom()                                //---Use to Play in Random Room--//
	{
		string roomName = "Room1";
		Photon.Realtime.RoomOptions opts = new Photon.Realtime.RoomOptions();
		opts.IsOpen = true;
		opts.IsVisible = true;
		opts.MaxPlayers = MaxPlayers;
		
		PhotonNetwork.JoinOrCreateRoom(roomName, opts, Photon.Realtime.TypedLobby.Default);	
		
	}*/
	
	public override void OnJoinedLobby()                            //---Join lobby scene to create room --//
	{
		SceneManager.LoadScene("Lobby");
	}
	
	public void GoToOnlineLobby()                                   //----Used to Play with friends by creating a room--//
	{
		buttonClick.Play();
		PhotonNetwork.JoinLobby();
		StartWindowPanel.SetActive(false);
		LoadingWindowPanel.SetActive(true);
	}

}
