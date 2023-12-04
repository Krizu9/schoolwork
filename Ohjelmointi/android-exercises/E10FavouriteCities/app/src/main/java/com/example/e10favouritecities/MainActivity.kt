package com.example.e10favouritecities

import android.os.Bundle
import android.preference.PreferenceManager.getDefaultSharedPreferences
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import org.osmdroid.config.Configuration.getInstance
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

        getInstance().load(this, getDefaultSharedPreferences(this))

        setContentView(R.layout.activity_main)

        map = findViewById(R.id.mapview)
        map.setTileSource(TileSourceFactory.MAPNIK)

        val mapController = map.controller
        mapController.setZoom(7)
        val startPoint = GeoPoint(63.83333, 26.93276)
        mapController.setCenter(startPoint)

        val items = ArrayList<OverlayItem>()
        val marker1 = OverlayItem("Seinäjoki", "Where I spent my youth", GeoPoint(62.79446, 22.82822))
        val marker2 = OverlayItem("Ilmajoki", "Where I grew up", GeoPoint(62.73333, 22.56667))
        val marker3 = OverlayItem("Lapinlahti", "Where a lot of my friends live", GeoPoint(63.36667, 27.4))
        val marker4 = OverlayItem("Kokkola", "Where I started my studies", GeoPoint(63.83847, 23.13066))
        val marker5 = OverlayItem("Jyväskylä", "Where I live now", GeoPoint(62.24147, 25.72088))

        items.add(marker1)
        items.add(marker2)
        items.add(marker3)
        items.add(marker4)
        items.add(marker5)

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
}
