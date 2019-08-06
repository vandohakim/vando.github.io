package com.kodingindonesia.mycrud;

public class konfigurasi {

    //Dibawah ini merupakan Pengalamatan dimana Lokasi Skrip CRUD PHP disimpan
    //Pada tutorial Kali ini, karena kita membuat localhost maka alamatnya tertuju ke IP komputer
    //dimana File PHP tersebut berada
    //PENTING! JANGAN LUPA GANTI IP SESUAI DENGAN IP KOMPUTER DIMANA DATA PHP BERADA
    public static final String URL_ADD= "http://140.115.158.239/Android/HW2/tambahData.php";
    public static final String URL_GET_ALL = "http://140.115.158.239/Android/HW2/tampilSemuaData.php";
    public static final String URL_GET_EMP = "http://140.115.158.239/Android/HW2/tampilData.php?id=";
    public static final String URL_UPDATE_EMP = "http://140.115.158.239/Android/HW2/updateData.php";
    public static final String URL_DELETE_EMP = "http://140.115.158.239/Android/HW2/hapusData.php?id=";

    //Dibawah ini merupakan Kunci yang akan digunakan untuk mengirim permintaan ke Skrip PHP
    public static final String KEY_EMP_ID = "id";
    public static final String KEY_EMP_NAME = "name";
    public static final String KEY_EMP_AGE = "age"; //desg itu variabel untuk posisi
    public static final String KEY_EMP_WEIGHT = "weight"; //salary itu variabel untuk gajih
    public static final String KEY_EMP_HEIGHT = "height"; //desg itu variabel untuk posisi
    public static final String KEY_EMP_GENDER = "gender"; //salary itu variabel untuk gajih
    public static final String KEY_EMP_BMR = "bmr"; //desg itu variabel untuk posisi
    public static final String KEY_EMP_BMI = "bmi"; //salary itu variabel untuk gajih

    //JSON Tags
    public static final String TAG_JSON_ARRAY="result";
    public static final String TAG_ID = "id";
    public static final String TAG_NAME = "name";
    public static final String TAG_AGE = "age";
    public static final String TAG_WEIGHT = "weight";
    public static final String TAG_HEIGHT = "height";
    public static final String TAG_GENDER = "gender";
    public static final String TAG_BMR = "bmr";
    public static final String TAG_BMI = "bmi";

    //ID karyawan
    //emp itu singkatan dari Employee
    public static final String EMP_ID = "emp_id";
}
