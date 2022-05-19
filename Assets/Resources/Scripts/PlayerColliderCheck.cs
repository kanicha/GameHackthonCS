using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderCheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        // 着地した先が地面であったらfalseにする
        if (col.transform.tag.Equals("Ground"))
        {
            PlayerStatus.playerMoveState = PlayerStatus.PlayerMoveState.Idle;
            PlayerStatus.isJump = false;
        }
    }
}