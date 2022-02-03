using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields

    [SerializeField] float healthPoints = 75f;

    [SerializeField] GunControllerScript gun;
    [SerializeField] ThirdPersonMovement movement;
    [SerializeField] float coolDown = 2f;
    private bool canShoot = true;
    private float timer = 0f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CustomWeaponAction.Attack(movement.moveDirection);
        }
        if (Input.GetMouseButtonDown(1) && canShoot)
        {
            for (int i = 0; i < 8; i++)
            {
                Vector3 direction = new Vector3(movement.moveDirection.x * (i - 30f * Time.deltaTime) * 10f, movement.moveDirection.y, movement.moveDirection.z).normalized;
                CustomWeaponAction.Attack(direction);

            }
        }
        if (!canShoot)
            timer += Time.deltaTime;
        if(timer > coolDown)
        {
            timer = 0f;
            canShoot = true;
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
