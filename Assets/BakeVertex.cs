using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeVertex : MonoBehaviour {

    public Color customShadowColor;
    public Color customSkyBoxColor;
    [Range( 0.5f,100.0f )]
    public float Distance=0.5f;
    [Range( 35.0f , 135.0f )]
    public float Angle=90.0f;




    public bool useCustomShadowColor = true;
    public bool useCustomSkyBoxColor = true;
    public bool AvergeHardEdge = false;


    public void BakeVertexMainFuntion( )
    {
        //   VertexDirtSettingsStruct

        VertexDirt.settings.samplingAngle = Angle;
        VertexDirt.settings.samplingDistance = Distance;

        VertexDirt.settings.customShadowColor = customShadowColor;

        VertexDirt.settings.customSkyColor = customSkyBoxColor;

        VertexDirt.settings.useCustomShadowColor = useCustomShadowColor;
        VertexDirt.settings.useCustomSkyColor = useCustomSkyBoxColor;

        VertexDirt.settings.edgeSmooth = AvergeHardEdge;
        foreach ( Transform t in transform )
            DestroyImmediate( t.GetComponent<VDColorHandler>( ) );


        VertexDirt.Dirt( GetComponentsInChildren<Transform>( ) );

    }
}
