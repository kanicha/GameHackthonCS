using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private float spd = 0.0f;
    public bool is_right_local = true;

    // Update is called once per frame
    void Update()
    {
        if (is_right_local)
        {
            transform.Translate(Vector3.right * spd);
        }
        else
        {
            transform.Translate(Vector3.left * spd);
            transform.localScale = new Vector3(-2, 2, 0);
        }
       // Destroy(gameObject, 1.0f);       
    }

    void setDirection(bool isMoving = true)
    {
        is_right_local = isMoving;
    }

}
