<template>
  <nav class="navbar">
    <div class="container-fluid">
      <a class="navbar-brand" href="#">Gymdiary-app</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
              aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav">
          <li class="nav-item">
            <RouterLink to="/login" class="nav-link-button">Login</RouterLink>
          </li>
          <li class="nav-item">
            <RouterLink to="/" class="nav-link-button">Home</RouterLink>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<style>

</style>
