package com.example.e11golfcourses

import android.os.Bundle
import android.preference.PreferenceManager.getDefaultSharedPreferences
import android.util.Log
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import com.android.volley.Request
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.example.e10favouritecities.R
import com.google.gson.Gson
import org.osmdroid.config.Configuration
import org.osmdroid.tileprovider.tilesource.TileSourceFactory
import org.osmdroid.util.GeoPoint
import org.osmdroid.views.MapView
import org.osmdroid.views.overlay.ItemizedIconOverlay
import org.osmdroid.views.overlay.OverlayItem

class MainActivity : AppCompatActivity() {
    private val requestPermissionsRequestCode = 1
    private lateinit var map: MapView
    private var currentOverlayItem: OverlayItem? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        Configuration.getInstance().load(this, getDefaultSharedPreferences(this))

        setContentView(R.layout.activity_main)

        map = findViewById(R.id.mapview)
        map.setTileSource(TileSourceFactory.MAPNIK)

        val mapController = map.controller
        mapController.setZoom(7)
        val startPoint = GeoPoint(63.83333, 26.93276)
        mapController.setCenter(startPoint)

        fetchDataFromJson()
    }

    private fun fetchDataFromJson() {
        val url = "https://ptm.fi/materials/golfcourses/golf_courses.json"
        val requestQueue = Volley.newRequestQueue(this)

        val jsonObjectRequest = JsonObjectRequest(
            Request.Method.GET, url, null,
            { response ->
                val gson = Gson()
                val courses =
                    gson.fromJson(response.getJSONArray("courses").toString(), Array<Course>::class.java)

                addMarkersToMap(courses)
            },
            { error ->
                Log.d("YourTag", "Error occurred: ${error.message}")
            }
        )

        requestQueue.add(jsonObjectRequest)
    }

    private fun addMarkersToMap(courses: Array<Course>) {
        val items = ArrayList<OverlayItem>()

        for (course in courses) {
            val marker = OverlayItem(
                course.course,
                "Address: ${course.address}\nPhone: ${course.phone}\nEmail: ${course.email}\nWeb: ${course.web}",
                GeoPoint(course.lat, course.lng)
            )
            items.add(marker)
        }

        val overlay = ItemizedIconOverlay<OverlayItem>(
            items,
            object : ItemizedIconOverlay.OnItemGestureListener<OverlayItem> {
                override fun onItemSingleTapUp(index: Int, item: OverlayItem): Boolean {
                    clearPreviousInfo()
                    showLocationInfo(item)
                    return true
                }

                override fun onItemLongPress(index: Int, item: OverlayItem): Boolean {
                    return false
                }
            },
            applicationContext
        )

        map.overlays.add(overlay)

        map.invalidate()
    }

    override fun onResume() {
        super.onResume()
        map.onResume()
    }

    override fun onPause() {
        super.onPause()
        map.onPause()
    }

    override fun onRequestPermissionsResult(
        requestCode: Int,
        permissions: Array<out String>,
        grantResults: IntArray
    ) {
        val permissionsToRequest = ArrayList<String>()
        var i = 0
        while (i < grantResults.size) {
            permissionsToRequest.add(permissions[i])
            i++
        }
        if (permissionsToRequest.isNotEmpty()) {
            ActivityCompat.requestPermissions(
                this,
                permissionsToRequest.toTypedArray(),
                requestPermissionsRequestCode
            )
        } else {
            super.onRequestPermissionsResult(requestCode, permissions, grantResults)
        }
    }

    private fun clearPreviousInfo() {
        currentOverlayItem = null
    }

    private fun showLocationInfo(item: OverlayItem) {
        val dialog = AlertDialog.Builder(this)
            .setTitle(item.title)
            .setMessage(item.snippet)
            .setPositiveButton("OK") { _, _ -> }
            .create()
        dialog.show()
    }

    data class Course(
        val type: String,
        val lat: Double,
        val lng: Double,
        val course: String,
        val address: String,
        val phone: String,
        val email: String,
        val web: String,
        val image: String,
        val text: String
    )
}
