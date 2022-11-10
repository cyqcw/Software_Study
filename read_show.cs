using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Text;
using System.Data;
using System;
using TMPro;


//  
public class read_show : MonoBehaviour{
    public string user_string;
    public string[][] my_Strings;   //  存放读取的数组
    public TextMeshProUGUI TEXT; //  用来显示用户数据
    public string backup_TEXT;
    public string PATH="test.csv";
    public string user_data;    // 
    // Start is called before the first frame update
    void Start(){
        user_data=DateTime.Now.Year+"."+DateTime.Now.Month+"."+DateTime.Now.Day;
        backup_TEXT="ID\t\t\tTime\t\t\tUsername\t\t\tPassword\n\n";
        TEXT.text=backup_TEXT;
        Debug.Log("read_show : "+user_data);
        read_csv();
    }

    // Update is called once per frame

    //  读取csv
    public void read_csv(){
        string[] csv_lines=File.ReadAllLines(PATH);   //  读完所有行
        string[] key_name=csv_lines[0].Split(',');  //  读第一行的关键字
        //  读下面的行
        for(int i=1;i<csv_lines.Length;i++){
            string[] each_line=csv_lines[i].Split(','); //  each_line分割
            if(each_line[1]==user_data){    //  找到符合条件时间登录的行
                Debug.Log(csv_lines[i]);
                for(int j=0;j<each_line.Length;j++){
                    backup_TEXT+=each_line[j]+"\t\t";   //  格式化
                }backup_TEXT+="\n";
            }TEXT.text=backup_TEXT;
        }
    }
}
