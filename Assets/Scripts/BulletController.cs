using System.Runtime.ExceptionServices;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    float damage;
    bool friendly;

    public void setup(float damage, bool friendly) {
        this.damage = damage;
        this.friendly = friendly;
    }

    public bool getFriendly() {
        return friendly;
    }

    public float hit() {
        return damage;
    }

}
