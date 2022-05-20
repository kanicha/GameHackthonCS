
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーとエネミーのモードを習得してそれに応じて見た目やUIを変化させるクラス
/// </summary>
public class ModeDraw : MonoBehaviour
{
    [SerializeField] private Text _playerModeText;
    [SerializeField] private GameObject _playerObj;

    public void PlayerDraw()
    {
        PlayerModeDraw();
        PlayerModeUIDraw();
    }
    
    /// <summary>
    /// プレイヤーの見た目を変化をさせる関数
    /// </summary>
    private void PlayerModeDraw()
    {
        switch (PlayerStatus.playerModeState)
        {
            case PlayerStatus.PlayerModeState.Dark:
                _playerObj.GetComponent<Renderer>().material.color = new Color32(128, 0, 128, 255);
                break;
            case PlayerStatus.PlayerModeState.Light:
                _playerObj.GetComponent<Renderer>().material.color = new Color32(255, 204, 0, 255);
                break;
        }
    }

    /// <summary>
    /// プレイヤーの見た目が変化した時(モードが変化された時)
    /// 画面上部のテキストの変更を行う関数
    /// </summary>
    private void PlayerModeUIDraw()
    {
        switch (PlayerStatus.playerModeState)
        {
            case PlayerStatus.PlayerModeState.Dark:
                _playerModeText.text = "闇";
                _playerModeText.color = new Color32(128, 0, 128, 255);
                break;
            case PlayerStatus.PlayerModeState.Light:
                _playerModeText.text = "光";
                _playerModeText.color = new Color32(255, 204, 0, 255);
                break;
        }
    }
}
