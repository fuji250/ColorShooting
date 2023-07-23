using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCollider : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<RockController>() == null)
        {
            return;
        }
        if (coll.gameObject.GetComponent<RockController>().isInside == true)
        {
            if (coll.gameObject.GetComponent<RockController>().enemyColor == RocketController.playerCurrentColor) 
            {
                //画面外上に再配置
                coll.transform.position = new Vector3(-9f + 18 * Random.value, 6, 0);

                CircleBulletController.CountDefeatEnemy();
                
                AudioManager.instance.PlaySE(AudioManager.SE.KillEnemy);

                // 衝突したときにスコアを更新する
                GameObject.Find ("Canvas").GetComponent<UIController>().AddScore();
            }
            
        }
    }
}
