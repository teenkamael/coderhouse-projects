using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields

    [SerializeField] float healthPoints = 75f;

    [SerializeField] GunControllerScript gun;
    [SerializeField] ThirdPersonMovement movement;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){ 
            CustomWeaponAction.Attack(movement.moveDirection);
        }
    }

    public void GetDamage(float damage)
    {
        healthPoints -= damage;
    }

    public void Cure(float value)
    {
        healthPoints += value;
    }

    
}
