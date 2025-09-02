using UnityEngine;

public class DebugInfo : MonoBehaviour
{
    [SerializeField]
    private int num = 42;

    // Start is called once before the first execution of
    // Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HELLO! "+num);
    }
}
