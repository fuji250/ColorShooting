using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {

    float fallSpeed;
    public float fallSpeed0;
    float rotSpeed;
    public float rotSpeed0;
    
    public bool isInside;

    public RocketController.PlayerColor enemyColor;

    void Start () {
        this.fallSpeed = 0.05f + fallSpeed0 * Random.value;
        this.rotSpeed = 0.5f + rotSpeed0 * Random.value;
    }
	
    void FixedUpdate () {
        transform.Translate( 0, -fallSpeed, 0, Space.World);
        transform.Rotate(0, 0, rotSpeed );
    }
    
    
    
    
}