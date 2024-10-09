using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveLight : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spriteRenderers;

    void Start()
    {
        //spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        StartCoroutine(AlphaPulseCoroutine());
    }

    public float fadeDuration = 2.0f;
    public float minAlpha = 0.3f; 
    public float maxAlpha = 1.0f; 

    private bool fadingIn = true;

    private IEnumerator AlphaPulseCoroutine()
    {
        
        while (true)
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                float targetAlpha = fadingIn ? maxAlpha : minAlpha;
                float startAlpha = spriteRenderer.color.a;
                float elapsedTime = 0f;

                while (elapsedTime < fadeDuration)
                {
                    float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
                    Color newColor = spriteRenderer.color;
                    newColor.a = alpha;
                    spriteRenderer.color = newColor;

                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                // 반전하여 알파 값을 변경
                fadingIn = !fadingIn;
            }
            
            yield return new WaitForSeconds(3f);
        }
    }
}
