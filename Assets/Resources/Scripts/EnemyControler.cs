using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyControler : MonoBehaviour
{
    [SerializeField] private EnemyDraw _enemyDraw;
    
    public float EyesRange;
    public float atackRange;
    private Transform Player;
    public float speed, speed2;
    public List<GameObject> LimitMovingRange;
    public Rigidbody2D rb;
    private float attackCountdown = 0f;
    public float attackRate = 1f;
    public int _localHp = EnemyStatus.MaxHp;
    // HPと同じで個々でモードを持っておく
    public PlayerStatus.PlayerModeState enemyMode;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Players").transform; //　playerを探す
        /*enemyMode = PlayerStatus.PlayerModeState.Dark;*/

        // 見た目の表示
        _enemyDraw.EnemyDrawColor(enemyMode, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        attackCountdown -= Time.deltaTime;
        //
        float distance = Vector2.Distance(Player.position, transform.position);　//　distance of ObjEnemy with ObjTagPlayer

        if (distance < EyesRange && distance > atackRange) // 
        {
            DetectPlayer();
        }
        if (distance <= atackRange)
        {
            Attack();
        }
        if (_localHp <= 0)
        {
            Die();
        }
       
    }
    


    private void OnDrawGizmosSelected() // draw for easy to see range
    {
        Gizmos.color = Color.red;
        var position = transform.position;
        Gizmos.DrawWireSphere(position, atackRange);
        Gizmos.DrawWireSphere(position, EyesRange);
    }

    private void DetectPlayer()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, Player.position, speed * Time.deltaTime);
         //transform.position = Vector3.Lerp(this.transform.position, Player.transform.position, speed * Time.deltaTime);
    }
    private void Attack()
    {
        if(attackCountdown <= 0f)

        {
            attackCountdown = 1f / attackRate;
            StartCoroutine(DoAttack(.6f));
        }

    }
    IEnumerator DoAttack( float delay)
    {
        print("Start");
        yield return new WaitForSeconds(delay);
        PlayerStatus.HP -= EnemyStatus.atk;
    }


    private void MovingAround() // まだ出来ない
    {
        rb.velocity = new Vector2(speed2 * Time.fixedDeltaTime, 0f);
    }
    //----------
    private void Patrol()
    {
        Flip();
    }
    private void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    private void Die()  // example for player
    {
        // add effect 
        Destroy(gameObject);
    }
}
