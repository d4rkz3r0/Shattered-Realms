///***********************************************************************
//Class: DestroyParticle.cs
/*Notes:
 * The DestroyParticle class should be attached to any particle created by the
 * particle system to ensure deletion from the scene.
 */
///***********************************************************************
using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour
{
    //Private References
    private ParticleSystem partSys;


	void Start ()
    {
		partSys = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (partSys.isPlaying)
        {
            return;
        }

        Destroy(gameObject);
	}

    //Optimization
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
