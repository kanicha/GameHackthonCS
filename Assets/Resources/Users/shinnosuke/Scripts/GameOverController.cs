using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Image _curor;
    [SerializeField] GameObject[] _titleText;
   
    // Start is called before the first frame update
    void Start()
    {
        Vector2 vec = Vector2.zero;
        vec = _titleText[0].transform.position;
        _curor.transform.position = vec;

        // XŽ²‚ð‚©‚³‚ñ
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
