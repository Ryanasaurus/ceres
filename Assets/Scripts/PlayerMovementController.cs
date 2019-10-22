using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 5;
    private Vector3 targetPosition;
    private Vector2 rotateVector;

    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        //rotate player to cursor
        RotateToCursor();        
    }

    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed, 0.0f);

        // transform.position = transform.position + movement * Time.deltaTime;

        rb2D.velocity = new Vector2(movement.x, movement.y);
    }

    private void RotateToCursor()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotateVector = targetPosition - transform.position;
        float rotateAngle = (Mathf.Atan2(rotateVector.y, rotateVector.x) * Mathf.Rad2Deg) - 90;
        Quaternion rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);
    }
}
