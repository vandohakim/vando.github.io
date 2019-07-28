package com.kodingindonesia.mycrud;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.provider.MediaStore;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.RadioGroup;
import android.app.DatePickerDialog;
import android.widget.DatePicker;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.w3c.dom.Text;

import java.util.HashMap;

public class MainActivity extends AppCompatActivity implements View.OnClickListener{

    //Dibawah ini merupakan perintah untuk mendefinikan View
    private EditText editTextName;
    private EditText editTextAge;
    private EditText editTextWeight;
    private EditText editTextHeight;

    private TextView hasilgender;
    private TextView hasilusia;
    private TextView editTextBmr;
    private TextView editTextBmi;

    private Button buttonClick;
    private Button buttonAdd;
    private Button buttonView;

    private DatePickerDialog datePickerDialog;
    private SimpleDateFormat dateFormatter;
    private TextView tvDateResult;
    private TextView tvDateYearResult;
    private TextView tvhasilUsia;
    private Button btDatePicker;

    private RadioGroup rgGender;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //Inisialisasi dari View
        editTextName = (EditText) findViewById(R.id.editTextName);
        //editTextAge = (EditText) findViewById(R.id.editTextAge);
        editTextWeight = (EditText) findViewById(R.id.editTextWeight);
        editTextHeight = (EditText) findViewById(R.id.editTextHeight);

        editTextBmr = (TextView) findViewById(R.id.editTextBmr);
        editTextBmi = (TextView) findViewById(R.id.editTextBmi);
        hasilgender = (TextView) findViewById(R.id.hasilgender);

        buttonClick = (Button) findViewById(R.id.buttonClick);
        buttonAdd = (Button) findViewById(R.id.buttonAdd);
        buttonView = (Button) findViewById(R.id.buttonView);

        //Setting listeners to button
        buttonClick.setOnClickListener(this);
        buttonAdd.setOnClickListener(this);
        buttonView.setOnClickListener(this);

        dateFormatter = new SimpleDateFormat("dd-MM-yyyy", Locale.US);

