using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    private CharacterController _characterController;
    private Health _health;
    [SerializeField] private GameObject enemySprite;

    [SerializeField] private Vector3 _moveDirection;

    private bool _isRight;

    [SerializeField] private float currentSpeed = 3f;
    
    [Header("Variables")]
    [Range(3f, 10f)]
    [SerializeField] private float gravity = 8f;
    [Range(1f, 5f)] 
    [SerializeField] private float moveRange = 3f;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _health = GetComponent<Health>();
        _isRight = true;
        StartCoroutine(EnemyTurnManager());
    }

    void Update()
    {
        Movement();
        Gravity();
        Vector3 moveThisDirection = new Vector3(_moveDirection.x,  _moveDirection.y, 0);
       
        _characterController.Move(moveThisDirection * Time.deltaTime);
    }

    private void Movement()
    {
        if (_health.isDead)
        {
            _moveDirection = Vector3.zero;
            animator.enabled = false;
            return;
        }
        _moveDirection = transform.right * currentSpeed * -1;
        animator.SetBool("isWalk",true);
    }

    private void Gravity()
    {
        //Gravity
        _moveDirection.y = _moveDirection.y + (Physics.gravity.y * gravity * Time.deltaTime);
    }
    
    IEnumerator EnemyTurnManager()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveRange);

            EnemyTurn();
        }
    }

    private void EnemyTurn()
    {
        if (_isRight)
        {
            _isRight = false;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            _isRight = true;
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
