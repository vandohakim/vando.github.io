package com.example.androidsocket5august;

import android.os.AsyncTask;
import android.util.Log;

import java.io.DataOutputStream;
import java.io.IOException;
import java.io.PrintWriter;
import java.net.Socket;

public class message extends AsyncTask<String, String, Void> {
    Socket s;
    DataOutputStream dO;
    PrintWriter pw;

    public message(Socket x){
        this.s = x;
    }

    @Override
    protected Void doInBackground(String... data){
        String msg = data[0];
        try {
            pw = new PrintWriter(s.getOutputStream());
            pw.write(msg);
            pw.flush();
        }catch (IOException e){
            e.printStackTrace();
        }

        return null;
    }

}
