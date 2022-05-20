using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDraw : MonoBehaviour
{
    [SerializeField] private ModeDraw _modeDraw;

    private void Start()
    {
        _modeDraw = GetComponent<ModeDraw>();
    }

    private void Update()
    {
        _modeDraw.PlayerDraw();
    }
}
