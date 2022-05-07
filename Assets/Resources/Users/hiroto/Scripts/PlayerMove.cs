using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerMove : MonoBehaviour
{
    // 当たり判定
    [SerializeField]
    private Rigidbody2D rb;
    // 移動速度
    [SerializeField]
    private int MoveSpeed;
    // ジャンプ力
    [SerializeField]
    private int JumpForce;
    // 2段ジャンプ用
    private bool isJumping = false;

    // Update is called once per frame
    void Update()
    {
        // ジャンプ
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping && !(rb.velocity.y < -0.5f))
        {
            Jump();
        }
        // 左右移動
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 2段ジャンプ禁止
        if (collision.CompareTag("Stage"))
        {
            isJumping = false;
        }
    }
}


// 攻撃を実装