using HedronStateMachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Scoreboard _scoreboard;
    [SerializeField] private int _numPlayers;
    private int _playerTurn;
    private int[] _gameScore;

    // Invokes the next player's turn.
    public void SwitchTurns()
    {
        _playerTurn = (_playerTurn + 1) % _numPlayers;
    }

    // Incements the throwing team's score.
    public void Score(int amount)
    {
        if (_playerTurn <= (_numPlayers / 2)) {
            _gameScore[0] += amount;
        }
        else
        {
            _gameScore[1] += amount;
        }

        _scoreboard.Refresh(_gameScore);
        SwitchTurns();
    }

    // Subscribes this GameManager to the HedronState events that dictate gameflow.
    private void OnEnable()
    {
        ValidBounceState.OnScore += Score;
        ValidBounceState.OnCatch += SwitchTurns;
        ThrownState.OnScore += Score;
        ThrownState.OnDead += SwitchTurns;
    }

    private void OnDisable()
    {
        ValidBounceState.OnScore -= Score;
        ValidBounceState.OnCatch -= SwitchTurns;
        ThrownState.OnScore -= Score;
        ThrownState.OnDead -= SwitchTurns;
    }

    private void Start()
    {
        _gameScore = new int[2] { 0, 0 };
    }
}
