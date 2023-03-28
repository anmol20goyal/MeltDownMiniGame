using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region GameObjects

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Animator gameOverAnim;
    [SerializeField] private TMP_Text countDownTxt;
    [SerializeField] private GameObject bgPanel;

    #endregion

    #region Variables

    [HideInInspector] public bool startGame;

    #endregion

    private void Start()
    {
        startGame = false;
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        int count = 3;

        while (count > 0) 
        {
            countDownTxt.text = count.ToString();
            count--;
            yield return new WaitForSeconds(1.5f);
        }

        countDownTxt.text = "GO!";
        yield return new WaitForSeconds(.5f);
        bgPanel.SetActive(false);
        startGame = true;
    }

    public void GameEnd()
    {
        startGame = false;
        gameOverPanel.SetActive(true);
        gameOverAnim.enabled = true;
    }
}
