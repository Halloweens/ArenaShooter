using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

    public GameObject bullet;
    public float bulletSpeed = 100f;
    public float bulletLifeTime = 2f;

    // Update is called once per frame
    void Update ()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            CreateBullet();
        }

    }

    void CreateBullet()
    {
        Vector3 dir = BulletDir();
        GameObject newBullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.forward, dir));
        newBullet.GetComponent<Rigidbody>().velocity = dir.normalized * bulletSpeed;
        Destroy(newBullet, bulletLifeTime);
    }

    Vector3 BulletDir()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray.origin, ray.direction, 100f))
            Debug.Log("Hit");

        RaycastHit[] hit = Physics.RaycastAll(ray, 100f);

        Vector3 target = hit[0].point - GameObject.FindGameObjectWithTag("BulletSpawner").transform.position;//(ray.direction + ray.origin) * 100;
        target.y = 0f;

        return target;
    }
}
