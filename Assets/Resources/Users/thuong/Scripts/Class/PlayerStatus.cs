using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public static class PlayerStatus
{
    public static int hp = 0;
    public static int atk = 0;
    public static int sp = 0;
    public static float speed = 1;

    public enum PlayerMoveState
    {
        None,
        Dash,
        Jumb,
        Dodge,
    }
    public static PlayerMoveState playerMoveState = PlayerMoveState.None;
    public enum PlayerModeState
    {
        None,
        Light,
        Dark,
    }
    public static PlayerModeState playerModeState = PlayerModeState.None;

}
