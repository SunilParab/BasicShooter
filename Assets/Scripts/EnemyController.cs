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

    void OnCollisionEnter(Collision collision) {
        GameObject other = collision.gameObject;
        if (other.tag.Equals("Bullet")) {
            
        }
    }

}
