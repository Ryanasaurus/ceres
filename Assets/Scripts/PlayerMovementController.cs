using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 5;
    private Vector3 targetPosition;
    private Vector2 rotateVector;
    void Start()
    {

    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed, 0.0f);

        transform.position = transform.position + movement * Time.deltaTime;

        //rotate player to cursor
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotateVector = targetPosition - transform.position;
        float rotateAngle = (Mathf.Atan2(rotateVector.y, rotateVector.x) * Mathf.Rad2Deg) - 90;
        Quaternion rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime);
    }
}
