using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class playerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("death"))
        {
            transform.position = respawnPoint.position;
        }
    }
    

}
