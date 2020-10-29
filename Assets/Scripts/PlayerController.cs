using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true)
        {
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlaneA"))
        {
            Grounded = true;
        }
        else if (collision.gameObject.CompareTag("PlaneB"))
		{
            Grounded = true;
		}
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlaneA"))
        {
            Grounded = false;
        }
        else if (collision.gameObject.CompareTag("PlaneB"))
		{
            Grounded = false;
		}
    }

    float speed = 15.0f;
    float xLimit = 10.0f;
    float yLimit = 10.0f;
    float zLimit = 20.0f;
    Rigidbody playerRb;
    bool Grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * VerticalInput * speed);
        float HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * HorizontalInput * speed);

        // Plane A
        // Transform X
        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }

        // Transform Y
        if (transform.position.y < -yLimit)
        {
            transform.position = new Vector3(transform.position.x, -yLimit, transform.position.z);
        }
        else if (transform.position.y > yLimit)
        {
            transform.position = new Vector3(transform.position.x, yLimit, transform.position.z);
        }

        // Transform Z (+B)
        if (transform.position.z < -zLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zLimit);
        }
        else if (transform.position.z > zLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }
        else if (transform.position.z < -10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }


        // Boundaries
        if (transform.position.x > 5 && transform.position.z > 10)
		{
            transform.position = new Vector3(transform.position.x, transform.position.y, 10);
		}
        else if (transform.position.x < -5 && transform.position.z > 10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 10);
        }

        // Plane B
        // Transform X

        if (transform.position.x < -5 && transform.position.z > 10)
        {
            transform.position = new Vector3(-5, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 5 && transform.position.z > 10)
        {
            transform.position = new Vector3(5, transform.position.y, transform.position.z);
        }
        PlayerJump();
    }
}
