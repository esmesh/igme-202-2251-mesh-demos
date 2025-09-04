using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject ballPrefab;

    private GameObject currentBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBall == null)
        {
            currentBall = Instantiate(
                ballPrefab, 
                transform.position, 
                Quaternion.identity);
        }
    }
}
