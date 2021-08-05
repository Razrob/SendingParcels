using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class ParcelData
{
    public string senderName { get; private set; }
    public string senderAddress { get; private set; } 
    public string senderPostcode { get; private set; }

    public string recipientName { get; private set; }
    public string recipientAddress { get; private set; }
    public string recipientPostcode { get; private set; }
     
    public string mass { get; private set; }
    public string value { get; private set; }
    public string scale { get; private set; }
    public string date { get; private set; }
    public string code { get; private set; }
    public bool mark { get; private set; } = true;
    public bool stump { get; private set; } = true;

    public bool isCorrect { get; private set; } = true;

    public void GenerateData(ParcelSize parcelSize, int hardLevel)
    { 
        int senderGenderIndex = Random.Range(0, 2);
        int recipientGenderIndex = Random.Range(0, 2);

        senderName = Data.names[senderGenderIndex, 0, Random.Range(0, Data.namesNumber[senderGenderIndex])] + 
            " " + Data.names[senderGenderIndex, 1, Random.Range(0, Data.namesNumber[senderGenderIndex])] + 
            " " + Data.names[senderGenderIndex, 2, Random.Range(0, Data.namesNumber[senderGenderIndex])];


        if (hardLevel > 0 && GetRandomResult(5))
        { 
            if (Random.Range(0, 2) == 0) senderName = senderName.Substring(senderName.IndexOf(" "));
            else senderName = senderName.Substring(senderName.LastIndexOf(" "));
        }
        if (hardLevel > 0 && GetRandomResult(3)) senderName = ""; 

        recipientName = Data.names[recipientGenderIndex, 0, Random.Range(0, Data.namesNumber[recipientGenderIndex])] + 
            " " + Data.names[recipientGenderIndex, 1, Random.Range(0, Data.namesNumber[recipientGenderIndex])] + 
            " " + Data.names[recipientGenderIndex, 2, Random.Range(0, Data.namesNumber[recipientGenderIndex])];


        if (hardLevel > 0 && GetRandomResult(5))
        { 
            if (Random.Range(0, 2) == 0) recipientName = recipientName.Substring(recipientName.IndexOf(" "));
            else recipientName = recipientName.Substring(recipientName.LastIndexOf(" "));
        }
        if (hardLevel > 0 && GetRandomResult(3)) recipientName = "";




        if (hardLevel > 1 && GetRandomResult(8))
        { 
            int countryIndex = Random.Range(0, Data.allImpossibleCountries.Length);
            senderAddress = Data.allImpossibleCountries[countryIndex] + ", г. ";
            countryIndex = Random.Range(0, Data.allPossibleCountries.Length);
            senderAddress += Data.allAddresses[countryIndex, 0][Random.Range(0, Data.adressesLength[countryIndex])] + "\nул. " + Data.allAddresses[countryIndex, 1][Random.Range(0, Data.adressesLength[countryIndex])] + " дом " + Random.Range(1, 25) + " кв. " + Random.Range(1, 350);
        }
        else
        {
            int countryIndex;
            if (hardLevel > 1 && GetRandomResult(10))
            {
                countryIndex = Random.Range(1, Data.allPossibleCountries.Length);
            }
            else countryIndex = 0;
            senderAddress = Data.allPossibleCountries[countryIndex] + ", г. ";
            senderAddress += Data.allAddresses[countryIndex, 0][Random.Range(0, Data.adressesLength[countryIndex])] + "\nул. " + Data.allAddresses[countryIndex, 1][Random.Range(0, Data.adressesLength[countryIndex])] + " дом " + Random.Range(1, 25) + " кв. " + Random.Range(1, 350);
        }
        if (hardLevel > 1 && GetRandomResult(3)) senderAddress = "";

        if (hardLevel > 1 && GetRandomResult(8))
        { 
            int countryIndex = Random.Range(0, Data.allImpossibleCountries.Length);
            recipientAddress = Data.allImpossibleCountries[countryIndex] + ", г. ";
            countryIndex = Random.Range(0, Data.allPossibleCountries.Length);
            recipientAddress += Data.allAddresses[countryIndex, 0][Random.Range(0, Data.adressesLength[countryIndex])] + "\nул. " + Data.allAddresses[countryIndex, 1][Random.Range(0, Data.adressesLength[countryIndex])] + " дом " + Random.Range(1, 25) + " кв. " + Random.Range(1, 350);
        }
        else
        {
            int countryIndex = Random.Range(0, Data.allPossibleCountries.Length);
            recipientAddress = Data.allPossibleCountries[countryIndex] + ", г. ";
            recipientAddress += Data.allAddresses[countryIndex, 0][Random.Range(0, Data.adressesLength[countryIndex])] + "\nул. " + Data.allAddresses[countryIndex, 1][Random.Range(0, Data.adressesLength[countryIndex])] + " дом " + Random.Range(1, 25) + " кв. " + Random.Range(1, 350);
        }
        if (hardLevel > 1 && GetRandomResult(3)) recipientAddress = "";

         

        if (hardLevel > 2 && GetRandomResult(5)) senderPostcode = Random.Range((int)Mathf.Pow(10, Random.Range(1, 4)), (int)Mathf.Pow(10, Random.Range(1, 5))).ToString();
        else senderPostcode = Random.Range(100, 1000).ToString() + Random.Range(100, 1000).ToString();

        if (hardLevel > 2 && GetRandomResult(3)) senderPostcode = "";
      

        if (hardLevel > 2 && GetRandomResult(5))  recipientPostcode = Random.Range((int)Mathf.Pow(10, Random.Range(1, 4)), (int)Mathf.Pow(10, Random.Range(1, 5))).ToString();
        else recipientPostcode = Random.Range(100, 1000).ToString() + Random.Range(100, 1000).ToString();

        if (hardLevel > 2 && GetRandomResult(3))  recipientPostcode = "";



        if (hardLevel > 3 && GetRandomResult(5)) code = Random.Range(0, (int)Mathf.Pow(10, Random.Range(0, 3))) + "-" + Random.Range(0, (int)Mathf.Pow(10, Random.Range(0, 3))) + "-" + Random.Range(0, (int)Mathf.Pow(10, Random.Range(0, 3)));
        else code = Random.Range(1000, 10000) + "-" + Random.Range(1000, 10000) + "-" + Random.Range(1000, 10000); 
        if (hardLevel > 3 && GetRandomResult(3)) code = "";
        

        mass = (Random.Range((int)parcelSize, (int)parcelSize * 8) * 10).ToString();
        if (hardLevel > 4 && GetRandomResult(6))
        {
            int index = Random.Range(0, 3);
            if (index == 0) mass = "";
            else if(index == 1) mass = (Random.Range(-1, 1) * Random.Range(10, 45) * 10).ToString();
            else (Random.Range(-(int)parcelSize, (int)parcelSize) * 10).ToString();
        }

        value = (Random.Range(9, 500) * 10 + 9 + 0.5f).ToString();
        if (hardLevel > 4 && GetRandomResult(6))
        {
            if (Random.Range(0, 2) == 0) value = "";
            else value = (Random.Range(-1, 1) * Random.Range(10, 45) * 10).ToString();
        }

        scale = parcelSize.ToString();
        if (hardLevel > 5 && GetRandomResult(6))
        {
            ParcelSize tempParcelSize = (ParcelSize)Enum.GetValues(typeof(ParcelSize)).GetValue(Random.Range(0, 3)); 
            while (tempParcelSize == parcelSize)
            {
                tempParcelSize = (ParcelSize)Enum.GetValues(typeof(ParcelSize)).GetValue(Random.Range(0, 3)); 
            } 
            scale = tempParcelSize.ToString();  
        }
         
        if (hardLevel > 5 && GetRandomResult(3)) scale = "";

        date = CurrentDate.GetDate();
        if (hardLevel > 5 && GetRandomResult(5))
        {
            if (Random.Range(0, 2) == 0) date = "";
            else
            {
                string str;
                switch(Random.Range(0, 3))
                { 
                    case 0:
                        date = date.Remove(0, 2);
                        str = Random.Range(1, 32).ToString();
                        if (str.Length == 1) str = str.Insert(0, "0");
                        date = date.Insert(0, str);
                        break;
                    case 1:
                        date = date.Remove(3, 2);
                        str = Random.Range(1, 12).ToString();
                        if (str.Length == 1) str = str.Insert(0, "0");
                        date = date.Insert(3, str);
                        break;
                    case 2:
                        date = date.Remove(6, 4);
                        date = date.Insert(6, Random.Range(1980, 2030).ToString());
                        break;
                }
            }
        }

        if (hardLevel > 6 && GetRandomResult(5)) mark = false;
        if (hardLevel > 7 && GetRandomResult(5)) stump = false;

    }
     
    private bool GetRandomResult(float probability)
    {
        if (Random.Range(0.01f, 100f) <= probability)
        {
            isCorrect = false;
            return true;
        }
        return false;
    }
   

}

