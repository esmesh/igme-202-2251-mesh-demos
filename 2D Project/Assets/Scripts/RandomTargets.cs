using UnityEngine;

public class RandomTargets : MonoBehaviour
{
    [SerializeField]
    int score;

    [SerializeField]
    TextMesh scoreLabel;

    [SerializeField]
    GameObject tarPrefab;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    Vector3 targetCenter = Vector3.zero;

    [SerializeField]
    Vector3 targetBoundsSize = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 location = new Vector3(
            Random.Range(targetCenter.x - targetBoundsSize.x / 2, targetCenter.x + targetBoundsSize.x / 2),
            Random.Range(targetCenter.y - targetBoundsSize.y / 2, targetCenter.y + targetBoundsSize.y / 2),
            0
            );
        target = Instantiate(tarPrefab, location, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        Destroy(target);
        target = null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(targetCenter, targetBoundsSize);
    }

}
