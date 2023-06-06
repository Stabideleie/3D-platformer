using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource audio;
    private PlayerMove movement;
    private PlayerInput input;

    [SerializeField] private AudioClip motorSounds;
    [SerializeField] private AudioClip jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        movement = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        MotorSounds();
    }

    private void MotorSounds()
    {
        audio.pitch = movement.moveSpeed / 20;
    }
}
