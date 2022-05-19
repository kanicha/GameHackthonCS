using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private int moveSpeed = 5;
    [SerializeField]
    private int jumpForce = 3;

    private bool isMoving = false;
    public bool isJumping = false; // ジャンプしているかどうか true:している false:していない
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
            Vector3 scale = _player.transform.localScale;

            if(horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }

            _player.transform.localScale = scale;
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            isAttack = true;
            StartCoroutine(WaitForAttack());
            jemPrefab.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && !isJumping && !isFalling)
        {
            Jump();
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        Debug.Log(isJumping);
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
        jemPrefab.SetActive(false);
    }
}
