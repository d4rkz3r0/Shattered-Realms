using UnityEngine;
using System.Collections;

public class HazardSpawner : MonoBehaviour
{
    public GameObject hazardToSpawn;
    public float acidTimer;
   
    public int fireTime;

    void Start()
    {
        acidTimer = 0;
        fireTime = 2 + Random.Range(0, 3);
    }

    void Update()
    {
        acidTimer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (acidTimer > fireTime)
        {
            acidTimer = 0;
            fireTime = 2 + Random.Range(0, 3);
            Instantiate(hazardToSpawn, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        }
    }
    
}
