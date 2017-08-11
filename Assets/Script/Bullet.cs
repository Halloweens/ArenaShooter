using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    GameObject player = null;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Player")
            Destroyer();
    }

    public void Destroyer()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > 70f)
            Destroyer();
    }
}
