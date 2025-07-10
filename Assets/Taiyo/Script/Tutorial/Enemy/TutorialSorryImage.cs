using UnityEngine;

public class TutorialSorryimage : MonoBehaviour
{
    public GameObject imageObject; // ImageがアタッチされたGameObject
    public TutorialEnemyAttackManager enemyAttackManager;
    void Start()
    {
        // 保険で自動取得（Inspectorで割り当ててあれば不要）
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
