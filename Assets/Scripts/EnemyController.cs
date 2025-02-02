using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    float health = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision) {
        Debug.Log("hit");
        GameObject other = collision.gameObject;
        if (other.tag.Equals("Bullet")) {
            BulletController bullet = other.GetComponent<BulletController>();
            if (bullet.getFriendly()) {
                health -= bullet.hit();
                Debug.Log(health);
            }
        }
    }

}
