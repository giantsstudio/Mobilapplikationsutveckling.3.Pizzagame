using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public Text cheerOrBuuh;

    public Display display;

    public GameObject[] pizzaArray;

    public GameObject[] stuffArray;

    public Text dollarText;

    public static int dollars;

    List<int> playersChoice = new List<int>();

    int error = 0;

    int counter;

    public int boostTime;

    int chefsTop1;
    int chefsTop2;
    int chefsTop3;
    int chefsTop4;

    int pizzaTop1;
    int pizzaTop2;
    int pizzaTop3;
    int pizzaTop4;

    private void clearPizza()
    {
        for (int i = 0; i < 8; i++)
        {
            pizzaArray[i].SetActive(false);
        }
    }

    private void checkWithChef()
    {
        

        chefsTop1 = display.scanningNumber1;
        chefsTop2 = display.scanningNumber2;
        chefsTop3 = display.scanningNumber3;
        chefsTop4 = display.scanningNumber4;

        if ((chefsTop1 == pizzaTop1 || chefsTop1 == pizzaTop2 || chefsTop1 == pizzaTop3 || chefsTop1 == pizzaTop4) && 
            (chefsTop2 == pizzaTop1 || chefsTop2 == pizzaTop2 || chefsTop2 == pizzaTop3 || chefsTop2 == pizzaTop4) &&
             (chefsTop3 == pizzaTop1 || chefsTop3 == pizzaTop2 || chefsTop3 == pizzaTop3 || chefsTop3 == pizzaTop4) &&
              (chefsTop4 == pizzaTop1 || chefsTop4 == pizzaTop2 || chefsTop4 == pizzaTop3 || chefsTop4 == pizzaTop4)){

            counter = 0;
            playersChoice.Clear();
            dollars = dollars + 9;

            dollarText.text = dollars.ToString() + " $";

            display.ClearChiefsSchedule();
            display.StartChefsSchedule();
            display.iTrack = display.iTrack + 10;
            clearPizza();

        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        clearPizza();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                if(counter < 4) 
                {
                    counter++;
                    if (hit.collider.name == "pineapple")
                    {
                        pizzaArray[0].SetActive(true);
                        playersChoice.Add(0);
                    }
                    else if (hit.collider.name == "sausage")
                    {
                        pizzaArray[1].SetActive(true);
                        playersChoice.Add(1);
                    }
                    else if(hit.collider.name == "mushroom")
                    {
                        pizzaArray[2].SetActive(true);
                        playersChoice.Add(2);
                    }
                     else if (hit.collider.name == "cheeze")
                    {
                        pizzaArray[3].SetActive(true);
                        playersChoice.Add(3);
                    }
                    else if (hit.collider.name == "sparris")
                    {
                        pizzaArray[4].SetActive(true);
                        playersChoice.Add(4);
                    }
                    else if (hit.collider.name == "onion")
                    {
                        pizzaArray[5].SetActive(true);
                        playersChoice.Add(5);
                    }
                    else if (hit.collider.name == "lobster")
                    {
                        pizzaArray[6].SetActive(true);
                        playersChoice.Add(6);
                    }
                    else if (hit.collider.name == "tomato")
                    {
                        pizzaArray[7].SetActive(true);
                        playersChoice.Add(7);

                    }

                    if (counter == 1)
                    {
                        pizzaTop1 = playersChoice[0];
                    }
                    if (counter == 2)
                    {
                        pizzaTop2 = playersChoice[1];
                    }
                    if (counter == 3)
                    {
                        pizzaTop3 = playersChoice[2];
                    }
                    if (counter == 4)
                    {
                        pizzaTop4 = playersChoice[3];
                    }

                    
                }
            }

           
        }
        checkWithChef();
    }
  
}