        tvDateResult = (TextView) findViewById(R.id.tahun);
        tvDateYearResult = (TextView) findViewById(R.id.tahunlahir);
        tvhasilUsia = (TextView) findViewById(R.id.hasilusia);
        btDatePicker = (Button) findViewById(R.id.buttonDate);
        btDatePicker.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view) {
                showDateDialog();
            }
        });
    }

    private void showDateDialog(){

        final Calendar newCalendar = Calendar.getInstance();
        datePickerDialog = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                Calendar newDate = Calendar.getInstance();
                newDate.set(year, monthOfYear, dayOfMonth);

                tvDateResult.setText("Your Birthday : "+dateFormatter.format(newDate.getTime()));
                tvDateYearResult.setText("Now, your age is : "+ (newCalendar.get(Calendar.YEAR) - year) +" years old");
                tvhasilUsia.setText(""+ (newCalendar.get(Calendar.YEAR) - year) +"");
            }

        },newCalendar.get(Calendar.YEAR), newCalendar.get(Calendar.MONTH), newCalendar.get(Calendar.DAY_OF_MONTH));
        datePickerDialog.show();
    }

    //Dibawah ini merupakan perintah untuk Menambahkan Pegawai (CREATE)
    private void addEmployee(){
        final String name = editTextName.getText().toString().trim();
        final String age = tvhasilUsia.getText().toString().trim();
        final String weight = editTextWeight.getText().toString().trim();
        final String height = editTextHeight.getText().toString().trim();
        final String gender = hasilgender.getText().toString().trim();
        final String bmr = editTextBmr.getText().toString().trim();
        final String bmi = editTextBmi.getText().toString().trim();

        class AddEmployee extends AsyncTask<Void,Void,String>{

            ProgressDialog loading;

            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                loading = ProgressDialog.show(MainActivity.this,"Add...","Wait...",false,false);
            }

            @Override
            protected void onPostExecute(String s) {
                super.onPostExecute(s);
                loading.dismiss();
                Toast.makeText(MainActivity.this,s,Toast.LENGTH_LONG).show();
            }

            @Override
            protected String doInBackground(Void... v) {
                HashMap<String,String> params = new HashMap<>();
                params.put(konfigurasi.KEY_EMP_NAME,name);
                params.put(konfigurasi.KEY_EMP_AGE,age);
                params.put(konfigurasi.KEY_EMP_WEIGHT,weight);
                params.put(konfigurasi.KEY_EMP_HEIGHT,height);
                params.put(konfigurasi.KEY_EMP_GENDER,gender);
                params.put(konfigurasi.KEY_EMP_BMR,bmr);
                params.put(konfigurasi.KEY_EMP_BMI,bmi);

                RequestHandler rh = new RequestHandler();
                String res = rh.sendPostRequest(konfigurasi.URL_ADD, params);
                return res;
            }
        }

        AddEmployee ae = new AddEmployee();
        ae.execute();
    }
    private void displayBMI(float bmi) {
        String bmiLabel = "";

        bmiLabel = bmi + bmiLabel;
        editTextBmi.setText(bmiLabel);
    }
    private void displayBMR(float bmr) {
        String bmrLabel = "";

        bmrLabel = bmr + bmrLabel;
        editTextBmr.setText(bmrLabel);
    }
    @Override
    public void onClick(View v) {
        if(v == buttonClick){
            rgGender = (RadioGroup) findViewById(R.id.rg_gender);
            int id = rgGender.getCheckedRadioButtonId();
            switch (id)
            {
                case R.id.radioMale:
                    //Toast.makeText(this,"Clicked "+((RadioButton)findViewById(id)).getText(), Toast.LENGTH_SHORT).show();
                    hasilgender.setText("Male");
                    break;
                case R.id.radioFemale:
                    //Toast.makeText(this,"Clicked "+((RadioButton)findViewById(id)).getText(), Toast.LENGTH_SHORT).show();
                    hasilgender.setText("Female");
                    break;
            }

            if(editTextName.getText().toString().trim().equals("") ||
                    editTextHeight.getText().toString().trim().equals("") ||
                    editTextWeight.getText().toString().trim().equals("") ||
                    hasilgender.getText().toString().trim().equals("") ||
                    tvhasilUsia.getText().toString().trim().equals(""))
            {
                Toast.makeText(this,"Please fill all of your information!", Toast.LENGTH_SHORT).show();
            }
            else
                {
                final String weight = editTextWeight.getText().toString().trim();
                final String height = editTextHeight.getText().toString().trim();
                final String gender = hasilgender.getText().toString().trim();
                final String age = tvhasilUsia.getText().toString().trim();

                if (!"".equals(height) && !"".equals(weight)) {
                    float heightValue = Float.parseFloat(height) / 100;
                    float weightValue = Float.parseFloat(weight);

                    float bmiV = weightValue / (heightValue * heightValue);
                    displayBMI(bmiV);
                }
                if (!"".equals(height) && !"".equals(weight) && !"".equals(gender))
                {
                    float heightValue = Float.parseFloat(height);
                    float weightValue = Float.parseFloat(weight);
                    float ageValue = Float.parseFloat(age);

                    if(gender.equalsIgnoreCase("male"))
                    {
                        float bmrV = 66 + (13.7f * weightValue) + (5.0f * heightValue) - (6.8f * ageValue);
                        displayBMR(bmrV);
                    }
                    else if(gender.equalsIgnoreCase("female"))
                    {
                        float bmrV = 655 + (9.6f * weightValue) + (1.8f * heightValue) - (4.7f * ageValue);
                        displayBMR(bmrV);
                    }
                    else
                    {
                        String bmrLabel = "Input gender only 'male' of 'female'!";
                        editTextBmr.setText(bmrLabel);
                    }
                }
            }
        }

        if(v == buttonAdd){
            if(editTextName.getText().toString().trim().equals("") ||
                    editTextHeight.getText().toString().trim().equals("") ||
                    editTextWeight.getText().toString().trim().equals("") ||
                    hasilgender.getText().toString().trim().equals("") ||
                    tvhasilUsia.getText().toString().trim().equals("") ||
                    editTextBmr.getText().toString().trim().equals("") ||
                    editTextBmi.getText().toString().trim().equals(""))
            {
                Toast.makeText(this,"Please fill all of your data first!", Toast.LENGTH_SHORT).show();
            }else {
                addEmployee();
            }
        }

        if(v == buttonView){
            startActivity(new Intent(this,TampilSemuaPgw.class));
        }
    }
}
