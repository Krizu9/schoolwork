'use client';
import { FC, useEffect, useState } from 'react';
import Image from 'next/image';
import styles from './productview.module.css';

interface Productprops {
    params: {
        product: string;
    };
}

interface Product {
    id: number;
    title: string;
    price: number;
    description: string;
    category: string;
    image: string;
}

async function getData(params: { product: string }) {
    const res = await fetch(`https://fakestoreapi.com/products/${params.product}`);
    if (!res.ok) {
        throw new Error('Failed to fetch API');
    }
    return res.json();
}

const ProductPage: FC<Productprops> = ({ params }) => {
    const [product, setProduct] = useState<Product | null>(null);

    useEffect(() => {
        const fetchProductData = async () => {
            try {
                const data = await getData(params);
                setProduct(data);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchProductData();
    }, [params]);

    if (!product) {
        return <div>Loading...</div>;
    }

    return (
        <>
            <h1 className={styles.producText}>Product id: {params.product}</h1>
            <div key={product.id} className={styles.productCard}>
                <Image
                    className={styles.productImage}
                    src={product.image}
                    alt={product.title}
                    width={200}
                    height={200}
                />
                <div className={styles.producText}>Product title: {product.title} </div>
                <div className={styles.producText}>Product description: {product.description}</div>
                <div className={styles.producText}>Product category: {product.category}</div>
                <div className={styles.producText}>${product.price}</div>
            </div>
        </>
    );
};

export default ProductPage;
