using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _endPanel;

    [SerializeField]
    private GameObject _playerWonText;

    [SerializeField]
    private GameObject _enemiesWonText;

    [SerializeField]
    private Entity _player;

    [SerializeField]
    private EnemiesManager _enemiesManager;

    private void Awake()
    {
        if (_player != null)
            _player.PlayerDied += OnPlayerDied;

        if (_enemiesManager != null)
            _enemiesManager.AllEnemiesDied += OnEnemiesDied;
    }

    private void OnDestroy()
    {
        if (_player != null)
            _player.PlayerDied -= OnPlayerDied;

        if (_enemiesManager != null)
            _enemiesManager.AllEnemiesDied -= OnEnemiesDied;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }

    private void OnPlayerDied()
    {
        RestartGame(false);
    }

    private void OnEnemiesDied()
    {
        RestartGame(true);
    }


    public void RestartGame(bool playerWon)
    {
        _endPanel.SetActive(true);

        if (playerWon) _playerWonText.SetActive(true);
        else _enemiesWonText.SetActive(true);

        StartCoroutine(nameof(RestartAfterTime));
    }

    private IEnumerator RestartAfterTime()
    {
        yield return new WaitForSeconds(3f);

        _endPanel.SetActive(false);
        _playerWonText.SetActive(false);
        _enemiesWonText.SetActive(false);

        SceneManager.LoadScene(0);
    }
}
