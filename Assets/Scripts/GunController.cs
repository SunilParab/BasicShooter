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

    //Gun Variables
    enum GunType {Pistol,Cannon,Sniper}
    [SerializeField]
    GunType curGun = GunType.Pistol;

    //Pistol Variables
    float pistolBulletSpeed = 40;
    float pistolBulletDamange = 10;
    float pistolBulletLifeSpan = 4;
    float pistolBulletSize = 1;

    //Cannon Variables
    float cannonBulletSpeed = 10;
    float cannonBulletDamange = 20;
    float cannonBulletLifeSpan = 10;
    float cannonBulletSize = 5;

    //Sniper Variables
    float sniperBulletSpeed = 100;
    float sniperBulletDamange = 40;
    float sniperBulletLifeSpan = 3;
    float sniperBulletSize = 2;


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
        switch (curGun) {
            case GunType.Pistol:
                PistolBullet(bullet);
                break;
            case GunType.Cannon:
                CannonBullet(bullet);
                break;
            case GunType.Sniper:
                SniperBullet(bullet);
                break;
        }

        reloaded = false;
        Invoke("Reload",reloadTime);
    }

    void Reload() {
        reloaded = true;
    }

    void PistolBullet(GameObject bullet) {
        bullet.GetComponent<Rigidbody>().linearVelocity = bullet.transform.up*pistolBulletSpeed;
        bullet.GetComponent<BulletController>().setup(pistolBulletDamange,true,pistolBulletLifeSpan);
        bullet.transform.localScale *= pistolBulletSize;
    }

    void CannonBullet(GameObject bullet) {
        bullet.GetComponent<Rigidbody>().linearVelocity = bullet.transform.up*cannonBulletSpeed;
        bullet.GetComponent<BulletController>().setup(cannonBulletDamange,true,cannonBulletLifeSpan);
        bullet.transform.localScale *= cannonBulletSize;
    }

    void SniperBullet(GameObject bullet) {
        bullet.GetComponent<Rigidbody>().linearVelocity = bullet.transform.up*sniperBulletSpeed;
        bullet.GetComponent<BulletController>().setup(sniperBulletDamange,true,sniperBulletLifeSpan);
        bullet.transform.localScale *= sniperBulletSize;
    }

}
