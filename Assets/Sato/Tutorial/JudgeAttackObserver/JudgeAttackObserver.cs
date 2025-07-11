using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/********
 *  タックル判定の通知管理クラス(疑似オブザーバー)
 **/

public class JudgeAttackObserver : MonoBehaviour
{
    //タックルしていいか
    bool isOkAttack = false;

    //タックルしたか
    bool isAttack = false;

    //タックルに成功したか
    bool isSuccess = false;

    //土下座画像を出す
    bool isDogeza = false;

    //土下座できるか
    bool isHowDogeza = false;

    //土下座が終了したか
    bool isClearDogeza = false;

    private void Start()
    {
        //すべて初期化
        isOkAttack      = false;
        isAttack        = false;
        isSuccess       = false;
        isDogeza        = false;
        isHowDogeza     = false;
        isClearDogeza   = false;
    }

    public void SetOkAttack(bool result)
    {
        isOkAttack = result;
    }

    public bool GetOkAttack()
    {
        return isOkAttack;
    }


    public void SetSuccess(bool result)
    {
        isSuccess = result;
    }

    public bool GetSuccess()
    {
        return isSuccess;
    }

    public void SetIsAttack(bool result)
    {
        isAttack = result;
    }
    public bool GetIsAttack()
    {
        return isAttack;
    }
    public void SetIsDogeza(bool result)
    {
        isDogeza = result;
    }
    public bool GetIsDogeza()
    {
        return isDogeza;
    }
    public void SetHowDogeza(bool result)
    {
        isHowDogeza = result;
    }
    public bool GetHowDogeza()
    {
        return isHowDogeza;
    }
    public void SetIsClearDogeza(bool result)
    {
        isClearDogeza = result;
    }
    public bool GetIsClearDogeza()
    {
        return isClearDogeza;
    }
}

