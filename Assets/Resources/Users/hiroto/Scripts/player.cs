using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private int moveSpeed = 5; // 移動速度
    [SerializeField]
    private int jumpForce = 3; // ジャンプ力
    [SerializeField] GameObject GemPrefab; // 攻撃

    // 各行動用
    private bool isMoving = false;
    private bool isJumping = false;
    private bool isFalling = false;
    private bool isAttack = false;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // 左右移動

        //// アニメーション用
        //isMoving = horizontal != 0;
        //isFalling = rb.velocity.y < -0.5f;

        if (isMoving)
        {
            Vector3 scale = gameObject.transform.localScale;

            if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }

            gameObject.transform.localScale = scale;
        }

        // スペースキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isFalling)
        {
            Jump();
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        // 左シフトで攻撃
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isAttack)
        {
            isAttack = true;
            StartCoroutine("WaitForAttack");
            GemPrefab.SetActive(true);
        }
    }

    // ジャンプ力計算
    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // 二段ジャンプ禁止
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Untagged"))
        {
            isJumping = false;
        }
    }

    // 0.5秒経ったら攻撃エフェクト消す
    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
        GemPrefab.SetActive(false);
    }
}


