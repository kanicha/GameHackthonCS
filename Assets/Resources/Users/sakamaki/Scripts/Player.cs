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
    private bool isAttack = false;

    public GameObject attackObj;

    private string deadArea = "DeadArea";

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isMoving = horizontal != 0;

        if(isMoving)
        {
            // 移動中なのでモードを変更
            PlayerStatus.playerMoveState = PlayerStatus.PlayerMoveState.Dash;
            
            Vector3 scale = _player.transform.localScale;

            if(horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }

            _player.transform.localScale = scale;
        }
        else
        {
            PlayerStatus.playerMoveState = PlayerStatus.PlayerMoveState.Idle;
        }

        // 攻撃
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAttack = true;
            StartCoroutine(WaitForAttack());
            attackObj.SetActive(true);
        }
        // ジャンプ
        else if(Input.GetKeyDown(KeyCode.Space) && PlayerStatus.playerMoveState != PlayerStatus.PlayerMoveState.Jump)
        {
            Jump();
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        // ジャンプをおこなうのでステートを代入
        PlayerStatus.playerMoveState = PlayerStatus.PlayerMoveState.Jump; 
 
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
        attackObj.SetActive(false);
    }
}
