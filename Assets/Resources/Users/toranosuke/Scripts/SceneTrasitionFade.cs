
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTrasitionFade : MonoBehaviour
{
    //インスタンスの作成
    public static SceneTrasitionFade instanc;

    //遷移先のシーン名
    [SerializeField]
    private string nextScene;

    //遷移を隠すためのイメージ
    [SerializeField]
    private GameObject fadecurtain;

    //フェードの速度
    private float fadespeed = 0.02f;

    //フェードアウトを始めるためのbool型変数
    [SerializeField]
    private bool fadeout = false;

    //フェードインを始めるためのbool型変数
    [SerializeField]
    private bool fadein = true;

    //フェードインを行う関数
    private void FadeIn()
    {
        Image image = fadecurtain.GetComponent<Image>();
        image.color = new Color(0,0,0,1f);

        while(fadein)
        {
            image.color -= new Color(0f, 0f, 0f, fadespeed * Time.deltaTime);
            if(image.color.a <= 0.1f)
            {
                image.color = new Color(0,0,0,0f);
                fadein = false;
            }
        }            
    }

    //フェードアウトを行う関数
    private void FadeOut()
    {
        Image image = fadecurtain.GetComponent<Image>();
        image.color = new Color(0,0,0,0f);

        while(fadeout)
        {
            image.color += new Color(0f, 0f, 0f, fadespeed * Time.deltaTime);
            if(image.color.a >= 0.9f)
            {
                image.color = new Color(0,0,0,1f);
                fadeout = false;    
                //シーンを遷移させるコード
                SceneManager.LoadScene($"{nextScene}");            
            }
        }            
    }

    //他のスクリプトからフェードアウトとシーン遷移を行うための関数
    public void FadeStart()
    {
        fadeout = true;
    }

    void Start() {
        //シーンを切り替えた直後にフェードインを実行
        FadeIn();
    }

    void FiUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            //FadeStart();
        }

        if(fadein)
        {
            Image image = fadecurtain.GetComponent<Image>();
            image.color = new Color(0,0,0,1f);

            while(fadein)
            {
                image.color -= new Color(0f, 0f, 0f, fadespeed * Time.deltaTime);
                if(image.color.a <= 0.1f)
                {
                    image.color = new Color(0,0,0,0f);
                    fadein = false;
                }
            }
        }

        if(fadeout)
        {
            //フェードアウトを実行
            //FadeOut();
            Image image = fadecurtain.GetComponent<Image>();
            image.color = new Color(0,0,0,0f);

            while(fadeout)
            {
                image.color += new Color(0f, 0f, 0f, fadespeed * Time.deltaTime);
                if(image.color.a >= 0.9f)
                {
                    image.color = new Color(0,0,0,1f);
                    fadeout = false;    
                    //シーンを遷移させるコード
                    SceneManager.LoadScene($"{nextScene}");            
                }
            }
        }            
    }
}