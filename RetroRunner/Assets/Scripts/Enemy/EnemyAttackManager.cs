using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    
    public float dmg;
    protected float _meleeRadius = 4f;
    protected float _meleeRange = 2f;
    
    

    private void MeleeAtk()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position,
            _meleeRadius, transform.forward, _meleeRange, LayerMask.GetMask("Player"));
        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                Health _health = hit.collider.GetComponent<Health>();
                if (_health)
                {
                    _health.TakeDmg(dmg);
                }
            }
        }
    }
}
