using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ATKData", menuName = "ScriptableObjects/ATKDATA", order = 1)]
public class AttackData : ScriptableObject
{
    [Header("attack Info")]
    public float attackPower = 10;
    public float costMana = 1;
    public float attackCoolTime = 2f;
    public float meleeRadius = 1f;
    public float meleeRange = 1f;
    public GameObject impactVfx;

    public KeyCode abilityKey;
}
