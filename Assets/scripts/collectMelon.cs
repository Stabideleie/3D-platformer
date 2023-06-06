using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectMelon : MonoBehaviour
{
    public AudioSource collectAudio;
    public AudioClip collectSound;
    private bool hasBeenCollected = false;


    void OnTriggerEnter(Collider other)
    {
        if (hasBeenCollected == false)
        {
            Debug.Log("collect fruit");
            hasBeenCollected = true;
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 1f);
            collectAudio.PlayOneShot(collectSound);
            ScoringSystem.instance.addMelonScore(1);
            Destroy(gameObject);
            //GetComponent<Renderer>().enabled = false;

        }
    }
}
