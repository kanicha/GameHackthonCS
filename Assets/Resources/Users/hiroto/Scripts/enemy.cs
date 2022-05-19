using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // çUåÇìñÇΩÇ¡ÇΩÇÁè¡Ç∑
         Destroy(gameObject);
    }
}
