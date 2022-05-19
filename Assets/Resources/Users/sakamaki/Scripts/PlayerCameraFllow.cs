using System;
using UnityEngine;

/// <summary>
/// プレイヤーにカメラを追従させるクラス
/// </summary>
public class PlayerCameraFllow : MonoBehaviour
{
    [SerializeField, Header("追従させるプレイヤーオブジェクト")]
    private GameObject _playerObj;
    [SerializeField, Header("カメラオブジェクト")] 
    private Camera _cameraObj;
    [SerializeField] private Vector3 _offset;
    private void Start()
    {
        // 初期化
        _cameraObj.transform.position = _playerObj.transform.position;
    }

    private void Update()
    {
        Follow();
    }

    /// <summary>
    /// 実際にプレイヤーオブジェクトとプレイヤーオブジェクトを同期させる処理
    /// </summary>
    private void Follow()
    {
        Vector3 cameraVec = _playerObj.transform.position + _offset;
        _cameraObj.transform.position = cameraVec;
    }
}