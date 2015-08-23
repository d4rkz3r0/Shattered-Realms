///***********************************************************************
//Class: DarkStormController.cs
/*Notes:
 * The DarkStormController class handles Itachi's DarkStorm ability.
 * abilitySpeed - x movement speed
 * enemyDeathParticle - the particle that plays when impacting an enemy.
 * standardImpactParticle - the particle that plays when this ability impacts
 * a non-enemy (Ex: Obstacle)
 * Start() - binds appropriate references, and sets the sprite's x localScale
 * depending on the players facing position.
 * Update() - abilitySpeed update per frame.
 * OnTrigger2D() - plays appropriate particle for collision and cleans up the
 * ability
 * 
 */
///***********************************************************************
using UnityEngine;
using System.Collections;

public class DarkStormController : MonoBehaviour
{
    //Private References
    private Rigidbody2D rb2D;
    private MasterController player;

    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<MasterController>();


        if (player.transform.localScale.x < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        if (player.transform.localScale.x > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    void Update()
    {
        transform.position = player.darkStormPoint.position;
    }

    //Stay On Platforms
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Platform"  || other.tag == "Ground" || other.tag == "LethalHazard")
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0.0f);
            rb2D.gravityScale = 0.0f;
        }
    }

    //Damage
    void OnTriggerStay2D(Collider2D other)
    {

    }
}
