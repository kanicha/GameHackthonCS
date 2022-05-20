using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyStatus
{
    public static int MaxHp = 100;
    public static int atk = 30;

    public enum EnemyMoveState
    {
        None,
        Dash, 
        Attack,
    }
    public static EnemyMoveState enemyMoveState = EnemyMoveState.None;

    public static PlayerStatus.PlayerModeState enemyModeState = PlayerStatus.PlayerModeState.None;

}