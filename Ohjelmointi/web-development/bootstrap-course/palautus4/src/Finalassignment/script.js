document.addEventListener('scroll', function () {
    var scrollPosition = window.scrollY;
    var translateY = Math.min(scrollPosition / 4, 200);
    document.body.style.setProperty('--triangle-translate-y', translateY + 'px');
});

document.addEventListener("DOMContentLoaded", function () {
    const productsContainer = document.getElementById("products-container");

    fetch("https://fakestoreapi.com/products")
        .then(response => response.json())
        .then(products => {
            products.forEach(product => {
                const productCard = createProductCard(product);
                productsContainer.appendChild(productCard);
            })
        })
        .catch(error => console.log(error));

    function createProductCard(product) {
        const card = document.createElement("div");
        card.classList.add("product-card");

        const title = document.createElement("h2");
        title.textContent = product.title;

        const price = document.createElement("p");
        price.textContent = product.price + "€";

        const description = document.createElement("p");
        description.textContent = product.description;

        const image = document.createElement("img");
        image.src = product.image;
        image.alt = product.title;
        image.classList.add("product-image");

        card.appendChild(title);
        card.appendChild(price);
        card.appendChild(description);
        card.appendChild(image);

        card.addEventListener("click", function () {
            openModal(product);
        }
        );
        return card;
    }

    function openModal(product) {
        const modalTitle = document.getElementById("productModalLabel");
        const modalPrice = document.getElementById("modal-price");
        const modalDescription = document.getElementById("modal-description");
        const modalImage = document.getElementById("modal-image");
        const modalCategory = document.getElementById("modal-category");
        const modalRating = document.getElementById("modal-rating");

        modalTitle.textContent = product.title;
        modalPrice.textContent = `${product.price}€`;
        modalDescription.textContent = product.description;
        modalImage.src = product.image;
        modalImage.alt = product.title;
        modalCategory.textContent = `Category: ${product.category}`;
        modalRating.textContent = `Product rated: ${product.rating.rate} / 5`;

        const productModal = new bootstrap.Modal(document.getElementById("productModal"));
        productModal.show();
    }
})