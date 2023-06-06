using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions inputActions;

    public Vector2 SteerVector;
    public bool JumpValue;
    public bool GassValue;
    public bool BrakeValue;


    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    // Update is called once per frame
    void Update()
    {

        GassValue = inputActions.player.gass.IsPressed();
        BrakeValue = inputActions.player.brake.IsPressed();
        SteerVector = new Vector2(inputActions.player.steering.ReadValue<Vector2>().x, 0f);

        JumpValue = inputActions.player.jump.triggered;
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

}
