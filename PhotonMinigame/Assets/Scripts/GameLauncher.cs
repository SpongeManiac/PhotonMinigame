using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameLauncher : MonoBehaviourPunCallbacks
{
    
    //client version
    string gameVersion = "0.1";

    public GameObject connectControls;
    public GameObject joinControls;

    private void Awake()
    {
        //automatically syncs peers to master when level changes
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (ConnectCloud())
        {
            //enable join controls and disable connect controls
            joinControls.SetActive(true);
            connectControls.SetActive(false);
        }
    }

    public void OnConnectClick()
    {
        if (ConnectCloud())
        {
            joinControls.SetActive(true);
            connectControls.SetActive(false);
        }
    }

    public void OnJoinClick(string room)
    {
        //join a specific room
        if (Join(room))
        {
            //disable join controls
            joinControls.SetActive(false);
        }
    }


    public bool ConnectCloud()
    {
        //check if connected to the cloud. If connected, join specific loby.
        //If not, connect to cloud.
        if (PhotonNetwork.IsConnected)
        {
            return true;
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
            if (PhotonNetwork.IsConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool Join(string room)
    {
        if(ConnectCloud()){
            PhotonNetwork.JoinRoom(room);
            return true;
        }
        else
        {
            return false;
        }
    }

}
