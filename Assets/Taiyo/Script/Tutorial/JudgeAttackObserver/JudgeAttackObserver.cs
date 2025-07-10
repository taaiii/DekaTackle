using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/********
 *  �^�b�N������̒ʒm�Ǘ��N���X(�^���I�u�U�[�o�[)
 **/

public class JudgeAttackObserver : MonoBehaviour
{
    //�^�b�N�����Ă�����
    bool isOkAttack = false;

    //�^�b�N��������
    bool isAttack = false;

    //�^�b�N���ɐ���������
    bool isSuccess = false;

    //�y�����摜���o��
    bool isDogeza = false;

    //�y�����ł��邩
    bool isHowDogeza = false;

    //�y�������I��������
    bool isClearDogeza = false;

    private void Start()
    {
        //���ׂď�����
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

