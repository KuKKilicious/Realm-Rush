using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    [SerializeField]
    Tower towerPrefab;
    [SerializeField]
    int towerLimit = 5;

    //create empty queue of Towers
    private Queue<Tower> towers = new Queue<Tower>();
    public void AddTower(Waypoint baseWaypoint) {
        if(towers.Count<towerLimit) //use towers Length
            {
            InstantiateNewTower(baseWaypoint);
        } else {
            MoveExistingTower(baseWaypoint);
        }

    }

    private void InstantiateNewTower(Waypoint baseWaypoint) {
        Tower tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, GameObject.Find("Towers").transform);
        //set the baseWaypoints
        tower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        //put new Tower on the queue
        towers.Enqueue(tower);
    }

    private void MoveExistingTower(Waypoint baseWaypoint) {
        //take bottom tower of queue

        Tower tower = towers.Dequeue();
        //set old wayPoint isPlaceable to true
        tower.baseWaypoint.isPlaceable = true;
        tower.transform.position = baseWaypoint.transform.position;
        //set the baseWaypoints
        tower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
      
        //put old tower on top of the queue
        towers.Enqueue(tower);
    }
}
