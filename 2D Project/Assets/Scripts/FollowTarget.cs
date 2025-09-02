using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("move!");
        this.gameObject.transform.position = new Vector3(
            target.transform.position.x, 
            target.transform.position.y,
            this.gameObject.transform.position.z);
    }
}
