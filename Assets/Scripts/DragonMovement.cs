using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public Transform spawnArea;
    public float speed = 2;
    public float playerDetectionRange;

    public Vector3 targetPosition;

    public bool isGrounded;
    public bool isFlying;
    public bool isSprinting;

    public Camera player;

    void Start()
    {
        SetRandomTarget();

        player = Camera.main;
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

        if (Vector3.Distance(targetPosition, player.transform.position) < playerDetectionRange)
        {
            isSprinting = true;
            speed = 1;
        }
        else
        {
            isSprinting = false;
            speed = 0.5f;
        }
    }

    void SetRandomTarget()
    {
        Vector3 halfSize = spawnArea.lossyScale / 2f;

        Vector3 randomPosition = new Vector3(
            Random.Range(-halfSize.x, halfSize.x),
            spawnArea.transform.position.y + 1.125f,
            Random.Range(-halfSize.z, halfSize.z)
        );

        targetPosition = spawnArea.position + randomPosition;
    }
}