import Link from 'next/link'
import styles from './layout.module.css'

export const metadata = {
  title: 'My JAMK App',
  description: 'Generated by create next app',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body>
        <div className={styles.header}>
          <div>The Fake Store</div>
          <div className={styles.linkbox}>
            <div className={styles.links}><Link href="/pages/home">Home</Link></div>
            <div className={styles.links}><Link href="/pages/products">Products</Link></div>
            <div className={styles.links}><Link href="/pages/about">About</Link></div>
          </div>
        </div>
        <div>{children}</div>
      </body>
    </html>
  )
}