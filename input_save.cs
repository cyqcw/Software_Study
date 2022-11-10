using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Xml;
using System;
using System.Data;
using System.Text;

//  加在button上，实现文本获取，和文本写入

public class input_save : MonoBehaviour{
    public TMP_InputField Name;
    public TMP_InputField Password;
    public string user_time;
    public string user_string;  //  要写入的string

    public string PATH="test.csv"; //  写入文件地址，相对路径，不同于Application.dataPATH+
    
    public int len;
    public string str_len;

    public void Start(){
        // //  先获取一下文件
        // StreamWriter MY_CSV;
        // if(!File.Exists(PATH)){ //  不存在就创建
        //     MY_CSV=File.CreateText(PATH);
        // }else{
        //     MY_CSV=File.AppendText(PATH);
        // }
        // string[] CSV_LINES=File.ReadAllLines(PATH);   //  读完所有行,目的是为了写入文件时用该索引
        // MY_CSV.Close();
        // MY_CSV.Dispose();

        len=99999;

        str_len=len.ToString();
        Debug.Log(str_len);
    }

    public void Update(){
        OnClick();  //  要一直更新
    }

    public void OnClick(){
        user_time=DateTime.Now.Year+"."+DateTime.Now.Month+"."+DateTime.Now.Day;
        user_string=str_len+","+user_time+","+Name.text+","+Password.text; //   str_len加上
        Debug.Log(user_string); //在Console输出当前账号
    }

    public void OnDestroy(){    //  关闭前最后一帧写入
        writeCSV(user_string,PATH);
    }

    //  文件写入函数
    public void writeCSV(string userString,string PATH){
        StreamWriter MY_CSV;
        if(!File.Exists(PATH)){ //  不存在就创建
            MY_CSV=File.CreateText(PATH);
            Debug.Log("input_save : File not exist, start create write");
        }else{
            Debug.Log("input_save : File exist, start write ! ");
            MY_CSV=File.AppendText(PATH);
        }
        
        MY_CSV.WriteLine(userString);
        MY_CSV.Close();
        MY_CSV.Dispose();
    }
}
