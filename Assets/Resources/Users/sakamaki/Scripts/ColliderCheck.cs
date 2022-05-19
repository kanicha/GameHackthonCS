using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnCollisionEnter2D(Collision2D col)
    {
        // 着地した先が地面であったらfalseにする
        if (col.transform.tag.Equals("Ground"))
            _player.isJumping = false;
    }
}