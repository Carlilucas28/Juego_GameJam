using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LifeManager : MonoBehaviour
{
    public List<Image> lifeSprites;
    private int maxLives;
    private int currentLives;

    private void Start()
    {
        maxLives = lifeSprites.Count;
        currentLives = maxLives;
        UpdateLifeSprites();
    }

    public void RemoveLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            UpdateLifeSprites();
        }
    }

    public void AddLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            UpdateLifeSprites();
        }
    }

    private void UpdateLifeSprites()
    {
        for (int i = 0; i < lifeSprites.Count; i++)
        {
            lifeSprites[i].enabled = i < currentLives;
        }
    }
}
