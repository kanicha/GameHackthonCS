using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyStatus
{
    public static int hp = 100;
    public static int atk = 20;

    public enum EnemyMoveState
    {
        None,
        Dash, // ����
        Attack,
    }
    public static EnemyMoveState playerMoveState = EnemyMoveState.None;
    public enum EnemyModeState
    {
        None,
        Light,
        Dark,
    }
    public static EnemyModeState enemyModeState = EnemyModeState.None;

}