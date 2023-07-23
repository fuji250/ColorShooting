using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class CircleBulletController : MonoBehaviour
{
    public float speed = default;
    

    private bool isInsideEnemy;

    public GameObject bullet;

    private static int defeatEnemy = 0;

    void Start()
    {
        this.transform.DOScale(new Vector2(10,10), 0.5f).SetLoops(2,LoopType.Yoyo);
        
        //2秒後にオブジェクトを消す
        Invoke("Destroy", 1);
    }

    public static void CountDefeatEnemy()
    {
        defeatEnemy++;
        Debug.Log(defeatEnemy);
    }

    private IEnumerator  Attack()
    {
        //何故かめっちゃ出る
        for (int i = 0; i < defeatEnemy; i++)
        {
            Instantiate (bullet, gameObject.transform.position, Quaternion.identity);
            AudioManager.instance.PlaySE(AudioManager.SE.Shot);
            yield return new WaitForSeconds(0.1f);
        }

        //次の攻撃とまじって変な感じなりそう
        defeatEnemy = 0;
        Destroy(gameObject);
    }

    //Invokeで使う
    void Destroy()
    {
        StartCoroutine(Attack());
        
    }
    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<RockController>() != null)
        {
            if (coll.gameObject.GetComponent<RockController>().enemyColor == RocketController.playerCurrentColor)
            {
                coll.gameObject.GetComponent<RockController>().isInside = true;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<RockController>() != null)
        {
            if (coll.gameObject.GetComponent<RockController>().enemyColor == RocketController.playerCurrentColor)
            {
                coll.gameObject.GetComponent<RockController>().isInside = false;
            }
        }
    }
}