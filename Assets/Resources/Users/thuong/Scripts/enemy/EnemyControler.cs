using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyControler : MonoBehaviour
{

    public Vector2 EyesRange;
    public Vector2 atackRange;
    private Transform Player;

    public float HP = 100;
    public float speed = 200f;
   
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform; //　playerを探す
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(Player.position, transform.position);　//　distance of ObjEnemy with ObjTagPlayer
        
        if (distanceFromPlayer < EyesRange.x && distanceFromPlayer > atackRange.x  ) // 
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.position, speed * Time.deltaTime);
           
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
    }
    
}
