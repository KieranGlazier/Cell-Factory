using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverController : MonoBehaviour
{
    public float speed = 5.0f;
    private GameObject currentTarget = null;
    private bool hasTarget = false;
    private bool carryingResource = false;
    private Vector3 carryingOffset = new Vector3(0, 2f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasTarget)
        {
            hasTarget = GetNewTarget("Resource");
        }

        if(hasTarget)
        {
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, speed * Time.deltaTime);
        }


    }

    

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Resource"))
        {
            // Pick up the resource
            Vector3 scaleChange = new Vector3(.5f, .5f, .5f);
            other.gameObject.transform.localScale -= scaleChange;
            other.transform.position = transform.position + carryingOffset;
            other.isTrigger = false;
            other.gameObject.transform.SetParent(transform);
            // Find a factory to take the resource
            hasTarget = GetNewTarget("Factory");
        }

        if (other.CompareTag("Factory"))
        {
            if (transform.childCount > 0)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
            hasTarget = false;
            currentTarget = null;
            //transform.DetachChildren();
            //GetNewTarget("Player Core");
        }
    }
    bool GetNewTarget(string targetTag)
    {
        GameObject[] targetList = GameObject.FindGameObjectsWithTag(targetTag);
        if (targetList.Length > 0)
        {
            int randomResourceListPosition = Random.Range(0, targetList.Length - 1);
            currentTarget = targetList[randomResourceListPosition];
            return true;
        } else
        {
            return false;
        }
    }
}
