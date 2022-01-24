using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public GameObject grabDetector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if (Input.GetKeyDown("up"))
        {
            rb.velocity = new Vector3(rb.velocity.x, 5f, 0);
        }

        if (Input.GetKeyDown("left"))
        {
            sr.flipX = false;
            grabDetector.transform.position = new Vector3(GetComponent<Transform>().position.x - 0.80f, grabDetector.transform.position.y, grabDetector.transform.position.z);
            rb.velocity = new Vector3(-5f, rb.velocity.y, 0);
        }

        if (Input.GetKeyDown("right"))
        {
            sr.flipX = true;
            grabDetector.transform.position = new Vector3(GetComponent<Transform>().position.x + 0.80f, grabDetector.transform.position.y, grabDetector.transform.position.z);
            rb.velocity = new Vector3(5f, rb.velocity.y, 0);
        }

    }

    private float checkValue(float number)
    {

        if (number > 0 && sr.flipX)
        {
            Debug.Log(number);
            return number;
        }
        if (number > 0 && !sr.flipX)
        {
            Debug.Log(number);
            Debug.Log(number * -1f);
            return number * -1f;
        }
        if (number < 0 && !sr.flipX)
        {
            Debug.Log(number);
            return number;
        }
        if (number < 0 && sr.flipX)
        {
            Console.WriteLine(number);
            Console.WriteLine(number * -1f);
            return number * -1f;
        }

        return number;
    }

}