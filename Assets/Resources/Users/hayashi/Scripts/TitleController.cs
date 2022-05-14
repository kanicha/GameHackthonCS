using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField] Image _cursor;
    [SerializeField] GameObject[] _titleText;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 vec = Vector2.zero;
        vec = _titleText[0].transform.position;
        _cursor.transform.position = vec;

        //XŽ²‚ð‰ÁŽZ‚³‚¹‚é
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
