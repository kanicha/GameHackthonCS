using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderCheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        // 着地した先が地面であったらfalseにする
        if (col.transform.tag.Equals("Ground"))
        {
            PlayerStatus.playerMoveState = PlayerStatus.PlayerMoveState.Idle;
            PlayerStatus.isJump = false;
        }
    }

    /// <summary>
    /// あたったオブジェクトにを習得してシーン分岐
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag.Equals("Goal"))
        {
            SoundManager.Instance.PlaySE(4);
            FadeContoller.Instance.LoadScene(0.2f, GameScene.GameClear);
            SoundManager.Instance.StopBGM();
        }
        else if (col.transform.tag.Equals("Dead"))
        {
            SoundManager.Instance.PlaySE(2);
            FadeContoller.Instance.LoadScene(0.2f, GameScene.GameOver);
            SoundManager.Instance.StopBGM();
        }
        else if (col.transform.tag.Equals("Heal"))
        {
            SoundManager.Instance.PlaySE(3);
            PlayerStatus.HP = PlayerStatus.maxHP;
            Destroy(col.gameObject);
            
        }
    }
}