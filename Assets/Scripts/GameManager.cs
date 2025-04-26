using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI itemCountText;
    public GameObject victoryMessage;
    public GameObject defeatMessage;

    public GameObject victoryBox;
    public AudioClip victorySound;
    public AudioClip defeatSound;

    public float gameTime = 600f;
    public float healthDecreaseInterval = 5f;
    public int maxHealth = 100;
    public int totalItemsToCollect = 10;

    private float timeRemaining;
    private int currentHealth;
    private bool isGameOver = false;
    private AudioSource audioSource;
    private InventoryManager inventory;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        inventory = FindObjectOfType<InventoryManager>();
        if (inventory != null)
        {
            inventory.totalItems = totalItemsToCollect;
        }

        timeRemaining = gameTime;
        currentHealth = maxHealth;

        UpdateHealthUI();
        UpdateTimerUI();
        UpdateItemCountUI();

        if (victoryMessage != null) victoryMessage.SetActive(false);
        if (defeatMessage != null) defeatMessage.SetActive(false);
        if (victoryBox != null) victoryBox.SetActive(false);

        StartCoroutine(DecreaseHealthOverTime());
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
            return;
        }

        timeRemaining -= Time.deltaTime;
        UpdateTimerUI();

        if (timeRemaining <= 0)
        {
            GameOver(false);
            return;
        }

        if (inventory != null && inventory.itemCount >= totalItemsToCollect)
        {
            ActivateVictoryBox();
        }

        if (currentHealth <= 0)
        {
            GameOver(false);
        }
    }

    private IEnumerator DecreaseHealthOverTime()
    {
        while (!isGameOver && currentHealth > 0)
        {
            yield return new WaitForSeconds(healthDecreaseInterval);
            ChangeHealth(-1);
        }
    }

    public void ChangeHealth(int amount)
    {
        if (isGameOver) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            GameOver(false);
        }
    }

    public void ApplyBandage(int healAmount)
    {
        ChangeHealth(healAmount);
    }

    private void ActivateVictoryBox()
    {
        if (victoryBox != null && !victoryBox.activeSelf)
        {
            victoryBox.SetActive(true);

            // Jouer le son de victoire
            if (audioSource != null && victorySound != null)
            {
                audioSource.PlayOneShot(victorySound);
            }
        }
    }

    public void PlayerReachedVictoryBox()
    {
        GameOver(true);
    }

    private void GameOver(bool isVictory)
    {
        isGameOver = true;

        if (isVictory)
        {
            if (victoryMessage != null)
            {
                victoryMessage.SetActive(true);
            }

            if (audioSource != null && victorySound != null)
            {
                audioSource.PlayOneShot(victorySound);
            }
        }
        else
        {
            if (defeatMessage != null)
            {
                defeatMessage.SetActive(true);
            }

            if (audioSource != null && defeatSound != null)
            {
                audioSource.PlayOneShot(defeatSound);
            }
        }

        Debug.Log("Jeu terminé! Victoire: " + isVictory);
        Debug.Log("Appuyez sur R pour recommencer");
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void UpdateItemCountUI()
    {
        if (itemCountText != null && inventory != null)
        {
            itemCountText.text = "Items: " + inventory.itemCount + " / " + totalItemsToCollect;
        }
    }
}