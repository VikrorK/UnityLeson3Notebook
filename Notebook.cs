using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notebook : MonoBehaviour
{
    public GameObject notebookObject; //Дневник
    private bool openNotebook = false; //условие открыт ли дневник
    public CursorsLook _cursorLook; //скрипт отключения/включения курсора
    public Text textUI; //текст дневника
    public InputField inpF; //поле ввода текста
    private int countS=0; //счетчик

        void Start()
    {
       openNotebook = false;//устанавливаем, что дневник закрыт
       notebookObject.SetActive(false); //отключем дневник
    }

    // Update is called once per frame
    void Update()
    {
        if(openNotebook==true)//если дневник открыт
        {  
            _cursorLook.CursorFalse();//включаем курсор и отключаем контроллер
            

            if(Input.GetKeyDown(KeyCode.Return)){//если нажади ENTER
            AddRecord();//добавляем запись
        }
        }
        else if (openNotebook==false)//если дневник закрыт
        {
             
            if(Input.GetKeyDown(KeyCode.J)){//если нажали кнопку J
                notebookObject.SetActive(true);//открываем дневник
                openNotebook = true;//устанавливаем занчение, что дневник открыт
                inpF.Select();//фокусируемся(выделяем) текстовое поле для записи
                
            }
        }
    }
    //закрытие дневника
    public void CloseNotebook(){
        notebookObject.SetActive(false);//отключаем дневник
        openNotebook = false;//устанавливаем занчение, что дневник закрыт
        _cursorLook.CursorTrue(); //отключаем курсор и включаем контроллер
        
    }
    //добавление записи
    public void AddRecord()
    {
        countS+=1;//прибавлем к счетчику 1
        textUI.text=textUI.text+"\n"+countS+". "+inpF.text;//вводим новый текст с новой строки и с выводом счетчика
        inpF.text=null;//очищаем текствовое поле
        inpF.Select();//фокусируемся(выделяем) текстовое поле для записи
       
    }
}
