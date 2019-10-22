using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public GameObject boltPrefab;

    private Vector3 targetPosition;
    private Vector2 rotateVector;

    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotateVector = targetPosition - transform.position;

        Move();

        //rotate player to cursor
        RotateToCursor();  
        
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("fire");
            Shoot();
        }
    }

    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed, 0.0f);

        // transform.position = transform.position + movement * Time.deltaTime;

        rb2D.velocity = new Vector2(movement.x, movement.y);
    }

    private void RotateToCursor()
    {        
        float rotateAngle = (Mathf.Atan2(rotateVector.y, rotateVector.x) * Mathf.Rad2Deg) - 90;
        Quaternion rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);
    }

    private void Shoot()
    {
        Vector2 shootDirection = targetPosition - transform.position;
        shootDirection.Normalize();

        GameObject bolt = Instantiate(boltPrefab, transform.position, Quaternion.identity);
        bolt.GetComponent<Rigidbody2D>().velocity = shootDirection;
        bolt.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(rotateVector.y, rotateVector.x) * Mathf.Rad2Deg);
        Destroy(bolt, 2.0f);
    }
}
