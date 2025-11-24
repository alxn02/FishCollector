using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    [HideInInspector] public bool isActive = false;

    private Rigidbody2D rb;
    private FishCollector fishCollector;
    private GameObject targetFish;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        fishCollector = Camera.main.GetComponent<FishCollector>();
        if (fishCollector == null)
            Debug.LogError("FishCollector missing on Main Camera!");
    }

    private void Update()
    {
        if (!isActive) return;

        // Remove destroyed/null fish
        fishCollector.fishList.RemoveAll(f => f == null);

        if (fishCollector.fishList.Count == 0)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        // Target the first fish in the list
        targetFish = fishCollector.fishList[0];
        Vector2 direction = (targetFish.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    private void OnMouseDown()
    {
        // Left click activates the ship
        isActive = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            Debug.Log("Collided with fish: " + other.name); // ? prints to console
            fishCollector.fishList.Remove(other.gameObject);
            Destroy(other.gameObject);
            rb.linearVelocity = Vector2.zero;
        }
    }
}
