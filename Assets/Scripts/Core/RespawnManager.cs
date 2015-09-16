using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour
{
    public bool isRespawning;
    private Transform GemContainer;

	void Start () 
    {
        isRespawning = false;
        GemContainer = GameObject.Find("HP Gems").GetComponent<Transform>();

        //Diagnostic Information
        Debug.Log("Respawnable Item Count: " + CountRespawnableObjects(GemContainer));
	}
	
	void Update ()
    {
	    if(!isRespawning)
        {
            return;
        }
        else
        {
            RespawnHPItems(GemContainer);
            RespawnEnemies(transform);
            isRespawning = false;
        }
	}

    int CountRespawnableObjects(Transform parent)
    {
        int itemCount = 0;
        foreach (Transform child in parent)
        {
            itemCount++;
        }
        return itemCount;
    }

    void RespawnEnemies(Transform parent)
    {
        foreach(Transform child in parent)
        {
            if (child.gameObject.activeInHierarchy == false)
            {
                child.gameObject.GetComponent<EnemyRespawn>().ResetSelf();
            }
            else
            {
                continue;
            }
            
        }
        isRespawning = false;
    }

    void RespawnHPItems(Transform parent)
    {
        Transform stripTransform;

        foreach (Transform child in parent)
        {
            if(child.gameObject.name == "hpGemStrip")
            {
                stripTransform = child.gameObject.transform;
                foreach(Transform child1 in stripTransform)
                {
                    if (child1.gameObject.activeInHierarchy == false)
                    {
                        child1.gameObject.GetComponent<RespawnableItem>().ResetSelf();
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            if (child.gameObject.activeInHierarchy == false)
            {
                child.gameObject.GetComponent<RespawnableItem>().ResetSelf();
            }
            else
            {
                continue;
            }
        }
    }
}
