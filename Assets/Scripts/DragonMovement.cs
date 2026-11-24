using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public Transform spawnArea;
    public float speed = 2f;

    private Vector3 targetPosition;

    void Start()
    {
        SetRandomTarget();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTarget();
        }
    }

    void SetRandomTarget()
    {
        Vector3 halfSize = spawnArea.lossyScale / 2f;

        Vector3 randomPosition = new Vector3(
            Random.Range(-halfSize.x, halfSize.x),
            1f,
            Random.Range(-halfSize.z, halfSize.z)
        );

        targetPosition = spawnArea.position + randomPosition;
    }
}