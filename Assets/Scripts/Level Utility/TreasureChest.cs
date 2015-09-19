using UnityEngine;
using System.Collections;

public class TreasureChest : MonoBehaviour
{
    public GameObject itemToSpawn;
    public int chestHP;

    private AudioSource chestHitSFX;
    public AudioSource chestOpenSFX;
    private float chestAnimTimer;
    private float chestAnimDuration;
    private Animator anim;
    private bool audioOnce;
    private MasterController player;

	void Start () 
    {
        player = FindObjectOfType<MasterController>();
        audioOnce = false;
        chestAnimDuration = 1.33f;
        anim = GetComponent<Animator>();
        chestHitSFX = GetComponent<AudioSource>();
	}

	void Update () 
    {
        if (chestHP <= 0)
        {
            anim.enabled = true;
            if(!audioOnce)
            {
                chestAnimTimer = chestAnimDuration;
                chestOpenSFX.Play();
                anim.Play("TreasureChest_Open");
                audioOnce = true;
            }
        }

        if(chestAnimTimer >= 0.0f)
        {
            chestAnimTimer -= Time.deltaTime;
        }

        if(chestAnimTimer <= 0.0f && chestHP <= 0)
        {
            Destroy(gameObject);
        }

	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerAbility" || player.isBackFlipping || player.isSpinDashing || player.isSpringing || player.isGoingSuper)
        {
            chestHitSFX.Play();
            chestHP -= 1;
        }
    }

    public void DropLoot()
    {
        GameObject item1 = (GameObject)Instantiate(itemToSpawn, transform.position, Quaternion.identity);
        item1.GetComponent<Rigidbody2D>().velocity = new Vector2(-4.0f, 1.25f);

        GameObject item2 = (GameObject)Instantiate(itemToSpawn, transform.position, Quaternion.identity);
        item2.GetComponent<Rigidbody2D>().velocity = new Vector2(4.0f, 1.25f);

        GameObject item3 = (GameObject)Instantiate(itemToSpawn, transform.position, Quaternion.identity);
        item3.GetComponent<Rigidbody2D>().velocity = new Vector2(0.25f, 7.0f);
    }

    public void SpawnEnemies()
    {
        Vector3 enemy1Pos = transform.position;
        Vector3 enemy2Pos = transform.position;
        enemy1Pos += new Vector3(-3.0f, 0.0f, 0.0f);
        enemy1Pos += new Vector3(3.0f, 0.0f, 0.0f);

        GameObject enemy1 = (GameObject)Instantiate(itemToSpawn, enemy1Pos, Quaternion.identity);
        GameObject enemy2 = (GameObject)Instantiate(itemToSpawn, enemy2Pos, Quaternion.identity);
    }
}
