using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class RocketController : MonoBehaviour {
	
	public GameObject bulletPrefab;
	private Rigidbody2D rb;
	public float speed = default;

	private SpriteRenderer signColor;

	public PlayerColor playerColor;
	public static PlayerColor playerCurrentColor;
	
	public GameObject explosionPrefab;   //爆発エフェクトのPrefab

	private GameObject circleBullet;

	public UIController gameOver;

	private bool isAttacking = false;
	
	 public enum PlayerColor
	{
		Red,
		Yellow,
		Blue
	}
	
	void Start()
	{
		// Rigidbody2D コンポーネントを取得して変数 rb に格納
		rb = GetComponent<Rigidbody2D>();
		
		signColor = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
		
		ChangeColor();
	}
	
	void Update () {
		// 右・左のデジタル入力値を x に渡す
		float x = Input.GetAxisRaw("Horizontal");
		// 上・下のデジタル入力値 y に渡す
		float y = Input.GetAxisRaw("Vertical");
		// 移動する向きを求める
		// x と y の入力値を正規化して direction に渡す
		Vector2 direction = new Vector2(x, y).normalized;
		
		// 移動する向きとスピードを代入する
		// Rigidbody2D コンポーネントの velocity に方向と移動速度を掛けた値を渡す
		rb.velocity = direction * speed;
		
		
		if (Input.GetKeyDown (KeyCode.Space)) {

			//二重攻撃出来ないように
			if (isAttacking)
			{
				return;
			}
			//ここ生成せずに一つを使いまわしの方がいい
			circleBullet = Instantiate (bulletPrefab, transform.position, Quaternion.identity);

			circleBullet.transform.parent = this.transform;
			circleBullet.GetComponent<SpriteRenderer>().color = this.gameObject.transform.GetChild(0).gameObject
				.GetComponent<SpriteRenderer>().color;
			
			isAttacking = true;
			Invoke("ChangeColor",1f);
			Invoke("ChangeAttackFlag",1f);
		}
	}

	public void ChangeColor()
	{
		if (playerCurrentColor == PlayerColor.Red)
		{
			playerCurrentColor = PlayerColor.Yellow;
			//黄色
			signColor.color = new Color32(200, 165, 0, 255);
			
		}
		else if (playerCurrentColor == PlayerColor.Yellow)
		{
			playerCurrentColor = PlayerColor.Blue;
			//青
			signColor.color = new Color32(0, 98, 133, 255);
		}
		else if (playerCurrentColor == PlayerColor.Blue)
		{
			playerCurrentColor = PlayerColor.Red;
			//青
			signColor.color = new Color32(217, 60, 15, 255);
		}
	}

	void ChangeAttackFlag()
	{
		isAttacking = false;
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		// 爆発エフェクトを生成する	
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		gameOver.GetComponent<UIController>().GameOver();
		
		AudioManager.instance.PlaySE(AudioManager.SE.Death);
		Destroy(gameObject);
	}
}