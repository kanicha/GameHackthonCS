
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region EnemyOne
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject player;
}
