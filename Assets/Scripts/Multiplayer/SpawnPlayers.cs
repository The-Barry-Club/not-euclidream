using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Random = System.Random;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public int minX;
    public int maxX;
    public int minZ;
    public int maxZ;

    private void Start()
    {
        int x = new Random().Next(minX, maxX);
        int z = new Random().Next(minZ, maxZ);
        Vector3 randomPos = new Vector3(x,1,z);
        PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
    }
}
