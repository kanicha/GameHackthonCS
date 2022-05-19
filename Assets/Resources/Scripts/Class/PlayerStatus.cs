
    public static class PlayerStatus
{
    public static int HP ;
    public static int maxHP = 100;
    public static int atk = 100;
    public static int sp = 0;
    public static float speed = 1;

    public enum PlayerMoveState
    {
        None,
        Idle,
        Dash,
        Attack,
        Jump,
        Dodge
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
