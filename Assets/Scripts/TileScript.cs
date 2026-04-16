using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour, IPointerDownHandler
{
    private bool isRotate = true;

    public bool isTruePath;
    public int trueRotation;

    private void Start()
    {
        gameObject.transform.Rotate(0, 0, 90);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RotateTile();
    }

    public void RotateTile()
    {
        if (IsRotate)
        {
            gameObject.transform.Rotate(0, 0, 90);
            if (gameObject.transform.rotation.eulerAngles.z == trueRotation && isTruePath == true)
            {
                IsRotate = false;
            }
        }
    }

    public bool IsRotate {  get { return isRotate; } set { isRotate = value; } }
}
