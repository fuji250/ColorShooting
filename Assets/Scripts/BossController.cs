using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class BossController : MonoBehaviour
{
    public GameObject explosionPrefab;   //爆発エフェクトのPrefab
    public int maxHp = default;
    int hp = default;
    
    public Slider hpSlider;
    
    [SerializeField] private Vector3 _LeftEdge = new Vector3(-6,4,0);
    [SerializeField] private Vector3 _RightEdge = new Vector3(6,4,0);
    public float MoveSpeed = 3.0f;
    public int direction = 1;

    void Start()
    {
        hp = maxHp;
        hpSlider.maxValue = maxHp;
        hpSlider.value = hp;
        
        //this.transform.DOMove(new Vector3(-6,4,0), 0.5f).SetLoops(-1,LoopType.Yoyo);
    }
    
    void FixedUpdate()
    {
        if (transform.position.x >= _RightEdge.x)
            direction = -1;
        if (transform.position.x <= _LeftEdge.x)
            direction = 1;
        transform.position = new Vector3(transform.position.x + MoveSpeed * Time.fixedDeltaTime * direction, 4, 0);
    }
    
    public void UpdateHP(int hp)
    {
        hpSlider.value = hp;
    }
    
    
    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Instantiate (explosionPrefab, coll.gameObject.transform.position, Quaternion.identity);
        Destroy(coll.gameObject);
        hp -= 10;
        UpdateHP(hp);
        AudioManager.instance.PlaySE(AudioManager.SE.ShotHit);
        if (hp <= 0)
        {
            hp = 0;
            
            AudioManager.instance.PlaySE(AudioManager.SE.KillBoss);

            Destroy(gameObject);
        }
    }
}
