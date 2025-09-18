using UnityEngine;

public class Week4Demo : MonoBehaviour
{
    [SerializeField]
    GameObject frameObj;

    [SerializeField]
    GameObject deltaObj;

    [SerializeField, Range(10, 150)]
    int targetFrameRate = 60;

    // to visualize movement per second
    [SerializeField]
    GameObject frameStep;

    [SerializeField]
    GameObject deltaStep;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = targetFrameRate;

        // frameObj.transform.position.x += 0.01f;
        Vector2 posTmp = frameObj.transform.position;
        posTmp.x += 0.6f / 60; //  0.01f;
        frameObj.transform.position = posTmp;

        posTmp = deltaObj.transform.position;
        posTmp.x += 0.6f * Time.deltaTime;
        deltaObj.transform.position = posTmp;

        // width == distance we are traveling per second at current frame rate
        Vector2 scale = new Vector2(0.01f * targetFrameRate, 0.3f);
        frameStep.transform.localScale = scale;

        scale.x = 0.6f * 1.0f;
        deltaStep.transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        //Gizmos.DrawWireCube(new Vector3(1, 0, 0), new Vector3(1, 1, 1));
        Gizmos.DrawLine(frameObj.transform.position, new Vector2(
            frameObj.transform.position.x + 0.01f * targetFrameRate,
            frameObj.transform.position.y));

        Gizmos.DrawLine(deltaObj.transform.position, new Vector2(
            deltaObj.transform.position.x + 0.6f,
            deltaObj.transform.position.y));
    }
}