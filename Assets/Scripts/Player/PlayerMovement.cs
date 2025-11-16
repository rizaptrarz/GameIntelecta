using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerrb;
    [SerializeField] float speed;   
    Vector2 horizontalVel;


    void Update()
    {
        horizontalVel = new Vector2(Input.GetAxis("Horizontal") * speed, playerrb.velocity.y);

        playerrb.velocity = horizontalVel;
    }
}
