using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{

    //Shooting Variables
    [SerializeField]
    float reloadTime = 0.5f;
    bool reloaded = true;


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
        Invoke("Reload",reloadTime);
        Debug.Log("shot");
    }

    void Reload() {
        reloaded = true;
    }

}
