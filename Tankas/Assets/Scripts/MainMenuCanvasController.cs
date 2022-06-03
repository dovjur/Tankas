using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvasController : MonoBehaviour
{
    [SerializeField]
    private RectTransform mainMenu;

    [SerializeField]
    private RectTransform optionsMenu;

    [SerializeField]
    private Slider musicVolumeSlider;

    [SerializeField]
    private Slider effectsVolumeSlider;

    [SerializeField]
    private MixerController mixerController;

    private SceneFader sceneFader;
    private bool changingScenes;
    private void Awake()
    {
        sceneFader = GetComponent<SceneFader>();
    }

    private static void Show(Component component)
    {
        component.gameObject.SetActive(true);
    }
    private static void Hide(Component component)
    {
        component.gameObject.SetActive(false);
    }
    private void Start()
    {
        ShowMainMenu();
        UpdateSliders();
    }
    public void StartGame()
    {
        if (changingScenes)
        {
            return;
        }
        StartCoroutine(StartGameDelayed());
        //Scenes.LoadNextScene();
    }
    public void ExitGame()
    {
        if (changingScenes)
        {
            return;
        }
        StartCoroutine(ExitGameDelayed());
        //Scenes.ExitGame();
    }
    public void ShowMainMenu()
    {
        Show(mainMenu);
        Hide(optionsMenu);
    }

    public void ShowOptionMenu()
    {
        Hide(mainMenu);
        Show(optionsMenu);
    }
    private void UpdateSliders()
    {
        musicVolumeSlider.SetValueWithoutNotify(mixerController.MusicVolume);
        effectsVolumeSlider.SetValueWithoutNotify(mixerController.EffectsVolume);
    }

    private IEnumerator StartGameDelayed()
    {
        changingScenes = true;
        yield return sceneFader.FadeOutScene();
        Scenes.LoadNextScene();
    }
    private IEnumerator ExitGameDelayed()
    {
        changingScenes = true;
        yield return sceneFader.FadeOutScene();
        Scenes.ExitGame();
    }

}
