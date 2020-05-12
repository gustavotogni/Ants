using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{

    public float energy;
    public float health;

    private float moveToX;
    private float moveToZ;

    private float barDisplay = 0;
    private Vector2 size = new Vector2(30,5);    
    private GUIStyle guiStyleEmpty;
    private GUIStyle guiStyleFull;

    void Start()
    {    
        energy = 10.0f;
        health = 100.0f;
    }

    void Update()
    {
        barDisplay = Time.time * 0.05f;
    }

    void FixedUpdate()
    {
        Roam();
    }

    void OnCollisionEnter(Collision collision) 
    {        
        choseScoutingPoint();
    }

    void OnGUI()
    {
        if (guiStyleFull == null) {
            guiStyleFull = new GUIStyle( GUI.skin.box );
            guiStyleFull.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 0.5f ) );
        }
        
        if (guiStyleEmpty == null) {
            guiStyleEmpty = new GUIStyle( GUI.skin.box );
            guiStyleEmpty.normal.background = MakeTex( 2, 2, new Color( 1f, 0f, 0f, 0.5f ) );
        }
    
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        GUI.BeginGroup (new Rect (screenPoint.x, screenPoint.y, size.x, size.y));
            GUI.Box (new Rect (0,0, size.x, size.y), "", guiStyleEmpty);
    
            GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
                GUI.Box (new Rect (0,0, size.x, size.y), "", guiStyleFull);
            GUI.EndGroup ();
        GUI.EndGroup (); 
    }

    void Roam() {
        transform.position += moveToX * transform.forward * Time.deltaTime;
        transform.position += moveToZ * transform.right * Time.deltaTime;
    }

    private Texture2D MakeTex( int width, int height, Color col )
    {
        Color[] pix = new Color[width * height];
        for( int i = 0; i < pix.Length; ++i )
        {
            pix[ i ] = col;
        }
        Texture2D result = new Texture2D( width, height );
        result.SetPixels( pix );
        result.Apply();
        return result;
    }

    void choseScoutingPoint() {                
        if (moveToX != 0) {
            moveToX = moveToX * - 1;
        } else {
            moveToX = 1.0f;
        }        
        
        if (moveToZ != 0) {
            moveToZ = moveToZ * - 1;
        } else {
            moveToZ = 1.0f;
        }           
    }
}