using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngineInternal;

public class Health : MonoBehaviour
{

    [SerializeField] private Animator animator;
    public Gauge<float> health;
    public float maxHealth = 100f;
    [SerializeField, Range(0f,10f)] float recover = 0.01f;
    private SpriteRenderer[] meshs;


    public bool isDead = false;
    public bool isDmg = false;
    private void Awake()
    {
        meshs = GetComponentsInChildren<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        health = new Gauge<float>(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RecoverHealth(recover);
    }

    public void RecoverHealth(float value)
    {
        if (isDead) return;
        if (health.Value < health.MaxValue)
        {
            health.Value += value;
        }
    }

    public void TakeDmg(float dmg)
    {
        if (isDead) {
            return;
        }
        
        if(isDmg == false)
        {
            StartCoroutine("OnDmg",dmg);
        }
    }
            

    IEnumerator OnDmg(float dmg)
    {
        isDmg = true;
        health.Value -= dmg;

        if (animator)
        {
            if (this.gameObject.CompareTag("Player"))
            {
                animator.CrossFade("Ani_Character_Hit", 0.2f);
            }
            else if (this.gameObject.CompareTag("Player"))
            {
                animator.CrossFade("Ani_Enemy_Hit", 0.2f);
            }
        }
        foreach (SpriteRenderer mesh in meshs)
            mesh.material.color = Color.red;

        if (health.Value <= 0) { 
            isDead = true; 
        }

        yield return new WaitForSeconds(0.2f);
        isDmg = false;

        if(isDead == false)
        {
            foreach (SpriteRenderer mesh in meshs)
                mesh.material.color = Color.white;
        }
        else
        {
            foreach (SpriteRenderer mesh in meshs)
                mesh.material.color = Color.gray;
            health.Value = 0;
            StartCoroutine(dieAct());
        }
    }

    public void getHealth(float value)
    {
        health.MaxValue += value;
    }

    IEnumerator dieAct()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
