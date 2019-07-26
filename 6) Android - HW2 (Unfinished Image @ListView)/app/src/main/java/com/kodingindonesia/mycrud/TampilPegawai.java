package com.kodingindonesia.mycrud;

import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;



public class TampilPegawai extends AppCompatActivity implements View.OnClickListener{

    private EditText editTextId;
    private EditText editTextName;
    private EditText editTextAge;
    private EditText editTextWeight;
    private EditText editTextHeight;
    private EditText editTextGender;

    private TextView editTextBmr;
    private TextView editTextBmi;

    private Button buttonClick;
    private Button buttonUpdate;
    private Button buttonDelete;

    private String id;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tampil_pegawai);

        Intent intent = getIntent();

        id = intent.getStringExtra(konfigurasi.EMP_ID);

        editTextId = (EditText) findViewById(R.id.editTextId);
        editTextName = (EditText) findViewById(R.id.editTextName);
        editTextAge = (EditText) findViewById(R.id.editTextAge);
        editTextWeight = (EditText) findViewById(R.id.editTextWeight);
        editTextHeight = (EditText) findViewById(R.id.editTextHeight);
        editTextGender = (EditText) findViewById(R.id.editTextGender);

        editTextBmr = (TextView) findViewById(R.id.editTextBmr);
        editTextBmi = (TextView) findViewById(R.id.editTextBmi);

        buttonClick = (Button) findViewById(R.id.buttonClick);
        buttonUpdate = (Button) findViewById(R.id.buttonUpdate);
        buttonDelete = (Button) findViewById(R.id.buttonDelete);

        buttonClick.setOnClickListener(this);
        buttonUpdate.setOnClickListener(this);
        buttonDelete.setOnClickListener(this);

        editTextId.setText(id);

        getEmployee();
    }

    private void getEmployee(){
        class GetEmployee extends AsyncTask<Void,Void,String>{
            ProgressDialog loading;
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                loading = ProgressDialog.show(TampilPegawai.this,"Fetching...","Wait...",false,false);
            }

            @Override
            protected void onPostExecute(String s) {
                super.onPostExecute(s);
                loading.dismiss();
                showEmployee(s);
            }

            @Override
            protected String doInBackground(Void... params) {
                RequestHandler rh = new RequestHandler();
                String s = rh.sendGetRequestParam(konfigurasi.URL_GET_EMP,id);
                return s;
            }
        }
        GetEmployee ge = new GetEmployee();
        ge.execute();
    }

    private void showEmployee(String json){
        try {
            JSONObject jsonObject = new JSONObject(json);
            JSONArray result = jsonObject.getJSONArray(konfigurasi.TAG_JSON_ARRAY);
            JSONObject c = result.getJSONObject(0);
            String name = c.getString(konfigurasi.TAG_NAME);
            String age = c.getString(konfigurasi.TAG_AGE);
            String weight = c.getString(konfigurasi.TAG_WEIGHT);
            String height = c.getString(konfigurasi.TAG_HEIGHT);
            String gender = c.getString(konfigurasi.TAG_GENDER);
            String bmr = c.getString(konfigurasi.TAG_BMR);
            String bmi = c.getString(konfigurasi.TAG_BMI);

            editTextName.setText(name);
            editTextAge.setText(age);
            editTextWeight.setText(weight);
            editTextHeight.setText(height);
            editTextGender.setText(gender);
            editTextBmr.setText(bmr);
            editTextBmi.setText(bmi);

        } catch (JSONException e) {
            e.printStackTrace();
        }
    }


    private void updateEmployee(){
        final String name = editTextName.getText().toString().trim();
        final String age = editTextAge.getText().toString().trim();
        final String weight = editTextWeight.getText().toString().trim();
        final String height = editTextHeight.getText().toString().trim();
        final String gender = editTextGender.getText().toString().trim();
        final String bmr = editTextBmr.getText().toString().trim();
        final String bmi = editTextBmi.getText().toString().trim();

        class UpdateEmployee extends AsyncTask<Void,Void,String>{
            ProgressDialog loading;
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                loading = ProgressDialog.show(TampilPegawai.this,"Updating...","Wait...",false,false);
            }

            @Override
            protected void onPostExecute(String s) {
                super.onPostExecute(s);
                loading.dismiss();
                Toast.makeText(TampilPegawai.this,s,Toast.LENGTH_LONG).show();
            }

            @Override
            protected String doInBackground(Void... params) {
                HashMap<String,String> hashMap = new HashMap<>();
                hashMap.put(konfigurasi.KEY_EMP_ID,id);
                hashMap.put(konfigurasi.KEY_EMP_NAME,name);
                hashMap.put(konfigurasi.KEY_EMP_AGE,age);
                hashMap.put(konfigurasi.KEY_EMP_WEIGHT,weight);
                hashMap.put(konfigurasi.KEY_EMP_HEIGHT,height);
                hashMap.put(konfigurasi.KEY_EMP_GENDER,gender);
                hashMap.put(konfigurasi.KEY_EMP_BMR,bmr);
                hashMap.put(konfigurasi.KEY_EMP_BMI,bmi);

                RequestHandler rh = new RequestHandler();

                String s = rh.sendPostRequest(konfigurasi.URL_UPDATE_EMP,hashMap);

                return s;
            }
        }

        UpdateEmployee ue = new UpdateEmployee();
        ue.execute();
    }

    private void deleteEmployee(){
        class DeleteEmployee extends AsyncTask<Void,Void,String> {
            ProgressDialog loading;

            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                loading = ProgressDialog.show(TampilPegawai.this, "Updating...", "Wait...", false, false);
            }

            @Override
            protected void onPostExecute(String s) {
                super.onPostExecute(s);
                loading.dismiss();
                Toast.makeText(TampilPegawai.this, s, Toast.LENGTH_LONG).show();
            }

            @Override
            protected String doInBackground(Void... params) {
                RequestHandler rh = new RequestHandler();
                String s = rh.sendGetRequestParam(konfigurasi.URL_DELETE_EMP, id);
                return s;
            }
        }

        DeleteEmployee de = new DeleteEmployee();
        de.execute();
    }

    private void confirmDeleteEmployee(){
        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(this);
        alertDialogBuilder.setMessage("Are you sure want to delete this data?");

        alertDialogBuilder.setPositiveButton("Yes",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface arg0, int arg1) {
                        deleteEmployee();
                        startActivity(new Intent(TampilPegawai.this,TampilSemuaPgw.class));
                    }
                });

        alertDialogBuilder.setNegativeButton("No",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface arg0, int arg1) {

                    }
                });

        AlertDialog alertDialog = alertDialogBuilder.create();
        alertDialog.show();
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

        if(v == buttonUpdate){
            updateEmployee();
        }

        if(v == buttonDelete){
            confirmDeleteEmployee();
        }
    }
}
