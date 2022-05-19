using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;

    [SerializeField] private PlayerController playerController;

    private Room respawnRoom;
    private Room currRoom;
    private GameObject respawnPoint;

    private void Awake()
    {
        if (Manager == null)
        {
            Manager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetRespawn(GameObject respawn)
    {
        respawnPoint = respawn;
        respawnRoom = currRoom;
    }

    public void SetRoom(Room r)
    {
        currRoom = r;
    }

    public void Respawn()
    {
        currRoom.Camera.Priority--;
        respawnRoom.Camera.Priority++;
        
        playerController.transform.position = respawnPoint.transform.position;
    }
}
