using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour
{
    public int iTrack;
    public Text timer;

   
    
    public int scanningNumber1;
    public int scanningNumber2;
    public int scanningNumber3;
    public int scanningNumber4;


    public Controller controller;
    public GameObject[] stickersOrder;
    public Text[] textOnSticker;
    public GameObject[] evryTopping;




    public void ClearChiefsSchedule()
    {

        for(int i = 0; i < 4; i++)
        {
            stickersOrder[i].SetActive(false);
            
        }
    }

 
   

    public void StartChefsSchedule()
    {       
        
        List<int> zList = new List<int>();
        List<int> ChefWhantsToCompareList = new List<int>();

        
        for (int z = 0; z < 8; z++)
        {
            zList.Add(z);
        }
        for (int i = 0; i < 4; i++)
        {
            
            stickersOrder[i].SetActive(true);
            
            int zIndex = Random.Range(0, zList.Count -1);
            int zRandom = zList[zIndex];
            ChefWhantsToCompareList.Add(zRandom);
            textOnSticker[i].text = evryTopping[zRandom].name;
            zList.RemoveAt(zIndex);
            
        }

        scanningNumber1 = ChefWhantsToCompareList[0];
        scanningNumber2 = ChefWhantsToCompareList[1];
        scanningNumber3 = ChefWhantsToCompareList[2];
        scanningNumber4 = ChefWhantsToCompareList[3];


    }



  public void Start()
    {
        ClearChiefsSchedule();

        StartChefsSchedule();
        
        StartCoroutine(GetToWorkAndMakePizzas());

    }

  public IEnumerator GetToWorkAndMakePizzas()
    {

        
        for (iTrack = 15; iTrack > -1; iTrack--)
            
            {
                timer.text = iTrack.ToString();
                yield return new WaitForSeconds(1f);
            if (iTrack < 5)
            {
                timer.color = Color.red;
            }
            if (iTrack > 5)
            {
                timer.color = Color.green;
            }
            if (iTrack == 0)
            {
                timer.text = "Bye!";
                SceneManager.LoadScene(2);
            }
            }
        
    }
    
}
