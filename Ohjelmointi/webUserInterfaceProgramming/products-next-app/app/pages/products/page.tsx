import styles from './productlist.module.css'
import Image from 'next/image'
import Link from 'next/link'


async function getData() {
    const res = await fetch('https://fakestoreapi.com/products')
    if (!res.ok) {
        throw new Error('Failed to fetch API')
    }
    return res.json()
}

interface Product {
    id: number
    title: string
    price: number
    description: string
    category: string
    image: string
}



export default async function Page() {
    const data = await getData()
    return (
        <>
            <div className={styles.productContainer}>
                {data.map((product: Product) => (
                    <div key={product.id} className={styles.productCard}>
                        <Image
                            className={styles.productImage}
                            src={product.image}
                            alt={product.title}
                            width={200}
                            height={200}
                        />
                        <div className={styles.productTitle}>{product.title} </div>
                        <div className={styles.productPrice}>${product.price}</div>
                        <div className={styles.links}><Link href={`/pages/products/${product.id}`}>
                            Open Product
                        </Link></div>
                    </div>
                ))}

            </div>
        </>
    )
}