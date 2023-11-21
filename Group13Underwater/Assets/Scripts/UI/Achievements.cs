using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public Canvas achievementCanvas;
    public Image badgeImage;

    public Sprite[] badgeSprites; // Add your badge sprites in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        achievementCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Simulating the player achieving something
        if (Input.GetKeyDown(KeyCode.Space)) // Replace this with your actual achievement logic
        {
            ShowAchievement();
        }
    }

    void ShowAchievement()
    {
        int randomIndex = Random.Range(0, badgeSprites.Length);
        Sprite randomBadge = badgeSprites[randomIndex];

        StartCoroutine(ShowAndFadeAchievement(randomBadge));
    }

    IEnumerator ShowAndFadeAchievement(Sprite badgeSprite)
    {
        badgeImage.sprite = badgeSprite;
        achievementCanvas.enabled = true;

        yield return new WaitForSeconds(5f); // Show the badge for 5 seconds

        achievementCanvas.enabled = false;
    }
}
