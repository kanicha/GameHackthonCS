using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyStatus
{
    public static int hp = 0;
    public static int atk = 0;
    public static float speed = 1;

    public enum EnemyMoveState
    {
        None,
        Dash, // ‘–‚è
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