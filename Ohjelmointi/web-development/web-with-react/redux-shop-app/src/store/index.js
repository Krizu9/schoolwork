import { configureStore } from '@reduxjs/toolkit';
import productsReducer from './slice';
import cartReducer from './cardSlice';


const store = configureStore({
    reducer: {
        products: productsReducer,
        cart: cartReducer,
    }
});

export default store;
