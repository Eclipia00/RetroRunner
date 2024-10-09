using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject playerCharacter;
    [SerializeField] private bool isAttack;
    [SerializeField] private Stamina stamina;
    [SerializeField] private Animator animator;

    [Header("attack Info")] 
    [SerializeField] private AttackData attackData;
    [SerializeField] private AttackData skillData;
    
    [SerializeField] private LayerMask atkTarget;
    
    [FormerlySerializedAs("attackKey")]
    [Header("Keys")]
    [SerializeField] private KeyCode baseAttackKey = KeyCode.C;
    [SerializeField] private KeyCode skillAttackKey = KeyCode.A;

    private void Start()
    {
        stamina = GetComponent<Stamina>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        AttackHandler();
    }

    private void AttackHandler()
    {
        if (isAttack == false)
        {
            if (Input.GetKeyDown(baseAttackKey) && stamina.stamina.Value >= attackData.costMana)
            {
                isAttack = true;
                Debug.Log("attack");
                animator.CrossFade("Ani_Character_Skill", 0.2f);
                StartCoroutine("ATKBase",attackData);
                stamina.UseStamina(attackData.costMana);
                StartCoroutine(AttackCounter());

            }
            else if (Input.GetKeyDown(skillAttackKey) && stamina.stamina.Value >= skillData.costMana)
            {
                isAttack = true;
                Debug.Log("skill");
                animator.CrossFade("Ani_Character_Skill", 0.2f);
                StartCoroutine("ATKBase",skillData);
                stamina.UseStamina(skillData.costMana);
                StartCoroutine(AttackCounter());
            }
            
        }
    }
    
    IEnumerator AttackCounter()
    {
        yield return new WaitForSeconds(1);
        isAttack = false;
    }
    
    IEnumerator ATKBase(AttackData atkData)
    {
        yield return new WaitForSeconds(0.1f);
        VFX(1f, atkData.impactVfx);
        RaycastHit[] hits = Physics.SphereCastAll(transform.position,
            atkData.meleeRadius, playerCharacter.transform.right, atkData.meleeRange, atkTarget);
        foreach (var hit in hits)
        {
            Health health = hit.collider.GetComponent<Health>();
            if (health)
            {
                health.TakeDmg(atkData.attackPower);
            }
        }
        yield return new WaitForSeconds(1f);
    }
    
    void VFX(float impactVfxLifetime, GameObject vfx)
    {
        if (vfx != null)
        {
            GameObject impactVfxInstance = Instantiate(vfx, playerCharacter.transform.position + playerCharacter.transform.right, playerCharacter.transform.rotation);
            if (impactVfxLifetime > 0)
            {
                Destroy(impactVfxInstance, impactVfxLifetime);
            }
        }
    }
    
    
}
