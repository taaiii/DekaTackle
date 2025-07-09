using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/********
 *  タックル判定の通知管理クラス(能動的な疑似オブザーバー)
 *  
 *  atacckManagerで判定Set
 *  TutorialManagerで判定を使用
 *  
 **/

public class JudgeAttackObserver : MonoBehaviour
{

    //タックルしていいか
    bool isOkAttack = false;

    //タックルしたか
    bool isAttack = false;

    //タックルに成功したか
    bool isSuccess = false;

    //土下座タイミング
    bool isDogeza = false;

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

}

