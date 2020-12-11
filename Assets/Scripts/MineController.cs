using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    private List<GameObject> resourcesInRange  = new List<GameObject>();
    public GameObject resourcePrefab;
    private float resourceRange = 2f;
    private int maxResourcesInRange = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] resources = Physics.OverlapSphere(transform.position, resourceRange);
        if (resources.Length < maxResourcesInRange)
        {
            spawnResource();
        }
        
    }


    private void spawnResource()
    {
        float randomX = Random.Range(-resourceRange, resourceRange);
        float randomZ = Random.Range(-resourceRange, resourceRange);
        Vector3 randomPosition = transform.position + new Vector3(randomX, 0, randomZ);
        resourcesInRange.Add(Instantiate(resourcePrefab, randomPosition, Quaternion.identity));
    }
}
