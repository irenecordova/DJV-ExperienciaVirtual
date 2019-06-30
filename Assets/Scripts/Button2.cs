using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button2 : MonoBehaviour
{
    public Rigidbody2D body;
    public float Vel = 0f;
    public GameObject history;
    public GameObject ball;
    public GameObject planets;
    public GameObject player;

   
    // Start is called before the first frame update
    void Start()
    {
        body.velocity = Vector2.down * Vel;
    }

       
    // Update is called once per frame
    void Update()
    {
    }

    public void beginning()
    {        
        history.SetActive(false);       
        ball.SetActive(true);
        planets.SetActive(true);
        player.SetActive(true);
        Vel = 5f;
        body.velocity = Vector2.down * Vel;
    }
}
