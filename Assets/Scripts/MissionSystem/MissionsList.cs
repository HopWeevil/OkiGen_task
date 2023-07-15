using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsList : MonoBehaviour
{
    [SerializeField] private List<Mission> _missions;

    public Mission GetRandomMission()
    {
        return _missions[Random.Range(0, _missions.Count)];
    }
}
