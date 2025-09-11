using UnityEngine;
using UnityEngine.InputSystem;

public class Week3Demo : MonoBehaviour
{

    [SerializeField]
    private GameObject goPrefab;

    [SerializeField]
    Vector3 mousePosition;

    [SerializeField]
    Vector3 spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        mousePosition = Mouse.current.position.ReadValue();
        spawnPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        spawnPoint.z = 0;
        GameObject newGO = Instantiate(goPrefab, spawnPoint, Quaternion.identity);
        newGO.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0, 1, 0, 1);
        */
    }

    public void OnSpawn(InputAction.CallbackContext context)
    {
        Debug.Log("Hi!! - " + context.phase);
        if (context.phase == InputActionPhase.Canceled)
        {
            Debug.Log("** GO **");
            mousePosition = Mouse.current.position.ReadValue();
            spawnPoint = Camera.main.ScreenToWorldPoint(mousePosition);
            spawnPoint.z = 0;
            GameObject newGO = Instantiate(goPrefab, spawnPoint, Quaternion.identity);
            newGO.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0, 1, 0, 1);
        }
    }

}
