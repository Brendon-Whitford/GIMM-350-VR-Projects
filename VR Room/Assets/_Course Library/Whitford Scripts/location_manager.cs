using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class location_manager : MonoBehaviour
{
    [SerializeField]
    Transform leftHandCube;
    [SerializeField]
    Transform rightHandCube;
    [SerializeField]
    Transform headCube;
    [SerializeField]
    bool isRecording = false;
    [SerializeField]
    List<Vector3> posOverTime;
    [SerializeField]
    XRPositions positions;
    [SerializeField]
    float timeMeasurementAmt;
    [SerializeField]
    float timer;
    /*[SerializeField]
    Vector3[] positionsOverTime;
    [SerializeField]
    int maxValues = 100;
    int indexCurrent = 0;*/

 /*   void doubleArrayAmt(
        {
            maxValues *= 2;
            var oldPos = positionsOverTime;
            positionsOverTime = new Vector3[maxValues];
            int i = 0;
            int indexCurrent;
            foreach(Vector3 a in oldPos)
            {
                positionsOverTime[i] = oldPos[i];
                i++;
            }
        }

    )*/
    // Start is called before the first frame update
    void Start()
    {
        positions = new XRPositions();
        positions.headPos = headCube.transform.position;
        positions.leftHandPos = leftHandCube.transform.position;
        positions.rightHandPos = rightHandCube.transform.position;
        posOverTime = new List<Vector3>();
        timer = timeMeasurementAmt;

    }

    public void StartRecording()
    {
        isRecording = true;
    }

    public void StopRecording()
    {
        isRecording = false;
    }
    /*{
        positionsOverTime = new Vector3[maxValues];
        if (indexCurrent > maxValues)
        {
            doubleArrayAmt();
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(isRecording && timer < 0){
        addToList();
        timer = timeMeasurementAmt;

        }
    }

    void addToList()
    {
        XRPositions newPositions = new XRPositions(leftHandCube.position, rightHandCube.position, headCube.position);
    }
}
