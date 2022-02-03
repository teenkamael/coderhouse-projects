using UnityEngine;

public class GunControllerScript : MonoBehaviour, IShootableObject
{


    [SerializeField] BulletController bulletType;
    [SerializeField] GameObject pointOnShoot;
    

    void Start()
    {
        CustomWeaponAction.Attack += Shoot;

    }

    void Update()
    {
    }

    public void Shoot(Vector3 direction)
    {
        bulletType.direction = direction;
        InstantiateBullet(bulletType);

    }

    private void InstantiateBullet(BulletController bullet)
    {
        Instantiate(bullet, pointOnShoot.transform.position, Quaternion.identity);
    }
}
