using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pelota : MonoBehaviour
{
    public Rigidbody2D body;
    public float Vel = 0f;
    public GameObject floor;
    public GameObject player;
    public GameObject ball;
    public Text gameoverText;
    public Text scoreText;
    public Text winText;

    private int count;
    private int countNivel;
    private float dif;
    private Vector2 dir;
    
    // Start is called before the first frame update
    void Start()
    {
        body.velocity = Vector2.down * Vel;
        count = 0;
        gameoverText.text = "";
        winText.text = "";
        SetScoreText();
        countNivel = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var otherObject = col.collider.gameObject;
        
        if (col.gameObject == floor)
        {
            body.velocity = Vector2.zero * Vel;
            gameoverText.text = "La contraparte ha ganado. La humanidad está perdida.";
            scoreText.text = "";

        }

        if (otherObject.tag == "block")
        {
            GameObject.Destroy(otherObject);
            count += 1;
            countNivel += 1;
            SetScoreText();
        }

        if (col.gameObject == player)
        {            
            float x;
           
            if (transform.position.x < 0)
            {
                x = 1;
            }
           
            else
            {
                x = -1;
            }
            
            dif = (transform.position.y - col.transform.position.y) / col.collider.bounds.size.y;
            dir = new Vector2(x, dif).normalized;
            body.velocity = dir * Vel;
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Planetas conquistados: " + count.ToString();
        if (count == 9)
        {
            ball.SetActive(false);
            winText.text = "¡Felicidades!\n Haz salvado a la humanidad.";
            scoreText.text = "";
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        if (countNivel == 3)
        {
            countNivel = 0;
            Vel += 2f;
            body.velocity = Vector2.down * Vel;
        }

    }
}
