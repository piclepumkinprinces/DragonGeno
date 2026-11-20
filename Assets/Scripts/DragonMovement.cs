using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public float speed;
    public float flightSpeed;
    public float runSpeed;

    [Space]

    public int health;
    public float detectionRange;

    [Space]

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
