using UnityEngine;

public class TutorialSorryimage : MonoBehaviour
{
    public GameObject imageObject; // Image���A�^�b�`���ꂽGameObject
    public TutorialEnemyAttackManager enemyAttackManager;
    void Start()
    {
        // �ی��Ŏ����擾�iInspector�Ŋ��蓖�ĂĂ���Εs�v�j
        if (enemyAttackManager == null)
            enemyAttackManager = FindObjectOfType<TutorialEnemyAttackManager>();
    }
    private void Update()
    {
        if (enemyAttackManager.isSorry == true)
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
        if (imageObject != null)
            imageObject.SetActive(true);
    }

    public void OffToggle()
    {
        if (imageObject != null)
            imageObject.SetActive(false);
    }

}
