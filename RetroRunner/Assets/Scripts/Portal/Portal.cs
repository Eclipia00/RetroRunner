using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;
    [SerializeField] private GameObject puzzleCam;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private SpriteRenderer portal;
    [SerializeField] private CubeManager cubeManager;
    [SerializeField] private GameObject ladder;

    private bool _isClear;
    private void Start()
    {
        _isClear = false;
        puzzleCam.SetActive(false);
        puzzle.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(_isClear) return;
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SetPuzzleCam();
                puzzle.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if(_isClear) return;
        if (other.CompareTag("Player"))
        {
            ResetPuzzleCam();
        }
    }

    private void SetPuzzleCam()
    {
        puzzleCam.SetActive(true);
    }

    private void ResetPuzzleCam()
    {
        puzzleCam.SetActive(false);
    }

    public void ActivePortal()
    {
        Color activePortal = new Color(0, 100, 100, 100);
        background.color = activePortal;
        portal.color = activePortal;
        ResetPuzzleCam();
        ladder.SetActive(true);
        _isClear = true;
    }
}
