using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    //
    void OnDamage(int damage, Vector2 hitPoint, Vector2 hitNormal);
}
