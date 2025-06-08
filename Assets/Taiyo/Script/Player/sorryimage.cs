using UnityEngine;

public class sorryimage : MonoBehaviour
{
    public GameObject imageObject; // ImageがアタッチされたGameObject
    public EnemyAttackManager enemyAttackManager;
    void Start()
    {
        // 保険で自動取得（Inspectorで割り当ててあれば不要）
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
