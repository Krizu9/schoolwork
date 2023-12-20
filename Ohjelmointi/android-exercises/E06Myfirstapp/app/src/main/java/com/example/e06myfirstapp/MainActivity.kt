package com.example.e06myfirstapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

            val button1 = findViewById<Button>(R.id.switch_button1)

        button1.setOnClickListener {
            val messageText = findViewById<EditText>(R.id.message).text.toString()
            val intent = Intent(this, SecondActivity::class.java)
            intent.putExtra("Message", messageText)
            startActivity(intent)
        }
    }
}