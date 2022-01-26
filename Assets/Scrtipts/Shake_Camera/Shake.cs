using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public GameObject ShakeFX;
    public float ShakeDur;
    void Start()
    {
        ShakeFX.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            StartCoroutine(Shake1(ShakeDur));
        }   
    }
    IEnumerator Shake1(float t)
    {
        ShakeFX.SetActive(true);
        yield return new WaitForSeconds(t);
        ShakeFX.SetActive(false);
    }
}
