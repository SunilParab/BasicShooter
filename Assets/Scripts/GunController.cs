using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{

    //Shooting Variables
    [SerializeField]
    float reloadTime = 0.5f;
    bool reloaded = true;
    [SerializeField]
    float bulletSpeed = 50;
    [SerializeField]
    GameObject bulletPrefab;

    //Input Systems
    InputAction attackAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (attackAction.triggered && reloaded) {
            Fire();
        }
    }


    void Fire() {
        GameObject bullet = Instantiate(bulletPrefab,transform.position,transform.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = bullet.transform.up*bulletSpeed;
        bullet.GetComponent<BulletController>().setup(10,true);

        reloaded = false;
        Invoke("Reload",reloadTime);
    }

    void Reload() {
        reloaded = true;
    }

}
