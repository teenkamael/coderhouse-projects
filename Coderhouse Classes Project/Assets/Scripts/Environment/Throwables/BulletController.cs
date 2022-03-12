using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IThrowable
{
    #region SerializedFields
    [SerializeField] float speed = 20f;
    [SerializeField] float timeToRemove = 50f;
    [SerializeField] public float damage = 25f;
    [SerializeField] private ProjectileType type;

    private float timer = 0f; 
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timeToRemove)
            timer += Time.deltaTime;
        else
        {
            timer = 0f;
            Destroy(gameObject);
        }
        Move(speed);
    }

    public void Move(float speed)
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);

    }

    public void OnCollisionEnter(Collision collision)
    { 
        Destroy(gameObject);
    }

    public ProjectileType GetProjectileType(){
        return type;
    }
}
