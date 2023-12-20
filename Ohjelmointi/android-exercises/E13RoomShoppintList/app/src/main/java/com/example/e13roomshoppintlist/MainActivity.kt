package com.example.e13roomshoppintlist

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.os.Handler
import android.os.Looper
import android.os.Message
import android.widget.Toast
import androidx.recyclerview.widget.ItemTouchHelper
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import androidx.room.Room
import com.google.android.material.floatingactionbutton.FloatingActionButton

class MainActivity:
    AppCompatActivity(),
    AskShoppingListItemDialogFragment.AddDialogListener {
    private var shoppingList: MutableList<ShoppingListItem> = ArrayList()
    private lateinit var adapter: ShoppingListAdapter
    private lateinit var recyclerView: RecyclerView
    private lateinit var db: ShoppingListRoomDatabase

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        recyclerView = findViewById(R.id.recyclerView)
        recyclerView.layoutManager = LinearLayoutManager(this)
        adapter = ShoppingListAdapter(shoppingList)
        recyclerView.adapter = adapter

        db = Room.databaseBuilder(
            applicationContext,
            ShoppingListRoomDatabase::class.java,
            "shopping_list_table"
        ).build()

        findViewById<FloatingActionButton>(R.id.floatingActionButton).setOnClickListener { view ->
            val dialog = AskShoppingListItemDialogFragment()
            dialog.show(supportFragmentManager, "AskNewItemDialogFragment")
        }
        initSwipe()
        loadShoppingListItems()
    }

    private fun initSwipe() {
        val simpleItemTouchCallback =
            object : ItemTouchHelper.SimpleCallback(0, ItemTouchHelper.LEFT) {
                override fun onSwiped(viewHolder: RecyclerView.ViewHolder, direction: Int) {
                    val position = viewHolder.adapterPosition
                    val handler = Handler(Looper.getMainLooper(), Handler.Callback {
                        Toast.makeText(
                            applicationContext,
                            it.data.getString("message"),
                            Toast.LENGTH_SHORT
                        ).show()
                        adapter.update(shoppingList)
                        true
                    })
                    var id = shoppingList[position].id
                    shoppingList.removeAt(position)
                    Thread(Runnable {
                        db.shoppingListDao().delete(id)
                        val message = Message.obtain()
                        message.data.putString("message", "Item deleted from db!")
                        handler.sendMessage(message)
                    }).start()
                }

                // Moved
                override fun onMove(
                    p0: RecyclerView,
                    p1: RecyclerView.ViewHolder,
                    p2: RecyclerView.ViewHolder
                )
                        : Boolean {
                    return true
                }
            }

        val itemTouchHelper = ItemTouchHelper(simpleItemTouchCallback)
        itemTouchHelper.attachToRecyclerView(recyclerView)
    }

    private fun loadShoppingListItems() {
        val handler = Handler(Looper.getMainLooper(), Handler.Callback {
            Toast.makeText(
                applicationContext,
                it.data.getString("message"),
                Toast.LENGTH_SHORT
            ).show()
            adapter.update(shoppingList)
            true
        })

        Thread(Runnable {
            shoppingList = db.shoppingListDao().getAll()
            val message = Message.obtain()
            if (shoppingList.size > 0)
                message.data.putString("message", "Data read from db!")
            else
                message.data.putString("message", "Shopping list is empty!")
            handler.sendMessage(message)
        }).start()
    }

    override fun onDialogPositiveClick(item: ShoppingListItem) {
        shoppingList.add(item)

        var handler = Handler(Looper.getMainLooper(), Handler.Callback {
            Toast.makeText(
                applicationContext,
                it.data.getString("message"),
                Toast.LENGTH_SHORT
            ).show()
            adapter.update(shoppingList)
            true
        })

        Thread(Runnable {
            val id = db.shoppingListDao().insert(item)
            item.id = id.toInt()
            val message = Message.obtain()
            message.data.putString("message", "Item added to db!")
            handler.sendMessage(message)
        }).start()
    }
}