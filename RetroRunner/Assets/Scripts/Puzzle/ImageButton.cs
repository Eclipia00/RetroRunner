using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageButton : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzleManager;
    public bool selected = false;
    public Image buttonColor;
    public Color defualtColor;
    public Color selectColor;
    public void Selecte()
    {
        selected = !selected;
        if (selected == false)
        {
            buttonColor.color = defualtColor;
        }
        else
        {
            buttonColor.color = selectColor;
        }
        puzzleManager.GetComponent<PuzzleManager>().checkImage();
    }
}
