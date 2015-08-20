using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyRemainingController : MonoBehaviour 
{
    private GameObject[] levelEnemies;
    private int enemiesRemaining;
    private Text enemiesRemainingText;



	// Use this for initialization
	void Start ()
    {
        levelEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesRemainingText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        levelEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesRemaining = levelEnemies.Length;
        enemiesRemainingText.text = "x " + enemiesRemaining.ToString();
	}
}
