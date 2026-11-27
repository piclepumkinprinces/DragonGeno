using UnityEngine;

public class dragonIndex : MonoBehaviour
{
    public bool dragon1;
    public bool dragon2;
    public bool dragon3;
    public bool dragon4;
    public bool dragon5;

    public GameObject[] dragons;
    private Renderer objRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
