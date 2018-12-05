using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class MenuFlow : MonoBehaviour
{
    public CanvasGroup canvasGroup0;
    public CanvasGroup canvasGroup1;
    public CanvasGroup canvasGroup2;
    public CanvasGroup canvasGroup3;
    public CanvasGroup canvasGroup4;
    public CanvasGroup canvasGroup5;
    public CanvasGroup canvasGroup6;


    private Sequence s;


    public void paseGameOver()
    {
        Debug.Log("paseGameOver");

    }

    public void paseMenu()
    {
        s.Complete();
        SceneManager.LoadScene("Scena1");
    }
    public void paseMenuDesdeCreditos()
    {
        s.Complete();
        canvasGroup5.gameObject.SetActive(false);
    }
    public void paseMenuDesdeControl()
    {
        s.Complete();
        canvasGroup6.gameObject.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void paseCreditos()
    {
        Debug.Log("paseCreditos");
        canvasGroup5.gameObject.SetActive(true);
    }

    public void paseControl()
    {
        Debug.Log("pasaControl");
        canvasGroup6.gameObject.SetActive(true);
    }

    public void paseJuego()
    {
        Debug.Log("paseJuego");
        float fade = 1f;
        float interval = 3f;
        //SceneManager.LoadScene("Scena2");
        s = DOTween.Sequence();
        s.Append(canvasGroup0.DOFade(0f, fade));
        s.AppendInterval(interval);
        s.Append(canvasGroup1.DOFade(0f, fade));
        s.AppendInterval(interval);
        s.Append(canvasGroup2.DOFade(0f, fade));
        s.AppendInterval(interval);
        s.Append(canvasGroup3.DOFade(0f, fade));
        s.AppendInterval(interval);
        s.Append(canvasGroup4.DOFade(0f, fade));
        s.OnComplete(() => {
            SceneManager.LoadScene("Scena2");
        });
    }

    public void gameStart()
    {
        s.Complete();
        SceneManager.LoadScene("Scena2");
    }
}
