package com.example.hw1_android;
import android.content.Intent;
import android.os.Bundle;
import androidx.appcompat.app.AppCompatActivity;

import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;

public class Main2Activity extends AppCompatActivity {
    @BindView(R.id.hasil_name)
    TextView hasilName;
    @BindView(R.id.hasil_age)
    TextView hasilAge;
    @BindView(R.id.hasil_weight)
    TextView hasilWeight;
    @BindView(R.id.hasil_height)
    TextView hasilHeight;
    @BindView(R.id.hasil_gender)
    TextView hasilGender;

    @BindView(R.id.hasil_bmi)
    TextView hasilBmi;
    @BindView(R.id.hasil_bmr)
    TextView hasilBmr;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);
        ButterKnife.bind(this);

        Button buttonOne = findViewById(R.id.buttonOne);
        buttonOne.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                startActivity(new Intent(Main2Activity.this, MainActivity.class));
            }
        });

        String name = getIntent().getStringExtra("NAME");
        String age = getIntent().getStringExtra("AGE");
        String weight = getIntent().getStringExtra("WEIGHT");
        String height = getIntent().getStringExtra("HEIGHT");
        String gender = getIntent().getStringExtra("GENDER");

        hasilName.setText(name);
        hasilAge.setText(age);
        hasilWeight.setText(weight);
        hasilHeight.setText(height);
        hasilGender.setText(gender);

        if (!"".equals(height) && !"".equals(weight))
        {
            float heightValue = Float.parseFloat(height) / 100;
            float weightValue = Float.parseFloat(weight);

            float bmi = weightValue / (heightValue * heightValue);

            displayBMI(bmi);
        }

        if (!"".equals(height) && !"".equals(weight) && !"".equals(gender))
        {
            float heightValue = Float.parseFloat(height);
            float weightValue = Float.parseFloat(weight);
            float ageValue = Float.parseFloat(age);

            if(gender.equalsIgnoreCase("Male"))
            {
                float bmr = 66 + (13.7f * weightValue) + (5.0f * heightValue) - (6.8f * ageValue);
                displayBMR(bmr);
            }
            else if(gender.equalsIgnoreCase("Female"))
            {
                float bmr = 655 + (9.6f * weightValue) + (1.8f * heightValue) - (4.7f * ageValue);
                displayBMR(bmr);
            }
            else
            {
                String bmrLabel = "Input gender only 'Male' of 'Female'!";
                hasilBmr.setText(bmrLabel);
            }
        }
    }

    private void displayBMI(float bmi) {
        String bmiLabel = "";

        bmiLabel = bmi + "\n\n" + bmiLabel;
        hasilBmi.setText(bmiLabel);
    }
    private void displayBMR(float bmr) {
        String bmrLabel = "";

        bmrLabel = bmr + "\n\n" + bmrLabel;
        hasilBmr.setText(bmrLabel);
    }
}
