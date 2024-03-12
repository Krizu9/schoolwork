package com.example.e16weatherwidget

import android.app.PendingIntent
import android.appwidget.AppWidgetManager
import android.appwidget.AppWidgetProvider
import android.content.Context
import android.content.Intent
import android.graphics.Color
import android.util.Log
import android.util.TypedValue
import android.widget.RemoteViews
import com.android.volley.Request
import com.android.volley.RequestQueue
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.bumptech.glide.Glide
import com.bumptech.glide.request.target.AppWidgetTarget
import java.time.Instant
import java.time.ZoneId
import java.time.format.DateTimeFormatter

class WeatherAppWidget : AppWidgetProvider() {
    val API_LINK: String = "https://api.openweathermap.org/data/2.5/weather?q="
    val API_ICON: String = "https://openweathermap.org/img/w/"
    val API_KEY: String = "removed"

    override fun onUpdate(
        context: Context,
        appWidgetManager: AppWidgetManager,
        appWidgetIds: IntArray
    ) {
        for (appWidgetId in appWidgetIds) {
            updateAppWidget(context, appWidgetManager, appWidgetId)
            val intent = Intent(context, MainActivity::class.java)
            val pendingIntent = PendingIntent.getActivity(context, 0, intent, PendingIntent.FLAG_UPDATE_CURRENT or PendingIntent.FLAG_IMMUTABLE)

            val views = RemoteViews(context.packageName, R.layout.weather_app_widget)
            views.setOnClickPendingIntent(R.id.cityTextView, pendingIntent)

            loadWeatherForecast("Jyväskylä", context, views, appWidgetId, appWidgetManager)
            updateAppWidget(context, appWidgetManager, appWidgetId)
        }
    }

    override fun onReceive(context: Context, intent: Intent) {
        super.onReceive(context, intent)

        if (intent.action == "com.example.weatherwidget.REFRESH") {

            val appWidgetManager = AppWidgetManager.getInstance(context.applicationContext)

            val views = RemoteViews(context.packageName, R.layout.weather_app_widget)

            val appWidgetId = intent.extras!!.getInt("appWidgetId")

            loadWeatherForecast("Jyväskylä", context, views, appWidgetId, appWidgetManager)
        }

    }

    private fun loadWeatherForecast(
        city: String,
        context: Context,
        views: RemoteViews,
        appWidgetId: Int,
        appWidgetManager: AppWidgetManager
    ) {

        val url = "$API_LINK$city&APPID=$API_KEY&units=metric"

        val jsonObjectRequest = JsonObjectRequest(
            Request.Method.GET, url, null, { response ->
                try {
                    val mainJSONObject = response.getJSONObject("main")
                    val weatherArray = response.getJSONArray("weather")
                    val firstWeatherObject = weatherArray.getJSONObject(0)

                    val cityName = response.getString("name")
                    val condition = firstWeatherObject.getString("main")
                    val temperature = mainJSONObject.getString("temp") + " °C"

                    val weatherTime: String = response.getString("dt")
                    val weatherLong: Long = weatherTime.toLong()
                    val formatter: DateTimeFormatter = DateTimeFormatter.ofPattern("HH:mm")
                    val dt = Instant.ofEpochSecond(weatherLong).atZone(ZoneId.systemDefault())
                        .toLocalDateTime().format(formatter).toString()


                    views.setTextViewText(R.id.cityTextView, cityName)
                    views.setTextViewText(R.id.condTextView, condition)
                    views.setTextViewText(R.id.tempTextView, temperature)
                    views.setTextViewText(R.id.timeTextView, dt)


                    val awt: AppWidgetTarget = object :
                        AppWidgetTarget(context.applicationContext, R.id.iconImageView, views, appWidgetId) {}
                    val weatherIcon = firstWeatherObject.getString("icon")
                    val iconUrl = "$API_ICON$weatherIcon.png"


                    Glide
                        .with(context)
                        .asBitmap()
                        .load(iconUrl)
                        .into(awt)

                    views.setTextColor(R.id.cityTextView, Color.BLUE)


                    val refreshIntent = Intent(context, WeatherAppWidget::class.java)
                    refreshIntent.action = "com.example.weatherwidget.REFRESH"
                    refreshIntent.putExtra("appWidgetId", appWidgetId)

                    val refreshPendingIntent = PendingIntent.getBroadcast(context, 0, refreshIntent, PendingIntent.FLAG_UPDATE_CURRENT or PendingIntent.FLAG_IMMUTABLE)

                    views.setOnClickPendingIntent(R.id.refreshImageView, refreshPendingIntent)

                    appWidgetManager.updateAppWidget(appWidgetId, views)

                } catch (e: Exception) {
                    e.printStackTrace()
                    Log.d("WEATHER", "***** error: $e")
                }
            },
            { error -> Log.d("ERROR", "Error: $error") })


        val queue: RequestQueue = Volley.newRequestQueue(context)
        queue.add(jsonObjectRequest)
        appWidgetManager.updateAppWidget(appWidgetId, views)
    }

}

internal fun updateAppWidget(
    context: Context,
    appWidgetManager: AppWidgetManager,
    appWidgetId: Int
) {
    val widgetText = context.getString(R.string.appwidget_text)

    val views = RemoteViews(context.packageName, R.layout.weather_app_widget)

    appWidgetManager.updateAppWidget(appWidgetId, views)
}