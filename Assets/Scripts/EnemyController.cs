using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
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
        GameObject other = collision.gameObject;
        if (other.tag.Equals("Bullet")) {
            BulletController bullet = other.GetComponent<BulletController>();
            if (bullet.getFriendly()) {
                takeDamage(bullet.hit());
            }
        }
    }

    void takeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            die();
        }
    }

    void die() {
        Destroy(gameObject);
    }

}
