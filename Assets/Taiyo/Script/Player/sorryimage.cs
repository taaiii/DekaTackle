using UnityEngine;

public class sorryimage : MonoBehaviour
{
    public GameObject imageObject; // Image���A�^�b�`���ꂽGameObject
    public EnemyAttackManager enemyAttackManager;
    void Start()
    {
        // �ی��Ŏ����擾�iInspector�Ŋ��蓖�ĂĂ���Εs�v�j
        if (enemyAttackManager == null)
            enemyAttackManager = FindObjectOfType<EnemyAttackManager>();
    }
    private void Update()
    {
        if(enemyAttackManager.isSorry == true)
        {
            OnToggle();
        }
        else
        {
            OffToggle();
        }
    }
    public void OnToggle()
    {
        Debug.Log("Image ON");
        if (imageObject != null)
            imageObject.SetActive(true);
    }

    public void OffToggle()
    {
        Debug.Log("Image OFF");
        if (imageObject != null)
            imageObject.SetActive(false);
    }

}
