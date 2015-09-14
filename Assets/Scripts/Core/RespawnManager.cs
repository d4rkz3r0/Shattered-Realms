using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour
{
    public bool isRespawning;

	void Start () 
    {
        isRespawning = false;

        //Diagnostic Information
        //Debug.Log("Respawnable Enemies: " + CountEnemies(transform));
	}
	
	void Update ()
    {
	    if(!isRespawning)
        {
            return;
        }
        else
        {
            RespawnEnemies(transform);
            isRespawning = false;
        }
	}

    int CountEnemies(Transform parent)
    {
        int enemyCount = 0;
        foreach (Transform child in parent)
        {
            enemyCount++;
        }
        return enemyCount;
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
}
