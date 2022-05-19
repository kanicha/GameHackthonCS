using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderCheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag.Equals("Enemy"))
        {
            Debug.Log("enemy");

            // EnemyオブジェクトのHP実数値を習得してきてPlayerのATK分値を減らす
            col.gameObject.GetComponent<EnemyControler>()._localHp -= PlayerStatus.atk;
        }
    }
}
