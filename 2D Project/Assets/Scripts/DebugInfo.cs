using UnityEngine;

public class DebugInfo : MonoBehaviour
{
    [SerializeField]
    private int num = 42;

    private int secret = 121;

    // Start is called once before the first execution of
    // Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HELLO! "+num);

        if(num > 100)
        {
            Debug.Log("stop");
        }
    }
}
