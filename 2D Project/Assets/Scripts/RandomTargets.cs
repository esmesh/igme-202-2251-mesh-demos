using UnityEngine;

public class RandomTargets : MonoBehaviour
{
    [SerializeField]
    int score;

    [SerializeField]
    TextMesh scoreLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
    }
}
