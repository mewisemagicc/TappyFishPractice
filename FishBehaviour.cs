using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] private float _Speed;
    int angle;
    int MaxAngle =20;
    int MinAngle =-60;
    public Score score;
    public static bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obstaclespawner;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        FishSwim();

    }
    private void FixedUpdate()
    {
        
        FishRotation();
    }

    void FishSwim()
    {
    if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            if(GameManager.gameStarted == false)
            {
                _rb.gravityScale = 4f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _Speed);
                obstaclespawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else 
            {

                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _Speed);
            }

        }
    }

    void FishRotation()
    {
         if(_rb.velocity.y > 0)
    {
        if(angle <= MaxAngle)
        {
            angle = angle + 4;
        }

    }
    else if(_rb.velocity.y < -1.2)
    {
        if(angle > MinAngle)
        {
            angle = angle - 1 ;

        }
    }
         if(touchedGround==false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);

        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("obstacle"))
        {
            //Debug.Log("scored!");
            score.Scored();
        }
        else if(collision.CompareTag("column"))
        {
            //gameover
            gameManager.GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            //Debug.Log("yerle temas etti");
            //game over
            if(GameManager.gameOver == false)
            {
                gameManager.GameOver();
                GameOver();
            }
           
       
        }
        else if (collision.gameObject.CompareTag("column"))
        {
            //game over
            GameOver();
        }
    }
    public void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0,0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }
}
