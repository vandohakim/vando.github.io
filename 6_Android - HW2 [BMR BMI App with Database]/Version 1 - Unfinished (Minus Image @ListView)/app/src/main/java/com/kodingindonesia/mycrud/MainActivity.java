package com.kodingindonesia.mycrud;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

import java.util.HashMap;

public class MainActivity extends AppCompatActivity implements View.OnClickListener{

    //Dibawah ini merupakan perintah untuk mendefinikan View
    private EditText editTextName;
    private EditText editTextAge;
    private EditText editTextWeight;
    private EditText editTextHeight;
    private EditText editTextGender;

    private TextView editTextBmr;
    private TextView editTextBmi;

    private Button buttonClick;
    private Button buttonAdd;
    private Button buttonView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //Inisialisasi dari View
        editTextName = (EditText) findViewById(R.id.editTextName);
        editTextAge = (EditText) findViewById(R.id.editTextAge);
        editTextWeight = (EditText) findViewById(R.id.editTextWeight);
        editTextHeight = (EditText) findViewById(R.id.editTextHeight);
        editTextGender = (EditText) findViewById(R.id.editTextGender);

        editTextBmr = (TextView) findViewById(R.id.editTextBmr);
        editTextBmi = (TextView) findViewById(R.id.editTextBmi);

        buttonClick = (Button) findViewById(R.id.buttonClick);
        buttonAdd = (Button) findViewById(R.id.buttonAdd);
        buttonView = (Button) findViewById(R.id.buttonView);

        //Setting listeners to button
        buttonClick.setOnClickListener(this);
        buttonAdd.setOnClickListener(this);
        buttonView.setOnClickListener(this);
    }

    //Dibawah ini merupakan perintah untuk Menambahkan Pegawai (CREATE)
    private void addEmployee(){
        final String name = editTextName.getText().toString().trim();
        final String age = editTextAge.getText().toString().trim();
        final String weight = editTextWeight.getText().toString().trim();
        final String height = editTextHeight.getText().toString().trim();
        final String gender = editTextGender.getText().toString().trim();
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
            final String weight = editTextWeight.getText().toString().trim();
            final String height = editTextHeight.getText().toString().trim();
            final String gender = editTextGender.getText().toString().trim();
            final String age = editTextAge.getText().toString().trim();

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

                if(gender.equalsIgnoreCase("Male"))
                {
                    float bmrV = 66 + (13.7f * weightValue) + (5.0f * heightValue) - (6.8f * ageValue);
                    displayBMR(bmrV);
                }
                else if(gender.equalsIgnoreCase("Female"))
                {
                    float bmrV = 655 + (9.6f * weightValue) + (1.8f * heightValue) - (4.7f * ageValue);
                    displayBMR(bmrV);
                }
                else
                {
                    String bmrLabel = "Input gender only 'Male' of 'Female'!";
                    editTextBmr.setText(bmrLabel);
                }
            }
        }

        if(v == buttonAdd){
            addEmployee();
        }

        if(v == buttonView){
            startActivity(new Intent(this,TampilSemuaPgw.class));
        }
    }
}
