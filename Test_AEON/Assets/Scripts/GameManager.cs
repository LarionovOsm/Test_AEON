using System;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [Header("Player settings")]
    [SerializeField] GameObject _player;
    [SerializeField] Vector3 _startPosition;
    [Header("Camera settings")] 
    [SerializeField] GameObject _freeLookCamera;
    [Header("Time settings")]
    [SerializeField] private bool _isPaused;
    [Header("UI settings")]
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _resultMenu;
    [SerializeField] GameObject _resultMessege;
    [SerializeField] Text _levelCompleteResultText;
    [SerializeField] Text _resultMenuResultText;
    private float _resultTime;
    private Rigidbody _playerRigidbody;
    private CinemachineFreeLook _freeLookCameraSettings;

    private void Start()
    {
        _isPaused = true;
        _playerRigidbody = _player.GetComponent<Rigidbody>();
        _freeLookCameraSettings = _freeLookCamera.GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        if (_isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        _resultTime += Time.deltaTime;
    }

    public void IsPaused()
    {
        _isPaused = !_isPaused;
    }

    public void SuccessfulMessege()
    {
        _resultMessege.SetActive(true);
        _levelCompleteResultText.text = ("Level complete in " + Math.Round(_resultTime, 3).ToString() + " seconds");
        _resultMenuResultText.text = ("Your last result is " + Math.Round(_resultTime, 3).ToString() + " seconds");
        IsPaused();
    }

    public void LoseMessege()
    {
        _resultMessege.SetActive(true);
        _levelCompleteResultText.text = ("You lose!");
        IsPaused();
    }

    public void Restart()
    {
        _player.transform.rotation = Quaternion.Euler(0, 0, 0);
        _player.transform.position = _startPosition;
        _playerRigidbody.velocity = Vector3.zero;
        _playerRigidbody.angularVelocity = Vector3.zero;
        _freeLookCameraSettings.m_YAxis.Value = 0.5f;
        _freeLookCameraSettings.m_XAxis.Value = 0f;
        _resultTime = 0;
        _isPaused = true;
        _mainMenu.SetActive(true);
        _resultMenu.SetActive(false);
        _resultMessege.SetActive(false);
    }
}