using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public PlantPrefab plant;
    public SlotPrefab slot;
    public List<GameObject> plantInstance;
    public List<GameObject> slotInstance;
    private int completed;

    void Start()
    {
        for(int i = 0; i < slot.pos.Count; i++)
        {
            var newSlot = Instantiate(slot.image, slot.pos[i], Quaternion.identity);
            slotInstance.Add(newSlot);
            newSlot.transform.SetParent(canvas.transform, false);
        }

        for(int i = 0; i < plant.image.Count; i++)
        {
            var newPlant = Instantiate(plant.image[i], plant.pos[i], Quaternion.identity);
            plantInstance.Add(newPlant);
            newPlant.transform.SetParent(canvas.transform, false);
        }
    }

    void Update()
    {
        completed = 0;

        for(int i = 0; i < plantInstance.Count; i++)
        {
            if(plantInstance[i].transform.position == slotInstance[plant.target[i]].transform.position)
            {
                slotInstance[plant.target[i]].GetComponent<Image>().color = new Color32(0, 255, 0, 50);
                completed++;
            }
            else
            {
                slotInstance[plant.target[i]].GetComponent<Image>().color = new Color32(255, 0, 0, 50);
            }
        }

        if(completed == plantInstance.Count)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // MISSING TEST
        }
    }
}
