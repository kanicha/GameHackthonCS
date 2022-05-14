using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{

    public Vector2 EyesRange;
    public Vector2 atackRange;
    public Rigidbody2D rb;
      private Transform Player;
    public float speed ;
    public bool mustMove = true;
    public bool mustTurn;
    public Transform groundCheckPos;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform; //　playerを探す
        //mustMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustMove)
        {
            Move();
            /*float  distanceFromPlayer = Vector2.Distance(Player.position, transform.position);　//　distance of ObjEnemy with ObjTagPlayer

            if (distanceFromPlayer < EyesRange.x  && distanceFromPlayer > atackRange.x  ) // 
            {
                transform.position = Vector2.MoveTowards(this.transform.position, Player.position, EnemyStatus.speed * Time.deltaTime);
               //transform.position = Vector3.Lerp(this.transform.position, Player.transform.position, EnemyStatus.speed * Time.deltaTime);
            }
            if (distanceFromPlayer < atackRange.x)
            {
                Debug.Log("-HP");

            }

        }
        private void OnDrawGizmosSelected() // draw 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, atackRange);
            Gizmos.DrawWireCube(transform.position, EyesRange);
        }*/
        }
       
    }
    private void FixedUpdate()
    {
        if (mustMove)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    void Move()
        {
        if(mustTurn)
        {
            Flip();
        }
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        }
    void Flip()
    {
        mustMove = false;
        transform.position = new Vector2(transform.position.x * -1, transform.position.y);
        speed *= -1;
        mustMove = true;
    }
    
    
}
