using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields

    [SerializeField] float healthPoints = 75f;
    
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        

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
