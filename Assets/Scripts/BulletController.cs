using System.Runtime.ExceptionServices;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    float damage;
    bool friendly;

    void setup(float damage, bool friendly) {
        this.damage = damage;
        this.friendly = friendly;
    }

    bool getFriendly() {
        return friendly;
    }

    float hit() {
        return damage;
    }

}
