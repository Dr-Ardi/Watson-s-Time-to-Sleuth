using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class CameraTransformData
{
    public Vector3Data position;
    public Vector3Data rotation;

    public CameraTransformData(Vector3Data position, Vector3Data rotation)
    {
        this.position = position;
        this.rotation = rotation;
    }
}

[Serializable]
public class Vector3Data
{
    public float x;
    public float y;
    public float z;

    public Vector3Data(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(
            x,
            y,
            z
        );
    }
}

[Serializable]
public class CameraPositionsWrapper
{
    public Dictionary<string, CameraTransformData> positions;
}

public class CameraPositionManager : MonoBehaviour
{
    public static CameraPositionManager Instance;

    private Dictionary<string, CameraTransformData> cameraPositions;

    void Awake()
    {
        Instance = this;
        // LoadCameraPositions();
    }

    void LoadCameraPositions()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("camera"); 
        CameraPositionsWrapper wrapper = JsonUtility.FromJson<CameraPositionsWrapper>(jsonFile.text);
        cameraPositions = wrapper.positions;
        Debug.Log(cameraPositions);
    }

    public void MoveCameraTo(string locationKey, Camera camera)
    {
        // if (cameraPositions == null)
        // {
        //     Debug.LogError("Camera positions not loaded.");
        //     return;
        // }

        // if (!cameraPositions.ContainsKey(locationKey))
        // {
        //     Debug.LogWarning("Camera position not found for key: " + locationKey);
        //     return;
        // }

        // var data = cameraPositions[locationKey];
        // Vector3Data position1 = new Vector3Data
        // {
        //     x = "-57",
        //     y = "94",
        //     z = "-402"
        // };
        // Vector3Data rotation1 = new Vector3Data
        // {
        //     x = "30",
        //     y = "0",
        //     z = "0"
        // };

        // if (locationKey == "221b_bed_room_john")
        // {
        //     position1 = new Vector3Data
        //     {
        //         x = "100",
        //         y = "94",
        //         z = "-402"
        //     };
        //     rotation1 = new Vector3Data
        //     {
        //         x = "30",
        //         y = "0",
        //         z = "0"
        //     };
        // }

        // CameraTransformData data = new CameraTransformData
        // {
        //     position = position1,
        //     rotation = rotation1
        // };

        Vector3Data position = new Vector3Data(
            float.Parse("-57"),
            float.Parse("94"),
            float.Parse("-402")
        );

        Vector3Data rotation = new Vector3Data(
            float.Parse("30"),
            float.Parse("0"),
            float.Parse("0")
        );

        if (locationKey == "221b_bed_room_john")
        {
            position = new Vector3Data(
                450,
                94,
                -402
            );
            rotation = new Vector3Data(
                30,
                0,
                0
            );
        }

        if (locationKey == "221b_bed_room_sherlock")
        {
            position = new Vector3Data(
                71,
                96,
                -108
            );
            rotation = new Vector3Data(
                30,
                0,
                0
            );
        }

        if (locationKey == "one")
        {
            position = new Vector3Data(
                346,
                239,
                -533
            );
            rotation = new Vector3Data(
                20,
                0,
                0
            );
        }

        if (locationKey == "two")
        {
            position = new Vector3Data(
                -356,
                239,
                -533
            );
            rotation = new Vector3Data(
                20,
                0,
                0
            );
        }

        if (locationKey == "three")
        {
            position = new Vector3Data(
                -930,
                239,
                -533
            );
            rotation = new Vector3Data(
                20,
                0,
                0
            );
        }

        if (locationKey == "four")
        {
            position = new Vector3Data(
                -1822,
                239,
                -533
            );
            rotation = new Vector3Data(
                20,
                0,
                0
            );
        }

        if (locationKey == "five")
        {
            position = new Vector3Data(
                1179,
                239,
                -533
            );
            rotation = new Vector3Data(
                20,
                0,
                0
            );
        }

        camera.transform.position = position.ToVector3();
        camera.transform.rotation = Quaternion.Euler(rotation.ToVector3());
    }

}
