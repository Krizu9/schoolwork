package com.example.e07myfirstappwithnavigation

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.EditText
import androidx.navigation.findNavController

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun sendMessage(view: View){
        val editText = findViewById<EditText>(R.id.messagee)
        val message = editText.text.toString()

        val action = FragmentOneDirections.actionFragmentOneToFragmentTwo(message)
        view.findNavController().navigate(action)
    }
}
