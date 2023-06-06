using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] float degreesPerSecond = 360;
    [SerializeField] Vector3 axis;
    [SerializeField] Space relativeTo =  Space.World;

    private void Update()
    {
        transform.Rotate(axis, degreesPerSecond * Time.deltaTime, relativeTo);
    }
}
