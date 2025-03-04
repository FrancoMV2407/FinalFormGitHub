using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xAxis;
    private float zAxis;
    public float horizontalSpeed;
    public float verticalSpeed;

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        this.transform.Rotate(xAxis * Vector3.up * horizontalSpeed * Time.deltaTime, Space.World);

        zAxis = Input.GetAxisRaw("Vertical");
        this.transform.Translate(zAxis * Vector3.forward * verticalSpeed * Time.deltaTime);
    }
}
