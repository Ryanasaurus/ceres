using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 5;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed, 0.0f);

        transform.position = transform.position + movement * Time.deltaTime;
    }
}
