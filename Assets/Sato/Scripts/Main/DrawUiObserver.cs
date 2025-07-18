using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawUiObserver : MonoBehaviour
{
    //****************************
    //*         UI描画管理クラス
    //*
    //* いろいろなスクリプトでUIを管理しているため、
    //* 描画のtrue,falseを統一化するために作成
    //* UiManagerで、これをもとにUIを制御
    //*
    //* UiManagerと機能統合してもいいが、シングルトンクラスで機能処理するのが自分ルールに反するので、この通知クラスを経由する
    //*
    //* 通知クラスというより、ただの状態管理クラスになりました。
    //*****

    public static DrawUiObserver Instance { get; private set; }

    //この変数を使って描画管理
    bool isView = true;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public void SetIsView(bool view)
    {
        isView = view;
    }

    public bool GetIsView()
    {
        return isView;
    }

}
