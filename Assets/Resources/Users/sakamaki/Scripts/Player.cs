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

        PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Light;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isMoving = horizontal != 0;

        // 移動
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

        PlayerActions();
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        // ヘルスバーとプレイヤーのHPを同期させる処理
        _healthBar.SetHealth(PlayerStatus.HP);
        Die();
    }

    /// <summary>
    /// プレイヤーがボタンを押したときに動作する行動処理をまとめた関数
    /// </summary>
    private void PlayerActions()
    {
        // 攻撃
        if(Input.GetKeyDown(KeyCode.X))
        {
            PlayerStatus.playerMoveState = PlayerStatus.PlayerMoveState.Attack;
            
            StartCoroutine(WaitForAttack());
            attackObj.SetActive(true);
        }
        // ジャンプ
        else if(Input.GetKeyDown(KeyCode.Z) && !PlayerStatus.isJump)
        {
            Jump();
        }
        // モードチェンジ
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ModeChange();
        }
    }
    
    void Jump()
    {
        // ジャンプをおこなうのでステートを代入
        PlayerStatus.playerMoveState = PlayerStatus.PlayerMoveState.Jump;
        PlayerStatus.isJump = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// プレイヤーがモードチェンジをおこなう処理
    /// </summary>
    private void ModeChange()
    {
        if (PlayerStatus.playerModeState == PlayerStatus.PlayerModeState.Dark)
        {
            PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Light;
        }
        else if (PlayerStatus.playerModeState == PlayerStatus.PlayerModeState.Light)
        {
            PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Dark;
        }
        else
        {
            PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Light;
        }
        
        Debug.Log(PlayerStatus.playerModeState);
    }
    
    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(0.3f);
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
            FadeContoller.Instance.LoadScene(0.2f, GameScene.GameOver);
        }
    }
}
