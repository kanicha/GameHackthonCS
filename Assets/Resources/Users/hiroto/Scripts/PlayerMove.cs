using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerMove : MonoBehaviour
{
    // �����蔻��
    [SerializeField]
    private Rigidbody2D rb;
    // �ړ����x
    [SerializeField]
    private int MoveSpeed;
    // �W�����v��
    [SerializeField]
    private int JumpForce;
    // 2�i�W�����v�p
    private bool isJumping = false;

    // Update is called once per frame
    void Update()
    {
        // �W�����v
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping && !(rb.velocity.y < -0.5f))
        {
            Jump();
        }
        // ���E�ړ�
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 2�i�W�����v�֎~
        if (collision.CompareTag("Stage"))
        {
            isJumping = false;
        }
    }
}


// �U��������