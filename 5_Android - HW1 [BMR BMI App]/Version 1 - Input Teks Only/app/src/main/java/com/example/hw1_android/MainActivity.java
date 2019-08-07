package com.example.hw1_android;

import android.content.Intent;
import android.os.Bundle;
import androidx.appcompat.app.AppCompatActivity;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;

public class MainActivity extends AppCompatActivity {

    @BindView(R.id.input_name)
    EditText inputName;
    @BindView(R.id.input_age)
    EditText inputAge;
    @BindView(R.id.input_weight)
    EditText inputWeight;
    @BindView(R.id.input_height)
    EditText inputHeight;
    @BindView(R.id.input_gender)
    EditText inputGender;

    @BindView(R.id.save_button)
    Button simpan_button;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ButterKnife.bind(this);
    }

    @OnClick(R.id.save_button)
    public void btnClicked() {
        String name = inputName.getText().toString();
        String age = inputAge.getText().toString();
        String weight = inputWeight.getText().toString();
        String height = inputHeight.getText().toString();
        String gender = inputGender.getText().toString();

        Intent i = new Intent(this, Main2Activity.class);
        i.putExtra("NAME", name);
        i.putExtra("AGE", age);
        i.putExtra("WEIGHT", weight);
        i.putExtra("HEIGHT", height);
        i.putExtra("GENDER", gender);
        startActivity(i);
    }

}
