using UnityEngine;
using UnityEngine.UI;

public class ButtonTestSCript : MonoBehaviour
{
    public Button test;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        test.onClick.AddListener(() => print("test"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
