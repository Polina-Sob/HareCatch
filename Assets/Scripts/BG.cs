using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BG : MonoBehaviour
{
    public float speed;
    public GameObject teleportRoad;
    public float backLength;
    public int backsCount;
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < teleportRoad.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + backLength * backsCount, transform.position.y);
        }
    }
}
