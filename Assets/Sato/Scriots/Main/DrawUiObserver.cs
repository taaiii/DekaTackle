using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawUiObserver : MonoBehaviour
{
    //****************************
    //*         UI�`��Ǘ��N���X
    //*
    //* ���낢��ȃX�N���v�g��UI���Ǘ����Ă��邽�߁A
    //* �`���true,false�𓝈ꉻ���邽�߂ɍ쐬
    //* UiManager�ŁA��������Ƃ�UI�𐧌�
    //*
    //* UiManager�Ƌ@�\�������Ă��������A�V���O���g���N���X�ŋ@�\��������̂��������[���ɔ�����̂ŁA���̒ʒm�N���X���o�R����
    //*
    //* �ʒm�N���X�Ƃ������A�����̏�ԊǗ��N���X�ɂȂ�܂����B
    //*****

    public static DrawUiObserver Instance { get; private set; }

    //���̕ϐ����g���ĕ`��Ǘ�
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
