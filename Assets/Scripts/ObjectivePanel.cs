using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePanel : MonoBehaviour
{
    [SerializeField] Objective objectivePrefab;
    [SerializeField] GameObject childpanel;
    public void PopulateObjectives(string type, string objective)
    {
        switch(type)
        {
            case "gb":
                Objective objective1 = Instantiate(objectivePrefab, childpanel.transform);
                Objective objective2 = Instantiate(objectivePrefab, childpanel.transform);
                Objective objective3 = Instantiate(objectivePrefab, childpanel.transform);
                Objective objective4 = Instantiate(objectivePrefab, childpanel.transform);
                objective1.objectiveText.text = "Wash";
                objective2.objectiveText.text = "Massage";
                objective3.objectiveText.text = "Cloth";
                objective4.objectiveText.text = "Coffin";
                switch (objective)
                {
                    case "not":
                        break;
                    case "wash":
                        objective1.checkImage.gameObject.SetActive(true);
                        break;
                    case "mass":
                        objective1.checkImage.gameObject.SetActive(true);
                        objective2.checkImage.gameObject.SetActive(true);
                        break;
                    case "clot":
                        objective1.checkImage.gameObject.SetActive(true);
                        objective2.checkImage.gameObject.SetActive(true);
                        objective3.checkImage.gameObject.SetActive(true);
                        break;
                    case "coff":
                        objective1.checkImage.gameObject.SetActive(true);
                        objective2.checkImage.gameObject.SetActive(true);
                        objective3.checkImage.gameObject.SetActive(true);
                        objective4.checkImage.gameObject.SetActive(true);
                        break;
                }
                break;
            case "nb":
                Objective objective5 = Instantiate(objectivePrefab, childpanel.transform);
                Objective objective6 = Instantiate(objectivePrefab, childpanel.transform);
                Objective objective7 = Instantiate(objectivePrefab, childpanel.transform);
                objective5.objectiveText.text = "Wash";
                objective6.objectiveText.text = "Massage";
                objective7.objectiveText.text = "Cloth";
                switch (objective)
                {
                    case "not":
                        print("not");
                        break;
                    case "wash":
                        objective5.checkImage.gameObject.SetActive(true);
                        break;
                    case "mass":
                        objective5.checkImage.gameObject.SetActive(true);
                        objective6.checkImage.gameObject.SetActive(true);
                        break;
                    case "clot":
                        objective5.checkImage.gameObject.SetActive(true);
                        objective6.checkImage.gameObject.SetActive(true);
                        objective7.checkImage.gameObject.SetActive(true);
                        break;
                }
                break;
            case "c":
                Objective objective8 = Instantiate(objectivePrefab, childpanel.transform);
                Objective objective9 = Instantiate(objectivePrefab, childpanel.transform);
                objective8.objectiveText.text = "Burn";
                objective9.objectiveText.text = "Ern";
                switch (objective)
                {
                    case "not":
                        print("not");
                        break;
                    case "burn":
                        objective8.checkImage.gameObject.SetActive(true);
                        break;
                    case "ern":
                        objective8.checkImage.gameObject.SetActive(true);
                        objective9.checkImage.gameObject.SetActive(true);
                        break;
                }
                break;
            case "a":
                Objective objective10 = Instantiate(objectivePrefab, childpanel.transform);
                Objective objective11 = Instantiate(objectivePrefab, childpanel.transform);
                Objective objective12 = Instantiate(objectivePrefab, childpanel.transform);
                objective10.objectiveText.text = "Massage";
                objective11.objectiveText.text = "Alkaline Hydrolysis";
                objective12.objectiveText.text = "Ern";
                switch (objective)
                {
                    case "not":
                        print("not");
                        break;
                    case "mass":
                        objective10.checkImage.gameObject.SetActive(true);
                        break;
                    case "alka":
                        objective10.checkImage.gameObject.SetActive(true);
                        objective11.checkImage.gameObject.SetActive(true);
                        break;
                    case "ern":
                        objective10.checkImage.gameObject.SetActive(true);
                        objective11.checkImage.gameObject.SetActive(true);
                        objective12.checkImage.gameObject.SetActive(true);
                        break;
                }
                break;
            case "v":
                Objective objective13 = Instantiate(objectivePrefab, childpanel.transform);
                Objective objective14 = Instantiate(objectivePrefab, childpanel.transform);
                Objective objective15 = Instantiate(objectivePrefab, childpanel.transform);
                Objective objective16 = Instantiate(objectivePrefab, childpanel.transform);
                objective13.objectiveText.text = "Wash";
                objective14.objectiveText.text = "Massage";
                objective15.objectiveText.text = "Cloth";
                objective16.objectiveText.text = "Raft";
                switch (objective)
                {
                    case "not":
                        break;
                    case "wash":
                        objective13.checkImage.gameObject.SetActive(true);
                        break;
                    case "mass":
                        objective13.checkImage.gameObject.SetActive(true);
                        objective14.checkImage.gameObject.SetActive(true);
                        break;
                    case "clot":
                        objective13.checkImage.gameObject.SetActive(true);
                        objective14.checkImage.gameObject.SetActive(true);
                        objective15.checkImage.gameObject.SetActive(true);
                        break;
                    case "raft":
                        objective13.checkImage.gameObject.SetActive(true);
                        objective14.checkImage.gameObject.SetActive(true);
                        objective15.checkImage.gameObject.SetActive(true);
                        objective16.checkImage.gameObject.SetActive(true);
                        break;
                }
                break;
        }
    }

    public void DeleteObjectives()
    {
        int childs = childpanel.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(childpanel.transform.GetChild(i).gameObject);
        }
    }
}
