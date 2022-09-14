using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Food Prefab
    public GameObject foodPrefab;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x - 1, borderRight.position.x - 1);
        int y = (int)Random.Range(borderBottom.position.y - 1, borderTop.position.y - 1);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
