using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public List<GameObject> tilePath;
    public List<GameObject> checkEndList;
    public GameObject character;
    public GameObject menu;

    private bool isGameEnded = false;

    private bool isStopMoving = false;
    private int step = 0;

    void Update()
    {
        CheckGameEnd();
        if (isGameEnded)
        {
            if (!isStopMoving)
            {
                MoveCharacter();
            }
            if (isStopMoving)
            {
                menu.SetActive(true);
            }
        }
    }

    private void CheckGameEnd()
    {
        int checkTile = 0;
        foreach (GameObject go in checkEndList)
        {
            if (go.GetComponent<TileScript>().IsRotate == false)
            {
                checkTile++;
                if (checkTile == checkEndList.Count)
                {
                    isGameEnded = true;
                }
            }
            
        }
    }

    private void MoveCharacter()
    {
        Vector3 targetPosition = new Vector3(tilePath[step].transform.position.x, tilePath[step].transform.position.y + 15, tilePath[step].transform.position.z);
        character.transform.position = Vector3.MoveTowards(character.transform.position, targetPosition, 50 * Time.deltaTime);
        
        character.GetComponent<Animator>().SetBool("IsMoving", true);
        
        if (character.transform.position == targetPosition)
        {
            step++;
            if (step == tilePath.Count)
            {
                isStopMoving = true;

                character.GetComponent<Animator>().SetBool("IsMoving", false);
            }
        }
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(0);
    }
}
