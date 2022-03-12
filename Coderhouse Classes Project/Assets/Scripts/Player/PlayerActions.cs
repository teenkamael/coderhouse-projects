using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Transform originShootpoint;

    private bool IsBlocking = false;
    private bool canCast = false;

    private List<GameObject> bulletsObtained = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shieldBlock();
        basicReflection();
    }

    private void shieldBlock()
    {
        if (Input.GetMouseButton(1))
        {
            IsBlocking = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            IsBlocking = false;
        }
        playerAnimator.SetBool("IsBlocking", IsBlocking);
    }

    private void basicReflection()
    {
        if (IsBlocking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (PlayerManager.GetChargesCount() == 3)
                {
                    canCast = true;
                    Debug.Log("Carga utilizada, se limpian las cargas");
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                canCast = false;
            }
            playerAnimator.SetBool("isCasting", canCast);
            if (canCast)
                reflectLastProjectile();
        }
    }

    private void reflectLastProjectile()
    {
        if (PlayerManager.GetChargesCount() == 3)
        {
            Instantiate(PlayerManager.GetLastProjectile().projectileGameObject, originShootpoint.position, originShootpoint.rotation, gameObject.transform);
            PlayerManager.ResetCharges();
        }
    }

    public void shieldDefense(GameObject collisionedObject)
    {
        if (IsBlocking)
        {
            PlayerManager.StoreProjectile(collisionedObject.GetComponent<BulletController>().GetProjectileType());
            Debug.Log($"Tienes {PlayerManager.GetChargesCount()} cargas");
            if (PlayerManager.GetChargesCount() == 3)
                Debug.Log("Deberías poder devolver la última carga");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(CollisionTags.Bullet.ToString()))
        {
            GameObject bullet = collision.gameObject;
            PlayerManager.TakeDamage(bullet.GetComponent<BulletController>().damage);
        }
    }


}
