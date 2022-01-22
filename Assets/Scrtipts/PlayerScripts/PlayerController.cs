using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jetpackForce = 75.0f;
    
    Rigidbody2D rb;
    Collider2D myCollider;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if(moveSpeed < 0|| moveSpeed == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    
void FixedUpdate()
    {
        bool jetpackActive = Input.GetButton("Jump");
        if (jetpackActive)
        {
            rb.AddForce(new Vector2(0, jetpackForce));
        }
    }
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("speedBoost"))
        {
            moveSpeed += 5;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("speedLet"))
        {
            moveSpeed -= 5;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("speedCheck"))
        {
            if(moveSpeed >= 25)
            {
            Destroy(other.gameObject);
            }
            else
            {
            SceneManager.LoadScene(0);
            }
        }
    }
    
}
