using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture DefaultCursor;
    private Texture m_CurrentCursor;
    private bool m_Navigating;
    public Color m_MouseOverColor = Color.green;
    private Color m_CurrentCursorColor;
    
    void Start()
    {
        Cursor.visible=false;
        m_CurrentCursor=DefaultCursor;
        m_CurrentCursorColor=Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        m_Navigating = Input.GetButton("Horizontal") ||
         Input.GetButton("Vertical");
    }
    public void CursorColorChange(bool colorize){
        m_CurrentCursorColor = colorize ? m_MouseOverColor : Color.white;
    }
    

    void OnGUI(){
        
        if(!m_Navigating){
            Vector3 position = Input.mousePosition;
            Color guiColor = GUI.color;
            GUI.color = m_CurrentCursorColor;
            GUI.DrawTexture(
                new Rect(position.x, Screen.height-position.y, 32f,32f),
                m_CurrentCursor
            );
            GUI.color=guiColor;
        }
    }
}
