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
        //Debug.Log("Respawnable Item Count: " + CountRespawnableObjects(GemContainer));
	}
	
	void Update ()
    {
	    if(!isRespawning)
        {
            return;
        }
        else
        {
            
            if(Application.loadedLevel == 9)
            {
                RespawnHPItems(GemContainer);
                isRespawning = false;
            }
            else
            {
                RespawnHPItems(GemContainer);
                RespawnEnemies(transform);
                isRespawning = false;
            }
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

		foreach (Transform child in parent)
		{
			if (child.gameObject.activeInHierarchy == false){
				Debug.Log ("FIRST");
				child.gameObject.GetComponent<EnemyRespawn>().ResetSelf();
				Debug.Log(child.gameObject.name);
			}
			else{
				Debug.Log("gotta go deeper");
				foreach (Transform childNext in child)
				{
					if (childNext.gameObject.activeInHierarchy == false){
						Debug.Log ("SECOND");
						childNext.gameObject.GetComponent<EnemyRespawn>().ResetSelf();
					}
					else{
						Debug.Log ("ive tried so hard and got so far");
						continue;
					}
				}
			}
		}

  
        isRespawning = false;
    }

    void RespawnHPItems(Transform parent)
    {
        Transform stripTransform;

        foreach (Transform child in parent)
        {

            stripTransform = child.gameObject.transform;
            foreach (Transform child1 in stripTransform)
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
