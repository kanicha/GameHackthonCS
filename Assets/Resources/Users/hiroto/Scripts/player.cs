using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]

public class player : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private int moveSpeed = 5;
    [SerializeField]
    private int jumpForce = 3;

    private bool isMoving = false;
    private bool isJumping = false;
    private bool isFalling = false;
    private bool isAttack = false;

    public GameObject jemPrefab;

    private string deadArea = "DeadArea";

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isMoving = horizontal != 0;
        isFalling = rb.velocity.y < -0.5f;
        
        if(isMoving)
        {
            Vector3 scale = gameObject.transform.localScale;

            if(horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }

            gameObject.transform.localScale = scale;
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping && !isFalling)
        {
            Jump();
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
        animator.SetBool("isAttack", isAttack);
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Untagged"))
        {
            isJumping = false;
        }

        if(collision.gameObject.tag == "GameOver")
        {
            SceneManager.LoadScene("GameOver");
        }

        else if (collision.gameObject.tag == "GameClear")
        {
            SceneManager.LoadScene("GameClear");
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isAttack = true;
            StartCoroutine("WaitForAttack");
            jemPrefab.SetActive(true);
        }
    }

    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
        jemPrefab.SetActive(false);
    }
}
