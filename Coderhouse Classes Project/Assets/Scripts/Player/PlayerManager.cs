using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public bool dontDestroyOnLoad;

    [SerializeField] private List<Projectile> reflectableProjectiles;
    private static List<Projectile> _reflectableProjectiles;
    private static List<Projectile> storedProjectiles = new List<Projectile>();
    private static float healthPoints = 75f;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            _reflectableProjectiles = reflectableProjectiles;
            instance = this;
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void TakeDamage(float damage)
    {
        healthPoints -= damage;
        Debug.Log("Tu vida es de: " + healthPoints);
    }

    public static void StoreProjectile(ProjectileType type)
    {
        storedProjectiles.Add(_reflectableProjectiles.Single(x => x.type == type));
        if (storedProjectiles.Count > 3)
            storedProjectiles.RemoveAt(0);
    }

    public static int GetChargesCount()
    {
        return storedProjectiles.Count;
    }

    public static Projectile GetLastProjectile()
    {
        return storedProjectiles.Last();
    }

    public static void ResetCharges()
    {
        storedProjectiles.Clear();
    }
}
