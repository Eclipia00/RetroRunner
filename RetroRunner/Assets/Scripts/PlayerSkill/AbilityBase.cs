using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbilityBase : MonoBehaviour
{
    public class MyFloatEvent : UnityEvent<float> { }
    public MyFloatEvent OnAbilityUse = new MyFloatEvent();

    [Header("Ability Info")]
    public string title;
    public Sprite icon;
    public float cooldownTime = 1;
    private bool canUse = true;
    [Range(10f, 30f)]
    [SerializeField] protected float Mana = 10f;
    [SerializeField] private Stamina stamina;
    [SerializeField] private KeyCode SkillKey = KeyCode.C;
    private void Awake()
    {
        stamina = GetComponent<Stamina>();
    }

    private void Update()
    {
        if (Input.GetKey(SkillKey) && stamina.stamina.Value > Mana)
        {
            TriggerAbility();
        }
    }
    public void TriggerAbility()
    {
        if (canUse && stamina.stamina.Value >= Mana)
        {
            OnAbilityUse.Invoke(cooldownTime);
            stamina.UseStamina(Mana);
            Ability();
            StartCooldown();
        }

    }
    public abstract void Ability();
    void StartCooldown()
    {
        StartCoroutine(Cooldown());
        IEnumerator Cooldown()
        {
            canUse = false;
            yield return new WaitForSeconds(cooldownTime);
            canUse = true;
        }
    }
}
