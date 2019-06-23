using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pelota : MonoBehaviour
{
    public Rigidbody2D body;
    public float Vel = 5f;
    public GameObject floor;
    public Text gameoverText;
    public Text scoreText;
    public Text winText;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        body.velocity = Vector2.down * Vel;
        count = 0;
        gameoverText.text = "";
        winText.text = "";
        SetScoreText();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var otherObject = col.collider.gameObject;
        if (col.gameObject == floor)
        {
            body.velocity = Vector2.zero * Vel;
            gameoverText.text = "Game Over Puntaje: " +  count.ToString();
            scoreText.text = "";

        }

        if (otherObject.tag == "block")
        {
            GameObject.Destroy(otherObject);
            count += 10;
            SetScoreText();
        }
    }


    void SetScoreText(){
        scoreText.text = "Puntaje: " + count.ToString();
        if (count == 50)
        {
            winText.text = "¡Felicidades! Haz ganado el juego. Puntaje: " + count.ToString();
            scoreText.text = "";
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
