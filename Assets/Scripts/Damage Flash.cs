using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [ColorUsage(true,true)]
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float flashDuration = 0.25f;

    private SpriteRenderer _spriteRenderer;
    private Material _material;

    private Coroutine _DMGflashcoroutine;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _material = _spriteRenderer.material;
    }

    public void CallDMGFlash()
    {
        if (_DMGflashcoroutine != null)
            StopCoroutine(_DMGflashcoroutine);

        _DMGflashcoroutine = StartCoroutine(DMGFlasher());
    }

    private IEnumerator DMGFlasher()
    {
        {
            _material.SetColor("_FlashColour", flashColor);

            float elapsedTime = 0f;
            while (elapsedTime < flashDuration)
            {
                float amount = Mathf.Lerp(1f, 0f, elapsedTime / flashDuration);
                _material.SetFloat("_FlashAmount", amount);
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            _material.SetFloat("_FlashAmount", 0f); // Ensure it's reset
        }
    }
}


