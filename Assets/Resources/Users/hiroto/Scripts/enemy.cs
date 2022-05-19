using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
         Destroy(gameObject);
    }
}
