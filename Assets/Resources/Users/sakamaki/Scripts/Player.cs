using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private int moveSpeed = 5;
    [SerializeField]
    private int jumpForce = 3;

    private bool isMoving = false;
    public GameObject attackObj;

    private string deadArea = "DeadArea";

    private void Start()
    {
        // プレイヤーHPの初期化
        PlayerStatus.HP = PlayerStatus.maxHP;
        _healthBar.SetMaxHealth(PlayerStatus.maxHP);
    }

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
            PlayerStatus.playerMoveState = PlayerStatus.PlayerMoveState.Attack;
            
            StartCoroutine(WaitForAttack());
            attackObj.SetActive(true);
        }
        // ジャンプ
        else if(Input.GetKeyDown(KeyCode.Space) && PlayerStatus.playerMoveState != PlayerStatus.PlayerMoveState.Jump)
        {
            Jump();
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        
        
        // ヘルスバーとプレイヤーのHPを同期させる処理
        _healthBar.SetHealth(PlayerStatus.HP);
        Die();
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
        PlayerStatus.playerMoveState = PlayerStatus.PlayerMoveState.Idle;
        attackObj.SetActive(false);
    }
    
    /// <summary>
    /// プレイヤーのHPが0以下になった時オブジェクトを削除する
    /// </summary>
    private void Die()  // example for player
    {
        if (PlayerStatus.HP <= 0)
        {
            Destroy(_player.gameObject);
        }
    }
}
