using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class PointsManager : MonoBehaviour
{
    static public int points = 0;
    public int idVariavelGlobal=0;
    static public GVar variavelGlobal;
    public enum cores{Incompleto,Facil,Minimo,Dificil,Extremo}
    
    static public bool perdeu = false;

    static public cores fase = 0;
    
    void Start()
    {
        variavelGlobal= GlobalVariables.GetVariable(0,true);
    }

    
    static public void Ganhou(int gamePoint){
        points+=gamePoint;
        variavelGlobal.IntegerValue=points;
    }
    static public void Perdeu(int gamePoint){
        points-=gamePoint;
        variavelGlobal.IntegerValue=points;
    }

    private void OnEnable ()
	{
		EventManager.OnDownloadVariable += OnDownload;
		EventManager.OnUploadVariable += OnUpload;
	}

	private void OnDisable ()
	{
		EventManager.OnDownloadVariable -= OnDownload;
		EventManager.OnUploadVariable -= OnUpload;
	}

	private void OnDownload (GVar variable, Variables variables)
	{
        
		if (variable.id == idVariavelGlobal)
		{
			variable.IntegerValue = points;
		}
	}

	private void OnUpload (GVar variable, Variables variables)
	{
        
		if (variable.id == idVariavelGlobal)
		{
			points = variable.IntegerValue;
		}
	}

}
