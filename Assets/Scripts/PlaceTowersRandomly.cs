using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceTowersRandomly : MonoBehaviour
{
    // Replace positions of the towers.
    public Transform[] replacePoints;
    // Scriptable objects
    public TowerData basicTower;
    public TowerData powerfulTower;
    // How many times you can spawn a tower.
    private int generateCount = 5;

    public GameObject spawnButton;
    public GameObject unleashHellText;
    public GameObject warningText;
    public GameObject startButton;
    public TextMeshProUGUI countText;
    // To control the occupied points.
    [SerializeField]
    private List<int> occupiedPoints;
    // To produce a random number to spawn.
    private int random;
    // To prevent spawn twice to a same point.
    private bool match = false;

    private void Start()
    {
        countText.text = "" + generateCount;
    }

    // This function generate the towers position randomly and prevent to spawn two turrets on the same position.
    // Also if all positions occupied, inactivate the button automatically.
    public void GenerateTowers()
    {
        random = Random.Range(0, replacePoints.Length);
        // If there is match, then recursive function works for prevent to spawn to a same place twice.
        if(occupiedPoints != null)
        {
            for (int i = 0; i < occupiedPoints.Count; i++)
            {
                if (occupiedPoints[i] == random)
                {
                    match = true;
                }
            }
            // If there is a match, recursive.
            if (match)
            {
                match = false;
                GenerateTowers();
            }
            // If there is not match, inform the occupied point and spawn that place a new tower.
            else
            {
                occupiedPoints.Add(random);
                if(random % 2 == 0)
                {
                    GameObject turret = Instantiate(basicTower.towerObject);
                    turret.transform.position = replacePoints[random].position;
                    turret.transform.rotation = replacePoints[random].rotation;
                    generateCount--;
                    countText.text = "" + generateCount;
                }
                // If random number is not odd, spawn the powerful tower.
                else if(random % 2 != 0)
                {
                    GameObject turret = Instantiate(powerfulTower.towerObject);
                    turret.transform.position = replacePoints[random].position;
                    turret.transform.rotation = replacePoints[random].rotation;
                    generateCount--;
                    countText.text = "" + generateCount;
                }
            }
        }

        // If all positions occupied, inactive the spawn button.
        if(generateCount <= 0)
        {
            spawnButton.gameObject.SetActive(false);
            warningText.gameObject.SetActive(true);
            unleashHellText.gameObject.SetActive(true);
            startButton.gameObject.SetActive(true);
        }
    }
}
