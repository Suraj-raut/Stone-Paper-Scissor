using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class playerSpawner : MonoBehaviourPun
{
	public GameObject playerPrefab;
	public RectTransform[] spawnPoints;
	public Camera cam;
	public RectTransform m_parent;
	
	
	
    // Start is called before the first frame update
    void Awake()
    {
     
		int i = PhotonNetwork.CurrentRoom.PlayerCount - 1;    //---check the player joined if yes positioned it in 1st spawnpoint--//
		
		Vector2 anchorPos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(m_parent, spawnPoints[i].position, cam, out anchorPos);
		

		PhotonNetwork.Instantiate(playerPrefab.name, anchorPos, Quaternion.identity);   
		
    }

  
}
