import React, { useState, useEffect } from 'react';
import {
  StyleSheet,
  Text,
  View,
  TextInput,
  Button,
  ScrollView,
  Keyboard,
} from 'react-native';
import Realm from 'realm';
import 'react-native-get-random-values';

const TodoSchema = {
  name: 'Todo',
  primaryKey: '_id',
  properties: {
    _id: 'objectId',
    text: 'string',
    completed: { type: 'bool', default: false },
  },
};

export default function App() {
  const [itemText, setItemText] = useState('');
  const [items, setItems] = useState([]);

  useEffect(() => {
    Realm.open({ schema: [TodoSchema] }).then((realm) => {
      const todos = realm.objects('Todo');

      setItems([...todos]);

      todos.addListener(() => {
        setItems([...todos]);
      });
    });
  }, []);

  const addToDoItem = async () => {
    if (itemText !== '') {
      const newTodo = { _id: new Realm.BSON.ObjectId(), text: itemText };
      const realm = await Realm.open({ schema: [TodoSchema] });
      realm.write(() => {
        realm.create('Todo', newTodo);
      });

      setItems([...items, newTodo]);
      setItemText('');
    }
    Keyboard.dismiss();
  };

  const removeItem = async (id) => {
    const realm = await Realm.open({ schema: [TodoSchema] });
    const todo = realm.objectForPrimaryKey('Todo', new Realm.BSON.ObjectId(id));

    try {
      realm.write(() => {
        realm.delete(todo);
      });
    } catch (e) {
      console.error("Failed to delete todo", e);
    }

    const newItems = items.filter((item) => item._id.toString() !== id);
    setItems(newItems);
  };

  const toggleCompleted = async (id) => {
    const realm = await Realm.open({ schema: [TodoSchema] });
    const todo = realm.objectForPrimaryKey('Todo', id);
    realm.write(() => {
      todo.completed = !todo.completed;
    });

    const newItems = items.map((item) => {
      if (item._id.toString() === id) {
        return { ...item, completed: !item.completed };
      } else {
        return item;
      }
    });
    setItems(newItems);
  };

  return (
    <View style={styles.container}>
      <View style={styles.addToDo}>
        <TextInput
          style={styles.addToDoTextInput}
          value={itemText}
          onChangeText={(text) => setItemText(text)}
          placeholder="Write a new todo here"
        />
        <Button title="Add" onPress={addToDoItem} />
      </View>
      <ScrollView style={styles.list}>
        {items.map((item) => (
          <View key={item._id} style={styles.listItem}>
            <Text
              style={[styles.listItemText, item.completed && styles.completed]}
              onPress={() => toggleCompleted(item._id.toString())}
            >
              * {item.text}
            </Text>
            <Text
              style={styles.listItemDelete}
              onPress={() => removeItem(item._id.toString())}
            >
              X
            </Text>
          </View>
        ))}
      </ScrollView>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 25,
    margin: 5,
  },
  addToDo: {
    flexDirection: 'row',
    marginBottom: 20,
  },
  addToDoTextInput: {
    borderWidth: 1,
    borderStyle: 'solid',
    borderColor: '#ccc',
    padding: 5,
    margin: 2,
    flex: 1,
  },
  list: {
    color: 'black',
    margin: 2,
  },
  listItem: {
    flexDirection: 'row',
    margin: 5,
  },
  listItemText: {},
  listItemDelete: {
    marginStart: 10,
    color: 'red',
    fontWeight: 'bold',
  },
});
