using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject[] keySlot = new GameObject[4];
    [SerializeField]
    private GameObject key;

    public void KeyRotation()
    {
        Debug.Log("turn");
        for (int i = 0; i < 4; i++)
        {
            if (Vector2.Distance(key.transform.position, keySlot[i].transform.position) <= 0.5f)
            {
                Debug.Log("turn2");
                i = (i + 1) % 4;
                key.transform.position = keySlot[i].transform.position;
                break;
            }
        }
    }
}
