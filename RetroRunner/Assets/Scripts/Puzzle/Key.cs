using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private GameObject goal;

    private void Update()
    {
        if (Vector2.Distance(goal.transform.position, this.transform.position) <= 0.1f)
        {
            Debug.Log("Clear");
        }
    }
}
