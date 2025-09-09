using UnityEngine;
using UnityEngine.InputSystem;

public class Week3Demo : MonoBehaviour
{

    [SerializeField]
    private GameObject ballPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Hi!! - " + context.phase);
        if (context.phase == InputActionPhase.Canceled)
        {
            Debug.Log("** GO **");
            Vector2 newLoc = transform.position;
            GameObject ball = Instantiate(ballPrefab, newLoc, Quaternion.identity);
            ball.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0, 1, 0, 1);
        }
    }

}
