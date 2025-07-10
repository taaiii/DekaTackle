using UnityEngine;

public class TutorialMoveL : MonoBehaviour
{
    public float moveSpeed = 1f; // ïbä‘à⁄ìÆó 
    public const float DeletePos  = 0f;

    private float lifeTime = 10f;
    private float lifeCount = 0;

    bool isMove = true;
    bool isMiss = false;
    void Update()
    {

        if (isMove)
        {
            Vector3 move = Vector3.right * moveSpeed * Time.deltaTime;
            transform.position += move;
        }

        if (lifeCount > lifeTime)
        {
            Debug.Log("É~ÉX");
            isMiss = true;
            ResetLifeCount();
        }
    }

    public void SetMove(bool move)
    {
        isMove = move;
    }

    public void SetIsMiss(bool result)
    {
        isMiss = result;
    }
    
    public bool GetIsMiss()
    {
        return isMiss;
    }

    public void ResetLifeCount()
    {
        lifeCount = 0;
    }

    public void AddLifeCount()
    {
        lifeCount += Time.deltaTime;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
