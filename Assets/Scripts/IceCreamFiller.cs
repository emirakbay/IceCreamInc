using System.Collections;
using UnityEngine;

public class IceCreamFiller : MonoBehaviour
{
    public BezierCurve curve;

    public float percentIncrease;
    public float iceCreamPartMovementTime;
    public float currentPercent;

    public int creamPieceNumber;
    public GameObject iceCreamPart;

    private void Awake()
    {
        creamPieceNumber = 0;
    }

    public void CreateWhiteIceCreamPart()
    {
        var iceCreamGo = Instantiate(iceCreamPart, transform.position, Quaternion.identity);
        creamPieceNumber++;
        Debug.Log(creamPieceNumber);
        StartCoroutine(MoveObjectToPosition(iceCreamPartMovementTime, iceCreamGo, curve.GetPointAt(currentPercent)));
        currentPercent += percentIncrease;
    }

    public void CreateChocolateCreamPart()
    {
        var iceCreamGo = Instantiate(iceCreamPart, transform.position, Quaternion.identity);
        creamPieceNumber++;
        Debug.Log(creamPieceNumber);
        ChangeCreamColor(iceCreamGo);
        StartCoroutine(MoveObjectToPosition(iceCreamPartMovementTime, iceCreamGo, curve.GetPointAt(currentPercent)));
        currentPercent += percentIncrease;
    }

    private IEnumerator MoveObjectToPosition(float time, GameObject go, Vector3 destination)
    {
        float timer = 0;
        Transform objTransform = go.transform;

        while (timer < time)
        {
            timer += Time.deltaTime;
            objTransform.position = Vector3.Lerp(objTransform.position, destination, timer / time);
            yield return null;
        }
    }

    private void ChangeCreamColor(GameObject obj)
    {
        var temp = obj.GetComponent<Renderer>();
        temp.material.color = new Color(0.4509804F, 0.227451F, 0F);
    }
}
