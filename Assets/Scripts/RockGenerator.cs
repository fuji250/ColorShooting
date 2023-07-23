using UnityEngine;
using System.Collections;

public class RockGenerator : MonoBehaviour {

    public GameObject redEnemy;
    public GameObject yellowEnemy;
    public GameObject blueEnemy;

    void Start () {
        InvokeRepeating ("GenRock", 1, 0.08f);
        Invoke(nameof(StopRepeat),6f);
    }
	
    void GenRock () {
        int rnd = Random.Range(0, 3);
        if (rnd == 0)
        {
            GameObject enemy = Instantiate (redEnemy, new Vector3 (-9f + 18 * Random.value, 6, 0), Quaternion.identity);
        }
        else if (rnd == 1)
        {
            GameObject enemy = Instantiate (yellowEnemy, new Vector3 (-9f + 18 * Random.value, 6, 0), Quaternion.identity);

        }
        else if (rnd == 2)
        {
            GameObject enemy = Instantiate (blueEnemy, new Vector3 (-9f + 18 * Random.value, 6, 0), Quaternion.identity);
        }
    }

    void StopRepeat()
    {
        CancelInvoke(nameof(GenRock));
    }
}
