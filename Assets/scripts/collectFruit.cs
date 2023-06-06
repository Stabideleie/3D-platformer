using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectfruit : MonoBehaviour
{
    public AudioSource collectSound;


    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        ScoringSystem.instance.theScore += 50;
        Destroy(gameObject);
    }
}
