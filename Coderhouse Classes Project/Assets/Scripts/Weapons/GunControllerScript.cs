using UnityEngine;

public class GunControllerScript : MonoBehaviour, IShootableObject
{


    [SerializeField] BulletController bulletType;

    void Start()
    {

    }

    void Update()
    {
        CustomWeaponAction.Attack += Shoot;
    }

    public void Shoot(Vector3 direction)
    {
        bulletType.direction = direction;
        InstantiateBullet(bulletType);

    }

    private void InstantiateBullet(BulletController bullet)
    {
        Instantiate(bullet, this.transform, false);
    }
}
