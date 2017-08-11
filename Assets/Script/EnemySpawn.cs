using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
    [SerializeField]
    private int spawnLife = 1;
    [SerializeField]
    private float spawnSpeed = 6f;
    [SerializeField]
    private GameObject ennemy;

    // Use this for initialization
    void Start () {
        InvokeRepeating("EnnemySpawn", spawnSpeed, spawnSpeed);	
	}

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.ToString());
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.tag == "Bullet")
        {
            spawnLife--;
            if (spawnLife <= 0)
                Destroy(gameObject);
        }
    }

    void EnnemySpawn()
    {
        GameObject spawnedEnnemy = (GameObject)Instantiate(ennemy, transform.position, Quaternion.FromToRotation(Vector3.forward, Vector3.zero));
    }
}
