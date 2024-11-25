using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public AudioSource clip;
    public AudioClip[] clipArray;
    private int counter = 0;
    private bool changeScene = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(HandleIntroSequence());
    }

    private IEnumerator HandleIntroSequence()
    {
        while (counter < clipArray.Length)
        {
            // Play the next audio clip
            clip.clip = clipArray[counter];
            clip.Play();

            // Wait for the duration of the audio clip to complete
            float remainingTime = clip.clip.length;

            // Update the image and animation according to the counter value
            HandleSceneTransition();

            // Wait until the current audio clip finishes playing
            yield return new WaitForSeconds(remainingTime);

            // Increment counter to move to the next clip/image
            counter++;
        }

        // Handle scene change after the loop completes
        if (changeScene)
        {
            ChangeScene("Advertisement-TycoonLoader");
        }
    }

    private void HandleSceneTransition()
    {
        switch (counter)
        {
            case 1:
                UpdateImageAndAnimation("1345", "Anim1", new Vector2(0.214f, 0.223f), new Vector2(3.791222f, 0f), false);
                break;
            case 2:
                UpdateImageAndAnimation("1347", "Anim2");
                break;
            case 3:
                UpdateImageAndAnimation("1350", "Anim1", new Vector2(0.214f, 0.223f), new Vector2(3.791222f, 0f), false);
                break;
            case 4:
                UpdateImageAndAnimation("1349");
                break;
            case 5:
                UpdateImageAndAnimation("1352", "Anim2");
                break;
            case 6:
                UpdateImageAndAnimation("1348", "Anim1");
                break;
            case 7:
                UpdateImageAndAnimation("1351", "Anim1", new Vector2(0.214f, 0.223f), new Vector2(3.791222f, 0f), false);
                break;
            case 8:
                UpdateImageAndAnimation("1375");
                break;
            case 9:
                UpdateImageAndAnimation("1354", "Anim1", new Vector2(0.25f, 0.223f));
                break;
            case 10:
                UpdateImageAndAnimation("1372", "Anim2");
                break;
            case 11:
                UpdateImageAndAnimation("1355", null, new Vector2(0.214f, 0.223f), new Vector2(3.791222f, 0f), false);
                break;
            case 12:
                UpdateImageAndAnimation("1356");
                break;
            case 13:
                UpdateImageAndAnimation("1357");
                break;
            case 14:
                UpdateImageAndAnimation("1358");
                break;
            case 15:
                UpdateImageAndAnimation("1373", "Anim1", new Vector2(0.25f, 0.223f));
                break;
            case 16:
                UpdateImageAndAnimation("1359", null, new Vector2(0.214f, 0.223f), new Vector2(3.791222f, 0f), false);
                break;
            case 17:
                UpdateImageAndAnimation("1360");
                break;
            case 18:
                UpdateImageAndAnimation("1361", "Anim1", new Vector2(0.25f, 0.223f));
                break;
            case 19:
                UpdateImageAndAnimation("1362", null, new Vector2(0.214f, 0.223f), new Vector2(3.791222f, 0f), false);
                break;
            case 20:
                UpdateImageAndAnimation("1364");
                break;
            case 21:
                UpdateImageAndAnimation("1363");
                break;
            case 22:
                UpdateImageAndAnimation("1365");
                break;
            case 23:
                UpdateImageAndAnimation("1366");
                break;
            case 24:
                UpdateImageAndAnimation("1367");
                break;
            case 25:
                UpdateImageAndAnimation("1368");
                break;
            case 26:
                UpdateImageAndAnimation("1369");
                break;
            case 27:
                UpdateImageAndAnimation("1370");
                break;
            case 28:
                UpdateImageAndAnimation("1371");
                changeScene = true;  // Set changeScene to true when ready to transition
                break;
        }
    }

    // Consolidated function to change the scene
    private void ChangeScene(string sceneName)
    {
        // Only change scene if changeScene is true
        if (changeScene)
        {
            SceneManager.LoadSceneAsync(sceneName);
            changeScene = false;  // Reset changeScene after the scene is loaded
        }
    }

    private void UpdateImageAndAnimation(string spriteName, string animationName = null, Vector2? scale = null, Vector2? position = null, bool playAnim = true)
    {
        Resources.UnloadUnusedAssets();
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/" + spriteName);

        if (animationName != null)
        {
            gameObject.GetComponent<Animation>().Play(animationName);
        }

        if (scale.HasValue)
        {
            gameObject.transform.localScale = scale.Value;
        }

        if (position.HasValue)
        {
            gameObject.transform.localPosition = position.Value;
        }

        if (!playAnim)
        {
            gameObject.GetComponent<Animation>().Stop();
        }
    }
}
