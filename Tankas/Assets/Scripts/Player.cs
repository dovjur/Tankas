using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    [Header("Player state")]
    [SerializeField, Min(0)]
    private int lives = 3;

    [SerializeField, Min(0)]
    private int ammo = 5;

    [Header("Events")]
    [SerializeField]
    private IntUnityEvent onUpdateLives;

    [SerializeField]
    private IntUnityEvent onUpdateAmmo;

    [SerializeField]
    private UnityEvent onStopGame;

    [Header("UI")]
    [SerializeField]
    private Text livesText;

    [SerializeField]
    private Text ammoText;

    [SerializeField]
    private Text finalText;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //UpdateLivesText();
        //UpdateAmmoText();
        InvokeOnUpdateLives();
        InvokeOnUpdateAmmo();
    }

    private void UpdateLivesText()
    {
        livesText.text = $"Lives: {lives}";
    }

    private void UpdateAmmoText()
    {
        ammoText.text = $"Ammo: {ammo}";
    }
    
    public void TakeDemage()
    {
        //lives--;
        //UpdateLivesText();
        AddLives(-1);

        if (lives <=0 )
        {
            //StopGame();
            onStopGame.Invoke();
        }
    }

    public void AddLives(int value)
    {
        lives += value;
        //UpdateLivesText();
        InvokeOnUpdateLives();
    }

    public void AddAmmo(int value)
    {
        ammo += value;
        //UpdateAmmoText();
        InvokeOnUpdateAmmo();
    }

    private void StopGame()
    {
        playerController.enabled = false;
        finalText.gameObject.SetActive(true);
    }
    private void InvokeOnUpdateLives()
    {
        onUpdateLives.Invoke(lives);
    }
    private void InvokeOnUpdateAmmo()
    {
        onUpdateAmmo.Invoke(ammo);
    }
}
