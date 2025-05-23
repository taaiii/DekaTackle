using UnityEngine;

public class EnemycheckL : MonoBehaviour
{
    private GameObject player;
    public float inputRange = 1f;
    public int eventNumber = 2;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            Debug.LogWarning("Playerタグのオブジェクトが見つかりません。");
        }
    }

    void Update()
    {

        if (transform.position.x >= 1f)
        {
            Destroy(gameObject);
        }
        if (player == null) return;

        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("距離 : " + distance + " 範囲 : " + inputRange);

            if (distance <= inputRange)
            {
                if (direction.x > 0) // プレイヤーが左にいるときだけ成功
                {
                    PointCounter.Point++;
                    Destroy(gameObject);
                    Debug.Log("成功");
                }
            }
            else
            {
                if (Random.Range(0, eventNumber) == 0)
                {
                    Debug.Log("誰もいなかった");
                }
                else
                {
                    Debug.Log("一般人にぶつかった");
                }
            }
        }
    }
}
