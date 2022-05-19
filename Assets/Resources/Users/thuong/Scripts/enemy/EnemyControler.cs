using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyControler : MonoBehaviour
{
    
    public float EyesRange;
    public float atackRange;
    private Transform Player;
    public float speed, speed2;
    public List<GameObject> LimitMovingRange;
    public Rigidbody2D rb;
    private float attackCountdown = 0f;
    public float attackRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform; //　playerを探す
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
         if (distance > EyesRange)
        {
            //MovingAround();
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
        PlayerStatus.HP -= 20;
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
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
