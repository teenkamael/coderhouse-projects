public enum PlayerState{
    IsGrounded,
    IsRunning,
    
}
public enum AttackType{
    MeleeAttack,
    TurretAttack,
    RangedAttack,
}

public  enum CollisionTags {
    Player,
    Ground,
    Enemy,
    Door,
    Portal,
    Bullet
}

public enum ProjectileType {
    Type1 = 1,
    Type2,
    Type3
}