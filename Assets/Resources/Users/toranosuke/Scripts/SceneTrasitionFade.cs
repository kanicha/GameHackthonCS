
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTrasitionFade : MonoBehaviour
{
    //遷移を隠すためのイメージ
    [SerializeField]
    private GameObject fadecurtain;

    //フェードの速度
    private float fadespeed = 0.5f;

    //フェードの開始を合図するbool型変数
    private bool fadestart;

    // Start is called before the first frame update
    void Start()
    {
        //フェード用イメージの透明度を初期化(完全透明がデフォルト)
        Image image = fadecurtain.GetComponent<Image>();
        image.color = new Color(0f, 0f, 0f, 0.0f);   
        //フェード用カーテンを非表示にする
        fadecurtain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            fadestart = true;
        }

        if(fadestart)
        {
            fadecurtain.SetActive(true);

            Image image = fadecurtain.GetComponent<Image>();
            image.color += new Color(0f, 0f, 0f, fadespeed * Time.deltaTime);
        }


    }
}