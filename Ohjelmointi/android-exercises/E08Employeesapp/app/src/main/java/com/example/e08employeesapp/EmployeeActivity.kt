package com.example.e08employeesapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import org.json.JSONObject

class EmployeeActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_employee)


        val imageView : ImageView = findViewById(R.id.imageView2)
        val nameTextView: TextView = findViewById(R.id.newNametextView)
        val titleTextView: TextView = findViewById(R.id.newTitleTextView)
        val emailTextView: TextView = findViewById(R.id.newEmailTextView)
        val phoneTextView: TextView = findViewById(R.id.newPhoneTextView)
        val departmentTextView: TextView = findViewById(R.id.newDepartmentTextView)

        val bundle: Bundle? = intent.extras
        if (bundle != null) {
            val employeeString = bundle.getString("employee")
            if (employeeString != null) {
                val employee = JSONObject(employeeString)
                val name= employee["firstName"]


                Glide.with(imageView)
                    .load(employee.getString("image"))
                    .into(imageView)
                nameTextView.text = "${employee.getString("firstName")} ${employee.getString("lastName")}"
                titleTextView.text = "${employee.getString("title")}"
                emailTextView.text = "${employee.getString("email")}"
                phoneTextView.text = "${employee.getString("phone")} "
                departmentTextView.text = "${employee.getString("department")}"

            }

        }

    }
}