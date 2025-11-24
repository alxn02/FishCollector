using System.Collections.Generic;
using UnityEngine;

public class FishCollector : MonoBehaviour
{
    public GameObject fishPrefab;               // Assign your Fish prefab here
    public List<GameObject> fishList = new List<GameObject>();

    void Update()
    {
        // Right click to spawn a fish
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -Camera.main.transform.position.z; // distance from camera
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            // Instantiate a new fish at the clicked position
            GameObject fish = Instantiate(fishPrefab, worldPos, Quaternion.identity);

            // Make sure it has the correct tag
            fish.tag = "Collectible";

            // Add to list
            fishList.Add(fish);
        }
    }
}
