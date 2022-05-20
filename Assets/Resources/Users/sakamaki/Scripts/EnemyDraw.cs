using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDraw : MonoBehaviour
{
    /// <summary>
    /// エネミーのモードによって色をかえる関数
    /// </summary>
    /// <param name="enemyMode"> エネミーのタイプ </param>
    /// <param name="enemyObj"> エネミーのオブジェクト </param>>
    public void EnemyDrawColor(PlayerStatus.PlayerModeState enemyMode, GameObject enemyObj)
    {
        switch (enemyMode)
        {
            case PlayerStatus.PlayerModeState.Dark:
                enemyObj.GetComponent<Renderer>().material.color = new Color32(128, 0, 128, 255);
                break;
            case PlayerStatus.PlayerModeState.Light:
                enemyObj.GetComponent<Renderer>().material.color = new Color32(255, 204, 0, 255);
                break;
        }
    }

}
