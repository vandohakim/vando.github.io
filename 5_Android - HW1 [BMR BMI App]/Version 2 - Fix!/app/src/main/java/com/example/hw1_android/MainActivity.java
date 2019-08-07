package com.example.hw1_android;

import android.content.Intent;
import android.os.Bundle;
import androidx.appcompat.app.AppCompatActivity;

import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Toast;
import android.widget.TextView;
import android.app.DatePickerDialog;
import android.widget.DatePicker;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.w3c.dom.Text;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;

public class MainActivity extends AppCompatActivity {

    @BindView(R.id.input_name)
    EditText inputName;
    @BindView(R.id.input_weight)
    EditText inputWeight;
    @BindView(R.id.input_height)
    EditText inputHeight;

    @BindView(R.id.hasilgender)
    TextView hasilgender;

    private DatePickerDialog datePickerDialog;
    private SimpleDateFormat dateFormatter;
    private TextView tvDateResult;
    private TextView tvDateYearResult;
    private TextView tvhasilUsia;
    private Button btDatePicker;

    @BindView(R.id.save_button)
    Button simpan_button;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ButterKnife.bind(this);

        dateFormatter = new SimpleDateFormat("dd-MM-yyyy", Locale.US);

        tvDateResult = findViewById(R.id.tahun);
        tvDateYearResult = findViewById(R.id.tahunlahir);
        tvhasilUsia = findViewById(R.id.hasilusia);
        btDatePicker = findViewById(R.id.buttonDate);
        btDatePicker.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view) {
                showDateDialog();
            }
        });
    }

    private void showDateDialog(){

        Calendar newCalendar = Calendar.getInstance();
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

    @OnClick(R.id.save_button)
    public void btnClicked() {
        String name = inputName.getText().toString();
        String age = tvhasilUsia.getText().toString().trim();
        String weight = inputWeight.getText().toString();
        String height = inputHeight.getText().toString();

        RadioGroup rgGender = findViewById(R.id.rg_gender);
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

        String gender = hasilgender.getText().toString();
        if(inputName.getText().toString().trim().equals("") ||
                inputHeight.getText().toString().trim().equals("") ||
                inputHeight.getText().toString().trim().equals("") ||
                hasilgender.getText().toString().trim().equals("") ||
                tvhasilUsia.getText().toString().trim().equals(""))
        {
            Toast.makeText(this,"Please fill all of your information!", Toast.LENGTH_SHORT).show();
        }else{
            Intent i = new Intent(this, Main2Activity.class);
            i.putExtra("NAME", name);
            i.putExtra("AGE", age);
            i.putExtra("WEIGHT", weight);
            i.putExtra("HEIGHT", height);
            i.putExtra("GENDER", gender);
            startActivity(i);
        }
    }

}
