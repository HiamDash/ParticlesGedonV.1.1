using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedSistem : MonoBehaviour
{
    public float moveSpeed;
    public AudioSource PlayerAudioSource;
    public AudioClip speedBoostAudioClip;
    
    Rigidbody2D rb;
    Collider2D myCollider;

    private UnityEngine.Object explosion;    
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        explosion = Resources.Load("Explosion");
    }

     void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if(moveSpeed < 0|| moveSpeed == 0)
        {
            SceneManager.LoadScene(0);
        }
        moveSpeed +=0.5F * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("speedBoost"))
        {
            PlayerAudioSource.PlayOneShot(speedBoostAudioClip);
            moveSpeed += 5;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("speedLet"))
        {
            GameObject explosionRef = (GameObject)Instantiate(explosion);
            explosionRef.transform.position = new Vector3(transform.position.x+5, transform.position.y+5, transform.position.z);
            moveSpeed -= 15;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("speedCheck"))
        {
            if(moveSpeed >= 35)
            {
            Destroy(other.gameObject);
            GameObject explosionRef = (GameObject)Instantiate(explosion);
            explosionRef.transform.position = new Vector3(transform.position.x+5, transform.position.y+5, transform.position.z);
            }
            else
            {
            SceneManager.LoadScene(0);
            }
        }
    }
}
