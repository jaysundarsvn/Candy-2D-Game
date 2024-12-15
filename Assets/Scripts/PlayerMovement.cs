using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 15f; 
    float xInput;
    Rigidbody2D rb;
    public bool canMove = true;
    public float Pos1;
    public float Pos2;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    void Move()
    {
        xInput = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * xInput * moveSpeed * Time.deltaTime;

        float xPos = Mathf.Clamp(transform.position.x, Pos1, Pos2);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
