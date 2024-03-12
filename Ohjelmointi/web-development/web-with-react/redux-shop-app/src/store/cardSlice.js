import { createSlice } from '@reduxjs/toolkit';

function generateRandomId() {
    const randomNumber = Math.random().toString(36).substr(2, 9);
    return randomNumber;
}

const cartSlice = createSlice({
    name: 'cart',
    initialState: [],
    reducers: {
        addItemToCart(state, action) {
            const newItem = { ...action.payload, id: generateRandomId(), quantity: 1 };
            const existingItem = state.find(item => item.title === newItem.title);

            if (existingItem) {
                existingItem.quantity++;
                existingItem.price = existingItem.price * existingItem.quantity;
            } else {
                newItem.quantity = 1;
                state.push(newItem);
            }
        },
        removeItemFromCart: (state, action) => {
            const itemToRemove = state.find(item => item.id === action.payload.id);

            if (itemToRemove) {
                if (itemToRemove.quantity > 1) {
                    itemToRemove.quantity--;
                    itemToRemove.price = itemToRemove.price / (itemToRemove.quantity + 1)
                } else {
                    state.splice(state.indexOf(itemToRemove), 1)
                }
            }
        },
    },
});

export const { addItemToCart, removeItemFromCart } = cartSlice.actions;
export default cartSlice.reducer;