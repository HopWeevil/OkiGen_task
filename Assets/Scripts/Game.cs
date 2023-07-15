using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private MissionsList _missionsList;
    [SerializeField] private MissionView _missionView;
    [SerializeField] private Player _player;
    [SerializeField] private Conveyor _conveyor;
    [SerializeField] private FoodSpawner _foodSpawner;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private EffectHandler _effectHandler;
    [SerializeField] private LevelPassScreen _levelPassScreen;
    [SerializeField] private StartGameScreen _startGameScreen;
    [SerializeField] private MissionScreen _missionScreen;
    [SerializeField] private Transform _foodBasket;

    private Mission _currentMission;

    private void Awake()
    {
        _currentMission = _missionsList.GetRandomMission();
        _currentMission.Create();
        _missionView.Render(_currentMission);
    }

    private void OnEnable()
    {
        _player.FoodDropped += OnFoodDropped;
        _currentMission.MissionComplete += OnMissionComplete;
        _levelPassScreen.NextLevelButtonClick += OnNextLevelButtonClick;
        _startGameScreen.StartGameButtonClick += OnStartGameButtonClick;

    }

    private void OnDisable()
    {
        _player.FoodDropped -= OnFoodDropped;
        _currentMission.MissionComplete -= OnMissionComplete;
        _levelPassScreen.NextLevelButtonClick -= OnNextLevelButtonClick;
        _startGameScreen.StartGameButtonClick -= OnStartGameButtonClick;
    }

    private void OnFoodDropped(Food food)
    {
        _currentMission.TryUpdateState(food);
        _effectHandler.PlayTextPopupEffect(_foodBasket);
    }

    private void OnMissionComplete()
    {
        _effectHandler.PlayConfettiEffect();
        _cameraMover.Move();
        _levelPassScreen.Show();
        Destroy(_foodSpawner.gameObject);
        _conveyor.Destroy();
        _player.SetDanceState();
        _missionScreen.Hide();
    }

    private void OnStartGameButtonClick()
    {
        _startGameScreen.Hide();
        _foodSpawner.StartSpawning();
        _player.SetIdleState();
        _missionScreen.Show();
    }

    private void OnNextLevelButtonClick()
    {
        Restart();
    }

    private void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}