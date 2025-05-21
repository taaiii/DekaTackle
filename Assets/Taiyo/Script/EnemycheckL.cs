using UnityEngine;

public class EnemycheckL : MonoBehaviour
{
    private GameObject player;
    public float inputRange = 10f;

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

    if (distance <= inputRange)
    {
        if (direction.x > 0)
            if (Input.GetKeyDown(KeyCode.A))
            {
                PointCounter.Point++;
                Destroy(gameObject);
            }
        }
    }
}
