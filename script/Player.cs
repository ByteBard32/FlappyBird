using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public float jumpForce = 5f;
    public float forwardSpeed = 0f;
    private Rigidbody2D rb;

    public Sprite[] sprites;
    public float gravity = 1f;
    private int spriteIndex;
    private Vector3 direction;
    public AudioClip wings;
 
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
    private void Start()
    {

        InvokeRepeating(nameof(AnimateSprite),0.15f,0.15f);
        rb = GetComponent<Rigidbody2D>();
    }
   private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
            AudioSource.PlayClipAtPoint(wings, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Fall();
        }
       

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Fall()
    {
        rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
    }

   
    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D other){
         if (other.gameObject.CompareTag("Obstacle")) {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.CompareTag("Scoring")) {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}