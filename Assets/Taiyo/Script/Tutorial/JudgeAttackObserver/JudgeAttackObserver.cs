using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/********
 *  �^�b�N������̒ʒm�Ǘ��N���X(�\���I�ȋ^���I�u�U�[�o�[)
 *  
 *  atacckManager�Ŕ���Set
 *  TutorialManager�Ŕ�����g�p
 *  
 **/

public class JudgeAttackObserver : MonoBehaviour
{

    //�^�b�N�����Ă�����
    bool isOkAttack = false;

    //�^�b�N��������
    bool isAttack = false;

    //�^�b�N���ɐ���������
    bool isSuccess = false;

    //�y�����^�C�~���O
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