public static class Data
{

    public static string[,,] names = new string[,,]
    {//male
        {
            { "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Соколов", "Михайлов", "Новиков", "Федоров", "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов", "Егоров", "Павлов", "Козлов", "Степанов", "Николаев", "Орлов" },
            { "Абрам", "Александр", "Алексей", "Антон", "Аркадий", "Арсений", "Артем", "Борис", "Вадим", "Валерий", "Григорий", "Олег", "Максим", "Данил", "Дмитрий", "Ашот", "Геннадий", "Виктор", "Константин", "Игнат", "Иван" },
            { "Евгеньевич", "Иванович", "Игоревич", "Валерьевич", "Миронович", "Артемович", "Борисович", "Олегович", "Александрович", "Максимович", "Данилович", "Никитович", "Павлович", "Константинович", "Романович", "Семенович", "Сергеевич", "Степанович", "Федорович", "Янович", "Геннадьевич" }
    },//female
        {
            { "Иванова", "Смирнова", "Кузнецова", "Попова", "Васильева", "Петрова", "Соколова", "Михайлова", "Новикова", "Федорова", "Морозова", "Волкова", "Алексеева", "Лебедева", "Семенова", "Егорова", "Павлова", "Козлова", "Степанова", "Николаева", "Орлова" },
            { "Лариса", "Анастасия", "Светлана", "Надежда", "Виктория", "Ольга", "Валерия", "Жанна", "Ирина", "Юлия", "Валентина", "Елена", "Татьяна", "Оксана", "Варвара", "Галина", "Александра", "Евгения", "Карина", "София", "Ангелина" },
            { "Евгеньевна", "Ивановна", "Игоревна", "Валерьевна", "Мироновна", "Артемовна", "Борисовна", "Олеговна", "Александровна", "Максимовна", "Даниловна", "Никитовна", "Павловна", "Константиновна", "Романовна", "Семеновна", "Сергеевна", "Степановна", "Федоровна", "Яновна", "Геннадьевна" }
        }
    };
    public static int[] namesNumber = new int[] { 21, 21 };
     
     
    public static string[] allPossibleCountries = new string[] { "Россия", "Украина", "Беларусь" };
    public static string[] allImpossibleCountries = new string[] { "Германия", "Португалия", "Великобритания", "США", "Канада", "Бразилия", "Китай", "Япония", "Бельгия", "Франция", "Швейцария", "Эстония" };

