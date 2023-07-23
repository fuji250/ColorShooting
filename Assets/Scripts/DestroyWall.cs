using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll) {
        
        //画面外上に再配置
        coll.transform.position = new Vector3(-9f + 18 * Random.value, 6, 0);
    }
}
