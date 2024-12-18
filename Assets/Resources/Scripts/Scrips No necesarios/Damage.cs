using UnityEngine;
using System.Collections;

public class DamageCube : MonoBehaviour
{
    public float scaleDuration = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeManager lifeManager = other.GetComponent<LifeManager>();
            if (lifeManager != null)
            {
                lifeManager.RemoveLife();
            }
            StartCoroutine(AnimateAndDestroy());
        }
    }

    private IEnumerator AnimateAndDestroy()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.5f;

        float elapsed = 0f;
        while (elapsed < scaleDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / scaleDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;
        while (elapsed < scaleDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, Vector3.zero, elapsed / scaleDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