    public static string[,][] allAddresses = new string[,][]
    {
        //Russian
        { 
            //Cities
            new string[] { "Тюмень", "Сургут", "Владивосток", "Казань", "Сочи", "Санкт-Петербург", "Москва", "Калининград", "Лосино-Петровский", "Краснодар", "Уфа", "Екатеринбург", "Новосибирск", "Нижний Новгород", "Красноярск" },
            //Streets
            new string[] { "Центральная", "Молодежная", "Лесная", "Советская", "Садовая", "Набережная", "Мира", "Ленина", "Октябрьская", "Комсомольская", "Гагарина", "Первомайская", "Кирова", "Нагорная", "Строителей" }
        },
        //Ukraine
        { 
            //Cities
            new string[] { "Донецк", "Киев", "Одесса", "Львов", "Бердянск", "Херсон", "Житомир" },
            //Streets
            new string[] { "Владимирская", "Пушкинская", "Льва Толстого", "Терещенковская", "Садовая", "Институтская", "Соборная" }
        },
        
        //Belarus
        { 
            //Cities
            new string[] { "Минск", "Витебск", "Могилев", "Брест", "Бобруйск", "Гомельг", "Борисов" },
            //Streets
            new string[] { "Ленина", "Замковая", "Суворова", "Комсомольская", "Гоголя", "Толстого", "Пушкина"}
        }
    };
    public static int[] adressesLength = new int[] { 15, 7, 7 };


}