using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public Transform spawnLocation;

    public void Start()
    {
        if (PlayerManager.LocalPlayerInstance == null)
        {
            //create local player
            PhotonNetwork.Instantiate(playerPrefab.name, spawnLocation.position, Quaternion.identity, 0);
        }
    }

    public override void OnLeftRoom()
    {
        //loads launcher when player leaves room
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom()
    {
        //disconnects player
        PhotonNetwork.LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Player {newPlayer.NickName} with id {newPlayer.UserId} joined.");

        //base.OnPlayerEnteredRoom(newPlayer);
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Master Client joined.");
        }
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"Player {otherPlayer.NickName} with id {otherPlayer.UserId} left.");
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Master Client left.");
        }
    }
}
