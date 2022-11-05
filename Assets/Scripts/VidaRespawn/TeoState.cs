using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TeoState
{
    //public static string player = "";
    //public static string nick = "";
    public static int resp = 0;
    public static float nslow = 0;
    public static int vidas = 5;
    //public static float xp = 0f;
    static float xD = 0f;
    static float yD = 1.5f;
    static float zD = 0f;
    public static Vector3 position = new Vector3(xD, yD, zD);
    public static Vector3 hposition = new Vector3(0, 0, 0);

    public static void SavePrefs()
    {
        PlayerPrefs.Save();
        SetPrefs();
    }

    public static void SetPrefs()
    {
        //PlayerPrefs.SetString("player", player);
        // PlayerPrefs.SetString("nick", nick);
        PlayerPrefs.SetInt("resp", resp);
        PlayerPrefs.SetFloat("nslow", nslow);
        PlayerPrefs.SetInt("lives", vidas);
        //PlaterPrefs.SetBool("ressp", resp);
        //PlaterPrefs.SetBool("resf", resf);
        //PlayerPrefs.SetFloat("xp", xp);
        PlayerPrefs.SetFloat("posx", position.x);
        PlayerPrefs.SetFloat("posy", position.y);
        PlayerPrefs.SetFloat("posz", position.z);
        PlayerPrefs.Save();
    }

    public static void SetPrefs(int vidas, int resp, float nslow, Vector3 position, Vector3 hposition)
    {
        //Prefs.player = player;
        //Prefs.nick = nick;
        TeoState.resp = resp;
        TeoState.nslow = nslow;
        TeoState.vidas = vidas;
        //Prefs.xp = xp;
        TeoState.position = position;
        TeoState.hposition = hposition;
        SavePrefs();
    }

    public static void LoadPrefs()
    {
        if (PlayerPrefs.HasKey("player"))
        {
            //player = PlayerPrefs.GetString("player");
            //nick = PlayerPrefs.GetString("nick");
            resp = PlayerPrefs.GetInt("resp");
            nslow = PlayerPrefs.GetFloat("nslow");
            vidas = PlayerPrefs.GetInt("lives");
            //xp = PlayerPrefs.GetFloat("xp");
            float x = PlayerPrefs.GetFloat("posx");
            float y = PlayerPrefs.GetFloat("posy");
            float z = PlayerPrefs.GetFloat("posz");
            position = new Vector3(x, y, z);
            hposition = new Vector3(x, y, z);
        }
    }

    //public static void ShowPrefs()
    //{
    //MonoBehaviour.print("player:" + player);
    //MonoBehaviour.print("nick:" + nick);
    //MonoBehaviour.print("nivel:" + lvl);
    //MonoBehaviour.print("vidas:" + vidas);
    //MonoBehaviour.print("xp:" + xp);
    //MonoBehaviour.print("posicion:" + position);
    //}
}

