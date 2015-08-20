using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHPBar : MonoBehaviour {
	
	public int E_MaxHP;
	public int E_CurrentHP;
	public Vector3 E_healthBarInitial;

	private float E_healthStatusRatio;
	private Color E_currHPBarSpriteColor;
	private Color E_lowHPColor;
	private Color E_fullHPColor;
	private Image E_hpBarSprite;
	private Transform HealthBar;

	private SpriteRenderer hi;

	// Use this for initialization
	void Start () {
		E_healthBarInitial = gameObject.transform.position;
		E_MaxHP = GetComponentInParent <EnemyHealthManager> ().EnemyMaxHP;

		E_lowHPColor = Color.red;
		E_fullHPColor = Color.green; //Full Alpha
		E_hpBarSprite = GetComponent<Image>();

		HealthBar = transform.FindChild ("EnemyHealthBar");

	}
	
	// Update is called once per frame
	void Update () {

		if (transform.localScale.x < 0)
			transform.FindChild("EnemyHealthBar").localScale = new Vector3 (-1, 1, 1);
		else
			transform.FindChild("EnemyHealthBar").localScale = new Vector3 (1, 1, 1);

		E_CurrentHP = GetComponentInParent <EnemyHealthManager> ().enemyHP;

		Vector3 newEnemyHPBarPos = E_healthBarInitial;
		newEnemyHPBarPos.x = newEnemyHPBarPos.x - (0.5f - ((float)E_CurrentHP / (float)E_MaxHP) * 0.5f);
		gameObject.GetComponentsInChildren<SpriteRenderer> () [2].transform.localScale = newEnemyHPBarPos;

		Vector3 newEnemyHPBarScale = new Vector3 (25, 1, 1);
		newEnemyHPBarScale.x = 25.0f * ((float)E_CurrentHP / (float)E_MaxHP);
		gameObject.GetComponentsInChildren<SpriteRenderer> () [2].transform.localScale = newEnemyHPBarScale;

		// Set Health Bar Color
		Color theColor = gameObject.GetComponent<SpriteRenderer> ().color;

		theColor.r = 1.0f * (1.0f - ((float)E_CurrentHP / (float)E_MaxHP));
		theColor.g = 1.0f * (((float)E_CurrentHP / (float)E_MaxHP));
		theColor.b = 0.0f;

		hi = gameObject.GetComponentsInChildren<SpriteRenderer>()[2];
		hi.color = theColor;

		if (E_CurrentHP <= 0)
		{
			E_CurrentHP = 0;
		}
	}


}
