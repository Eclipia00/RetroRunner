using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject imageBorad;
    private ImageButton[] imageButtonSet;
    private bool[] correctImage = {false, true, true,  false, false,
                                    true, true, true,  false, true,
                                   false, true, true,  true,  true,
                                   false, true, true,  true,  true,
                                    true, true, false, true,  true };

    private void Start()
    {
        imageButtonSet = imageBorad.GetComponentsInChildren<ImageButton>();
    }

    public void checkImage()
    {
        int i = 0;
        for (; i < 25; i++)
        {
            if (imageButtonSet[i].selected != correctImage[i])
            {
                Debug.Log("Fail");
                break;
            }
        }
        if (i >= 25)
        {
            Debug.Log("Clear");
        }
    }
}
