using UnityEngine;
using Tempest.Core;

namespace Tempest.Gameplay.Mission
{
    public class MissionManager : MonoBehaviour
    {
        public enum MissionState { NotStarted, InProgress, Completed, Failed }

        private MissionState _currentState = MissionState.NotStarted;

        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        public void StartMission(string missionID)
        {
            _currentState = MissionState.InProgress;
            Debug.Log($"Mission Started: {missionID}");
        }

        public void CompleteMission()
        {
            _currentState = MissionState.Completed;
            Debug.Log("Mission Completed!");
        }
    }
}