using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_active : MonoBehaviour
{
    public GameObject shield;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="shield")
        {
            shield.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}