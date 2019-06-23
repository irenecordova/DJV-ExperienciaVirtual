using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

    public Rigidbody2D body;
    public float walkingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        var v = body.velocity;
        var speed = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed += -walkingSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed += +walkingSpeed;
        }

        v.x = speed;
        body.velocity = v;
        
    }
}
